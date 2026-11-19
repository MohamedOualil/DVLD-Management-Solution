using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Administration.GetServiceFees;
using DVLD.Contracts.Administration;
using DVLD.Contracts.Enums;
using DVLD.Domain.Common;
using DVLD.Domain.Interfaces;
using DVLD.Domain.ValueObjects;

namespace DVLD.Application.Administration.UpdateServiceFee
{
    internal sealed class UpdateServiceFeeCommandHandler
        : ICommandHandler<UpdateServiceFeeCommand, ServiceFeeItemDto>
    {
        private readonly IApplicationTypesRepository _applicationTypesRepository;
        private readonly ITestTypesRepository _testTypesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuditService _auditService;

        public UpdateServiceFeeCommandHandler(
            IApplicationTypesRepository applicationTypesRepository,
            ITestTypesRepository testTypesRepository,
            IUnitOfWork unitOfWork,
            IAuditService auditService)
        {
            _applicationTypesRepository = applicationTypesRepository;
            _testTypesRepository = testTypesRepository;
            _unitOfWork = unitOfWork;
            _auditService = auditService;
        }

        public async Task<Result<ServiceFeeItemDto>> Handle(
            UpdateServiceFeeCommand request,
            CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                return Result<ServiceFeeItemDto>.Failure(DomainErrors.erApplicationTypes.InvalidId);

            if (!Enum.IsDefined(request.Category))
                return Result<ServiceFeeItemDto>.Failure(DomainErrors.erApplicationTypes.InvalidId);

            if (string.IsNullOrWhiteSpace(request.Title))
                return Result<ServiceFeeItemDto>.Failure(DomainErrors.erApplicationTypes.ApplicationTypeNameRequired);

            string trimmedTitle = request.Title.Trim();
            if (trimmedTitle.Length > 100 ||
                (!string.IsNullOrWhiteSpace(request.Description) && request.Description.Trim().Length > 500))
            {
                return Result<ServiceFeeItemDto>.Failure(DomainErrors.erPerson.FieldTooLong);
            }

            var moneyResult = Money.Create(request.Fees);
            if (moneyResult.IsFailure)
                return Result<ServiceFeeItemDto>.Failure(moneyResult.Errors);

            if (request.Category == FeeCategory.ApplicationService)
            {
                var appType = await _applicationTypesRepository.GetByIdAsync(request.Id, cancellationToken);
                if (appType is null)
                    return Result<ServiceFeeItemDto>.Failure(DomainErrors.erApplicationTypes.NotFound);

                var oldValues = new
                {
                    Title = appType.ApplicationTypeTitle,
                    Fees = appType.ApplicationFees.Amount
                };

                appType.Update(trimmedTitle, moneyResult.Value!);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                await _auditService.LogActionAsync(
                    action: "UpdateServiceFee",
                    entityName: "ApplicationType",
                    entityId: appType.Id.ToString(),
                    oldValues: oldValues,
                    newValues: new
                    {
                        Title = appType.ApplicationTypeTitle,
                        Fees = appType.ApplicationFees.Amount
                    },
                    isSuccess: true);

                return Result<ServiceFeeItemDto>.Success(new ServiceFeeItemDto
                {
                    Id = appType.Id,
                    Category = FeeCategory.ApplicationService,
                    Title = appType.ApplicationTypeTitle,
                    Description = GetServiceFeesQueryHandler.GetApplicationServiceDescription(appType.Id),
                    Fees = appType.ApplicationFees.Amount
                });
            }

            var testType = await _testTypesRepository.GetByIdAsync(request.Id, cancellationToken);
            if (testType is null)
                return Result<ServiceFeeItemDto>.Failure(DomainErrors.erTestTypes.NotFound);

            var oldTestValues = new
            {
                Title = testType.TestTypeTitle,
                Description = testType.TestTypeDescrption,
                Fees = testType.TestFees.Amount
            };

            testType.Update(trimmedTitle, request.Description, moneyResult.Value!);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            await _auditService.LogActionAsync(
                action: "UpdateServiceFee",
                entityName: "TestType",
                entityId: testType.Id.ToString(),
                oldValues: oldTestValues,
                newValues: new
                {
                    Title = testType.TestTypeTitle,
                    Description = testType.TestTypeDescrption,
                    Fees = testType.TestFees.Amount
                },
                isSuccess: true);

            return Result<ServiceFeeItemDto>.Success(new ServiceFeeItemDto
            {
                Id = testType.Id,
                Category = FeeCategory.TestExam,
                Title = testType.TestTypeTitle,
                Description = testType.TestTypeDescrption,
                Fees = testType.TestFees.Amount
            });
        }
    }
}
