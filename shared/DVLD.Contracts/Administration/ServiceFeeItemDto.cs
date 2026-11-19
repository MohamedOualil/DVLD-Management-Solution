using DVLD.Contracts.Enums;

namespace DVLD.Contracts.Administration
{
    public sealed record ServiceFeeItemDto
    {
        public int Id { get; init; }
        public FeeCategory Category { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Fees { get; init; }

        public string CategoryLabel => Category == FeeCategory.ApplicationService ? "Service Fee" : "Exam Fee";
        public string CodeLabel => Category == FeeCategory.ApplicationService ? $"SRV-{Id:00}" : $"EXM-{Id:00}";
    }
}
