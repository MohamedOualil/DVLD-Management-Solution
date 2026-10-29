using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Licenses.GetLicense;

namespace DVLD.Application.Licenses.GetLicenseByLocalApplicationId;

public sealed record GetLicenseByLocalApplicationIdQuery(int LocalApplicationId)
    : IQuery<GetLicenseResponse>;
