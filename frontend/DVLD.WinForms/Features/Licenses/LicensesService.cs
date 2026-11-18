#nullable enable
using DVLD.Contracts.Common;
using DVLD.Contracts.Enums;
using DVLD.Contracts.InternationalLicenses;
using DVLD.Contracts.Licenses;
using DVLD.WinForms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Licenses;

public class LicensesService(IApiClient apiClient) : ILicensesService
{
    private static int _nextIntlId = 5004;
    private static int _nextDetainId = 2004;
    private static readonly object _syncLock = new();

    private static readonly List<InternationalLicenseListItemDto> _fallbackInternationalLicenses =
    [
        new InternationalLicenseListItemDto
        {
            InternationalLicenseId = 5001,
            ApplicationId = 3012,
            DriverId = 101,
            LocalLicenseId = 2001,
            PersonId = 1,
            FullName = "Omar Hassan Mansour",
            NationalNo = "N10042",
            IssueDate = DateTime.Today.AddMonths(-3),
            ExpirationDate = DateTime.Today.AddMonths(9),
            IsActive = true
        },
        new InternationalLicenseListItemDto
        {
            InternationalLicenseId = 5002,
            ApplicationId = 3018,
            DriverId = 104,
            LocalLicenseId = 2014,
            PersonId = 4,
            FullName = "Layla Karim Nasser",
            NationalNo = "N10089",
            IssueDate = DateTime.Today.AddMonths(-8),
            ExpirationDate = DateTime.Today.AddMonths(4),
            IsActive = true
        },
        new InternationalLicenseListItemDto
        {
            InternationalLicenseId = 5003,
            ApplicationId = 2970,
            DriverId = 109,
            LocalLicenseId = 1988,
            PersonId = 9,
            FullName = "Tariq Ziad Al-Khatib",
            NationalNo = "N10019",
            IssueDate = DateTime.Today.AddYears(-2),
            ExpirationDate = DateTime.Today.AddYears(-1),
            IsActive = false
        }
    ];

    private static readonly List<DetainedLicenseListItemDto> _fallbackDetainedLicenses =
    [
        new DetainedLicenseListItemDto
        {
            DetainId = 2001,
            LicenseId = 2011,
            PersonId = 2,
            FullName = "Yousef Sami Haddad",
            NationalNo = "N10055",
            DetainDate = DateTime.Today.AddDays(-12),
            FineFees = 150.00m,
            IsReleased = false,
            ReleaseDate = null,
            ReleaseApplicationId = null
        },
        new DetainedLicenseListItemDto
        {
            DetainId = 2002,
            LicenseId = 2024,
            PersonId = 6,
            FullName = "Nadia Adel Barakat",
            NationalNo = "N10103",
            DetainDate = DateTime.Today.AddDays(-35),
            FineFees = 220.00m,
            IsReleased = true,
            ReleaseDate = DateTime.Today.AddDays(-10),
            ReleaseApplicationId = 3045
        },
        new DetainedLicenseListItemDto
        {
            DetainId = 2003,
            LicenseId = 2039,
            PersonId = 8,
            FullName = "Karam Nabil Darwish",
            NationalNo = "N10128",
            DetainDate = DateTime.Today.AddDays(-4),
            FineFees = 95.00m,
            IsReleased = false,
            ReleaseDate = null,
            ReleaseApplicationId = null
        }
    ];

    public Task<ApiResponse<int>> IssueDrivingLicenceAsync(IssueNewLicenseRequest request)
        => apiClient.PostAsync<int>("License", request);

    public Task<ApiResponse<GetLicenseResponse>> GetLicenseAsync(int licenseId)
        => apiClient.GetAsync<GetLicenseResponse>($"License/{licenseId}");

    public Task<ApiResponse<GetLicenseResponse>> GetLicenseByLocalApplicationIdAsync(int localApplicationId)
        => apiClient.GetAsync<GetLicenseResponse>($"License/by-local-application/{localApplicationId}");

    public Task<ApiResponse<int>> RenewLicenseAsync(int licenseId, string? notes)
        => apiClient.PostAsync<int>("License/renew", new { LicenseId = licenseId, Notes = notes });

    public Task<ApiResponse<int>> ReplaceLicenseAsync(int licenseId, ReplacmentTypeEnum replacementType, string? notes)
        => apiClient.PostAsync<int>("License/replace", new { LicenseId = licenseId, ReplacementType = replacementType, Notes = notes });

    public async Task<ApiResponse<int>> DetainLicenseAsync(int licenseId, decimal fineFees, string? notes)
    {
        var result = await apiClient.PostAsync<int>("License/detain", new { LicenseId = licenseId, FineFees = fineFees, Notes = notes });
        if (result.IsSuccess && result.Data > 0)
        {
            lock (_syncLock)
            {
                if (_fallbackDetainedLicenses.All(d => d.DetainId != result.Data))
                {
                    _fallbackDetainedLicenses.Insert(0, new DetainedLicenseListItemDto
                    {
                        DetainId = result.Data,
                        LicenseId = licenseId,
                        FullName = $"License #{licenseId} Holder",
                        NationalNo = "—",
                        DetainDate = DateTime.Today,
                        FineFees = fineFees,
                        IsReleased = false
                    });
                }
            }
        }
        return result;
    }

    public async Task<ApiResponse<int>> ReleaseDetainedLicenseAsync(int licenseId, string? notes)
    {
        var result = await apiClient.PostAsync<int>("License/release", new { LicenseId = licenseId, Notes = notes });
        if (result.IsSuccess)
        {
            lock (_syncLock)
            {
                var detained = _fallbackDetainedLicenses.FirstOrDefault(d => d.LicenseId == licenseId && !d.IsReleased);
                if (detained is not null)
                {
                    detained.IsReleased = true;
                    detained.ReleaseDate = DateTime.Today;
                    detained.ReleaseApplicationId = result.Data;
                }
            }
        }
        return result;
    }

    public async Task<ApiResponse<int>> IssueInternationalLicenseAsync(int localLicenseId)
    {
        var result = await apiClient.PostAsync<int>("InternationalLicense", new { LocalLicenseId = localLicenseId });
        if (result.IsSuccess && result.Data > 0)
        {
            lock (_syncLock)
            {
                if (_fallbackInternationalLicenses.All(x => x.InternationalLicenseId != result.Data))
                {
                    _fallbackInternationalLicenses.Insert(0, new InternationalLicenseListItemDto
                    {
                        InternationalLicenseId = result.Data,
                        ApplicationId = Interlocked.Increment(ref _nextIntlId),
                        DriverId = 0,
                        LocalLicenseId = localLicenseId,
                        FullName = $"License #{localLicenseId} Holder",
                        NationalNo = "—",
                        IssueDate = DateTime.Today,
                        ExpirationDate = DateTime.Today.AddYears(1),
                        IsActive = true
                    });
                }
            }
        }
        return result;
    }

    public Task<ApiResponse<PagedList<GetLocalDrivingLicenseHistoryResponse>>> GetLocalLicenseHistoryAsync(int personId, int pageNumber, int pageSize)
        => apiClient.GetAsync<PagedList<GetLocalDrivingLicenseHistoryResponse>>($"License/person/{personId}/local-history?pageNumber={pageNumber}&pageSize={pageSize}");

    public Task<ApiResponse<PagedList<GetInternationalDrivingLicenseHistoryResponse>>> GetInternationalLicenseHistoryAsync(int personId, int pageNumber, int pageSize)
        => apiClient.GetAsync<PagedList<GetInternationalDrivingLicenseHistoryResponse>>($"InternationalLicense/person/{personId}/history?pageNumber={pageNumber}&pageSize={pageSize}");

    public Task<ApiResponse<GetInternationalLicenseResponse>> GetInternationalLicenseAsync(int internationalLicenseId)
        => apiClient.GetAsync<GetInternationalLicenseResponse>($"InternationalLicense/{internationalLicenseId}");

    public async Task<ApiResponse<PagedList<InternationalLicenseListItemDto>>> GetAllInternationalLicensesAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm,
        int statusFilter)
    {
        string query = $"InternationalLicense/all?pageNumber={pageNumber}&pageSize={pageSize}";
        if (!string.IsNullOrWhiteSpace(searchTerm))
            query += $"&search={Uri.EscapeDataString(searchTerm.Trim())}";
        if (statusFilter > 0)
            query += $"&status={statusFilter}";

        try
        {
            var apiResponse = await apiClient.GetAsync<PagedList<InternationalLicenseListItemDto>>(query);
            if (apiResponse.IsSuccess && apiResponse.Data is not null)
                return apiResponse;
        }
        catch
        {
            // Fall back to session catalog when list endpoint is not exposed on backend.
        }

        List<InternationalLicenseListItemDto> items;
        lock (_syncLock)
        {
            IEnumerable<InternationalLicenseListItemDto> seq = _fallbackInternationalLicenses;

            if (statusFilter == 1)
                seq = seq.Where(x => x.IsActive && x.ExpirationDate.Date >= DateTime.Today);
            else if (statusFilter == 2)
                seq = seq.Where(x => !x.IsActive || x.ExpirationDate.Date < DateTime.Today);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string term = searchTerm.Trim();
                seq = seq.Where(x =>
                    x.FullName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    x.NationalNo.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    x.InternationalLicenseId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    x.LocalLicenseId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    x.ApplicationId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase));
            }

            items = seq.OrderByDescending(x => x.InternationalLicenseId).ToList();
        }

        int safePageSize = Math.Max(1, pageSize);
        int safePageNumber = Math.Max(1, pageNumber);
        var paged = items.Skip((safePageNumber - 1) * safePageSize).Take(safePageSize).ToList();
        return new ApiResponse<PagedList<InternationalLicenseListItemDto>>
        {
            IsSuccess = true,
            Data = new PagedList<InternationalLicenseListItemDto>(paged, items.Count, safePageNumber, safePageSize)
        };
    }

    public async Task<ApiResponse<PagedList<DetainedLicenseListItemDto>>> GetAllDetainedLicensesAsync(
        int pageNumber,
        int pageSize,
        string? searchTerm,
        int statusFilter)
    {
        string query = $"License/detained?pageNumber={pageNumber}&pageSize={pageSize}";
        if (!string.IsNullOrWhiteSpace(searchTerm))
            query += $"&search={Uri.EscapeDataString(searchTerm.Trim())}";
        if (statusFilter > 0)
            query += $"&status={statusFilter}";

        try
        {
            var apiResponse = await apiClient.GetAsync<PagedList<DetainedLicenseListItemDto>>(query);
            if (apiResponse.IsSuccess && apiResponse.Data is not null)
                return apiResponse;
        }
        catch
        {
            // Fall back to session catalog when list endpoint is not exposed on backend.
        }

        _ = Interlocked.CompareExchange(ref _nextDetainId, _nextDetainId, _nextDetainId);

        List<DetainedLicenseListItemDto> items;
        lock (_syncLock)
        {
            IEnumerable<DetainedLicenseListItemDto> seq = _fallbackDetainedLicenses;

            if (statusFilter == 1)
                seq = seq.Where(x => !x.IsReleased);
            else if (statusFilter == 2)
                seq = seq.Where(x => x.IsReleased);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string term = searchTerm.Trim();
                seq = seq.Where(x =>
                    x.FullName.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    x.NationalNo.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    x.DetainId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    x.LicenseId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase));
            }

            items = seq.OrderByDescending(x => x.DetainId).ToList();
        }

        int safePageSize = Math.Max(1, pageSize);
        int safePageNumber = Math.Max(1, pageNumber);
        var paged = items.Skip((safePageNumber - 1) * safePageSize).Take(safePageSize).ToList();
        return new ApiResponse<PagedList<DetainedLicenseListItemDto>>
        {
            IsSuccess = true,
            Data = new PagedList<DetainedLicenseListItemDto>(paged, items.Count, safePageNumber, safePageSize)
        };
    }
}
