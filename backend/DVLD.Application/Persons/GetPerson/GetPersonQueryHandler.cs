using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Common;
using DVLD.Contracts.Persons;
using DVLD.Domain.Common;

namespace DVLD.Application.Persons.GetPerson
{
    internal sealed class GetPersonQueryHandler : IQueryHandler<GetPersonQuery, PersonResponse>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetPersonQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }

        public async Task<Result<PersonResponse>> Handle(
            GetPersonQuery request,
            CancellationToken cancellationToken)
        {
            if (request.personId <= 0)
                return Result<PersonResponse>.Failure(DomainErrors.erPerson.InvalidId);

            PersonResponse? person = await QueryProjectionHelpers.GetPersonResponseAsync(
                _dbContext,
                request.personId,
                cancellationToken);

            if (person is null)
                return Result<PersonResponse>.Failure(DomainErrors.erPerson.NotFound);

            return Result<PersonResponse>.Success(person);
        }
    }
}
