using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Administration;
using DVLD.Contracts.Enums;

namespace DVLD.Application.Administration.UpdateServiceFee
{
    public sealed record UpdateServiceFeeCommand : ICommand<ServiceFeeItemDto>
    {
        public int Id { get; init; }
        public FeeCategory Category { get; init; }
        public string Title { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Fees { get; init; }
    }
}
