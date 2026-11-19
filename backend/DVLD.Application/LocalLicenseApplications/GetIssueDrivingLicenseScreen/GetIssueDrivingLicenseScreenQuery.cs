using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.LocalLicenseApplications;

namespace DVLD.Application.LocalLicenseApplications.GetIssueDrivingLicenseScreen
{
    public sealed record GetIssueDrivingLicenseScreenQuery(int LocalApplicationId)
        : IQuery<IssueDrivingLicenseScreenResponse>;
}
