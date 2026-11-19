using DVLD.Application.Abstractions.Messaging;
using DVLD.Contracts.LocalLicenseApplications;

namespace DVLD.Application.LocalLicenseApplications.GetLocalApplicationDetailScreen
{
    public sealed record GetLocalApplicationDetailScreenQuery(int LocalApplicationId)
        : IQuery<LocalApplicationDetailScreenResponse>;
}
