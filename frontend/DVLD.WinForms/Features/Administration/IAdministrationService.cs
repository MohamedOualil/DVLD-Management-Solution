#nullable enable
using DVLD.Contracts.Common;
using DVLD.WinForms.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DVLD.WinForms.Features.Administration
{
    public enum FeeCategory
    {
        ApplicationService = 1,
        TestExam = 2
    }

    public sealed class ServiceFeeItemDto
    {
        public int Id { get; set; }
        public FeeCategory Category { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Fees { get; set; }

        public string CategoryLabel => Category == FeeCategory.ApplicationService ? "Service Fee" : "Exam Fee";
        public string CodeLabel => Category == FeeCategory.ApplicationService ? $"SRV-{Id:00}" : $"EXM-{Id:00}";
    }

    public sealed class UpdateServiceFeeRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Fees { get; set; }
    }

    public sealed class AuditLogItemDto
    {
        public int LogId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
        public string TargetEntity { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
    }

    public sealed class FeeCatalogResult
    {
        public List<ServiceFeeItemDto> Items { get; init; } = [];
        public bool IsFromLiveApi { get; init; }
    }

    public sealed class AuditLogsResult
    {
        public PagedList<AuditLogItemDto> Page { get; init; } = new(Array.Empty<AuditLogItemDto>(), 0, 1, 15);
        public bool IsFromLiveApi { get; init; }
    }

    public interface IAdministrationService
    {
        Task<ApiResponse<FeeCatalogResult>> GetAllFeeTypesAsync();
        Task<ApiResponse<ServiceFeeItemDto>> UpdateFeeTypeAsync(int id, FeeCategory category, UpdateServiceFeeRequest request);
        Task<ApiResponse<AuditLogsResult>> GetAuditLogsAsync(int pageNumber, int pageSize, string? searchTerm, string? statusFilter);
        void RecordSessionActivity(string operation, string targetEntity, string status, string details = "");
    }
}
