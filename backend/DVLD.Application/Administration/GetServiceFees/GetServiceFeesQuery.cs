using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.Administration;
using DVLD.Contracts.Enums;

namespace DVLD.Application.Administration.GetServiceFees
{
    public sealed record GetServiceFeesQuery(FeeCategory? Category = null)
        : IQuery<List<ServiceFeeItemDto>>;
}
