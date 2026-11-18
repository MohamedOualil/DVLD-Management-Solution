#nullable enable
using DVLD.Contracts.Common;
using DVLD.WinForms.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Administration
{
    public class AdministrationService : IAdministrationService
    {
        private readonly IApiClient _apiClient;
        private readonly AppSession _session;
        private static int _nextSessionLogId = 1001;

        private static readonly List<ServiceFeeItemDto> _fallbackFees =
        [
            new ServiceFeeItemDto
            {
                Id = 1,
                Category = FeeCategory.ApplicationService,
                Title = "New Local Driving License Service",
                Description = "Initial application processing fee for a local driving license class.",
                Fees = 15.00m
            },
            new ServiceFeeItemDto
            {
                Id = 2,
                Category = FeeCategory.ApplicationService,
                Title = "Renew Driving License Service",
                Description = "Administrative fee for renewing an expired local driving license.",
                Fees = 7.00m
            },
            new ServiceFeeItemDto
            {
                Id = 3,
                Category = FeeCategory.ApplicationService,
                Title = "Replacement for a Lost Driving License",
                Description = "Issuing a duplicate credential after a reported loss.",
                Fees = 10.00m
            },
            new ServiceFeeItemDto
            {
                Id = 4,
                Category = FeeCategory.ApplicationService,
                Title = "Replacement for a Damaged Driving License",
                Description = "Reprinting an unreadable or physically damaged license card.",
                Fees = 5.00m
            },
            new ServiceFeeItemDto
            {
                Id = 5,
                Category = FeeCategory.ApplicationService,
                Title = "Release Detained Driving License",
                Description = "Clearance application fee required when releasing a detained license.",
                Fees = 15.00m
            },
            new ServiceFeeItemDto
            {
                Id = 6,
                Category = FeeCategory.ApplicationService,
                Title = "New International License",
                Description = "Issuance of a 1-year international driving permit linked to an active Class 3 license.",
                Fees = 50.00m
            },
            new ServiceFeeItemDto
            {
                Id = 7,
                Category = FeeCategory.ApplicationService,
                Title = "Retake Test",
                Description = "Additional service fee charged when rescheduling a previously failed examination.",
                Fees = 5.00m
            },
            new ServiceFeeItemDto
            {
                Id = 1,
                Category = FeeCategory.TestExam,
                Title = "Vision Test",
                Description = "Assesses applicant visual acuity to confirm medical fitness to drive safely.",
                Fees = 10.00m
            },
            new ServiceFeeItemDto
            {
                Id = 2,
                Category = FeeCategory.TestExam,
                Title = "Written (Theory) Test",
                Description = "Evaluates traffic signs, right-of-way rules, and road safety regulations.",
                Fees = 20.00m
            },
            new ServiceFeeItemDto
            {
                Id = 3,
                Category = FeeCategory.TestExam,
                Title = "Practical (Street) Test",
                Description = "On-road driving assessment under live traffic conditions with an examiner.",
                Fees = 30.00m
            }
        ];

        private static readonly List<AuditLogItemDto> _sessionAuditTrail = [];
        private static readonly object _syncLock = new();

        public AdministrationService(IApiClient apiClient, AppSession session)
        {
            _apiClient = apiClient;
            _session = session;
        }

        public async Task<ApiResponse<FeeCatalogResult>> GetAllFeeTypesAsync()
        {
            try
            {
                var appTypesTask = _apiClient.GetAsync<List<ServiceFeeItemDto>>("ApplicationTypes");
                var testTypesTask = _apiClient.GetAsync<List<ServiceFeeItemDto>>("TestTypes");

                await Task.WhenAll(appTypesTask, testTypesTask);

                var appResult = await appTypesTask;
                var testResult = await testTypesTask;

                if (appResult.IsSuccess && appResult.Data is not null &&
                    testResult.IsSuccess && testResult.Data is not null)
                {
                    foreach (var item in appResult.Data)
                        item.Category = FeeCategory.ApplicationService;
                    foreach (var item in testResult.Data)
                        item.Category = FeeCategory.TestExam;

                    var combined = appResult.Data.Concat(testResult.Data).ToList();
                    return new ApiResponse<FeeCatalogResult>
                    {
                        IsSuccess = true,
                        Data = new FeeCatalogResult
                        {
                            Items = combined,
                            IsFromLiveApi = true
                        }
                    };
                }
            }
            catch
            {
                // Backend endpoints not exposed yet; fall back cleanly to local DVLD catalog.
            }

            List<ServiceFeeItemDto> snapshot;
            lock (_syncLock)
            {
                snapshot = _fallbackFees
                    .Select(x => new ServiceFeeItemDto
                    {
                        Id = x.Id,
                        Category = x.Category,
                        Title = x.Title,
                        Description = x.Description,
                        Fees = x.Fees
                    })
                    .ToList();
            }

            return new ApiResponse<FeeCatalogResult>
            {
                IsSuccess = true,
                Data = new FeeCatalogResult
                {
                    Items = snapshot,
                    IsFromLiveApi = false
                }
            };
        }

        public async Task<ApiResponse<ServiceFeeItemDto>> UpdateFeeTypeAsync(
            int id,
            FeeCategory category,
            UpdateServiceFeeRequest request)
        {
            string endpoint = category == FeeCategory.ApplicationService
                ? $"ApplicationTypes/{id}"
                : $"TestTypes/{id}";

            try
            {
                var apiResponse = await _apiClient.PutAsync<ServiceFeeItemDto>(endpoint, request);
                if (apiResponse.IsSuccess && apiResponse.Data is not null)
                {
                    apiResponse.Data.Category = category;
                    RecordSessionActivity(
                        "Update Fee",
                        $"{category}: {request.Title}",
                        "Success",
                        $"Updated fee to {request.Fees:C2} via API");
                    return apiResponse;
                }
            }
            catch
            {
                // Fall back to session fee schedule if backend endpoint is unavailable.
            }

            ServiceFeeItemDto? updated = null;
            lock (_syncLock)
            {
                var target = _fallbackFees.FirstOrDefault(x => x.Id == id && x.Category == category);
                if (target is not null)
                {
                    target.Title = request.Title.Trim();
                    target.Description = request.Description.Trim();
                    target.Fees = request.Fees;
                    updated = new ServiceFeeItemDto
                    {
                        Id = target.Id,
                        Category = target.Category,
                        Title = target.Title,
                        Description = target.Description,
                        Fees = target.Fees
                    };
                }
            }

            if (updated is null)
            {
                return new ApiResponse<ServiceFeeItemDto>
                {
                    IsSuccess = false,
                    Errors = { $"Fee entry #{id} ({category}) was not found." }
                };
            }

            RecordSessionActivity(
                "Update Fee",
                $"{updated.CodeLabel} ({updated.Title})",
                "Warning",
                $"Updated fee to {updated.Fees:C2} in local catalog (backend endpoint not active)");

            return new ApiResponse<ServiceFeeItemDto>
            {
                IsSuccess = true,
                Data = updated
            };
        }

        public async Task<ApiResponse<AuditLogsResult>> GetAuditLogsAsync(
            int pageNumber,
            int pageSize,
            string? searchTerm,
            string? statusFilter)
        {
            string query = $"AuditLogs?pageNumber={pageNumber}&pageSize={pageSize}";
            if (!string.IsNullOrWhiteSpace(searchTerm))
                query += $"&search={Uri.EscapeDataString(searchTerm.Trim())}";
            if (!string.IsNullOrWhiteSpace(statusFilter) && !statusFilter.Equals("All", StringComparison.OrdinalIgnoreCase))
                query += $"&status={Uri.EscapeDataString(statusFilter.Trim())}";

            try
            {
                var apiResult = await _apiClient.GetAsync<PagedList<AuditLogItemDto>>(query);
                if (apiResult.IsSuccess && apiResult.Data is not null)
                {
                    return new ApiResponse<AuditLogsResult>
                    {
                        IsSuccess = true,
                        Data = new AuditLogsResult
                        {
                            Page = apiResult.Data,
                            IsFromLiveApi = true
                        }
                    };
                }
            }
            catch
            {
                // Backend AuditLogs endpoint not exposed yet; serve session telemetry below.
            }

            EnsureBaselineSessionLogs();

            List<AuditLogItemDto> filtered;
            lock (_syncLock)
            {
                IEnumerable<AuditLogItemDto> seq = _sessionAuditTrail
                    .OrderByDescending(l => l.Timestamp)
                    .ThenByDescending(l => l.LogId);

                if (!string.IsNullOrWhiteSpace(statusFilter) &&
                    !statusFilter.Equals("All", StringComparison.OrdinalIgnoreCase))
                {
                    seq = seq.Where(l => l.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    string term = searchTerm.Trim();
                    seq = seq.Where(l =>
                        l.Username.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                        l.Operation.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                        l.TargetEntity.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                        l.Details.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                        l.LogId.ToString().Contains(term, StringComparison.OrdinalIgnoreCase));
                }

                filtered = seq.ToList();
            }

            int safePageSize = Math.Max(1, pageSize);
            int totalCount = filtered.Count;
            int safePageNumber = Math.Max(1, pageNumber);
            var pageItems = filtered
                .Skip((safePageNumber - 1) * safePageSize)
                .Take(safePageSize)
                .ToList();

            return new ApiResponse<AuditLogsResult>
            {
                IsSuccess = true,
                Data = new AuditLogsResult
                {
                    Page = new PagedList<AuditLogItemDto>(pageItems, totalCount, safePageNumber, safePageSize),
                    IsFromLiveApi = false
                }
            };
        }

        public void RecordSessionActivity(string operation, string targetEntity, string status, string details = "")
        {
            string username = string.IsNullOrWhiteSpace(_session.Username) ? "System" : _session.Username;
            string role = _session.IsAdmin ? "Admin" : _session.Role.ToString();

            lock (_syncLock)
            {
                int id = Interlocked.Increment(ref _nextSessionLogId);
                _sessionAuditTrail.Add(new AuditLogItemDto
                {
                    LogId = id,
                    Timestamp = DateTime.Now,
                    Username = username,
                    Role = role,
                    Operation = operation,
                    TargetEntity = targetEntity,
                    Status = status,
                    Details = details
                });
            }
        }

        private void EnsureBaselineSessionLogs()
        {
            lock (_syncLock)
            {
                if (_sessionAuditTrail.Count > 0)
                    return;

                string username = string.IsNullOrWhiteSpace(_session.Username) ? "System" : _session.Username;
                string role = _session.IsAdmin ? "Admin" : _session.Role.ToString();

                _sessionAuditTrail.Add(new AuditLogItemDto
                {
                    LogId = Interlocked.Increment(ref _nextSessionLogId),
                    Timestamp = DateTime.Now.AddMinutes(-1),
                    Username = username,
                    Role = role,
                    Operation = "Session Started",
                    TargetEntity = "DVLD Admin Shell",
                    Status = "Success",
                    Details = "Authenticated operator session initialized."
                });
            }
        }
    }
}
