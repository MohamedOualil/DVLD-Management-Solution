using DVLD.Contracts.Common;
using DVLD.Contracts.Persons;
using DVLD.Application.Abstractions;
using DVLD.Application.Abstractions.Interfaces;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace DVLD.Application.Persons.GetAllPerson
{
    
    internal sealed class GetAllPersonQueryHandler : IQueryHandler<GetAllPersonQuery, PagedList<GetAllPersonResponse>>
    {
        private readonly IApplicationDbContext _dbContext;

        private readonly IValidate<GetAllPersonQuery> _validator;

        public GetAllPersonQueryHandler(
            IApplicationDbContext dbContext,
            IValidate<GetAllPersonQuery> validate)
        {
            _dbContext = dbContext;

            _validator = validate;
        }
        public async Task<Result<PagedList<GetAllPersonResponse>>> Handle(
            GetAllPersonQuery request, 
            CancellationToken cancellationToken)
        {
            Result validation = _validator.Validate(request);
            if (validation.IsFailure)
                return Result<PagedList<GetAllPersonResponse>>.Failure(validation.Errors);

            var query = _dbContext.Persons.AsNoTracking();

            if (request.Gender.HasValue && request.Gender.Value > 0)
            {
                query = query.Where(p => (short)p.Gender == request.Gender.Value);
            }

            if (!string.IsNullOrWhiteSpace(request.SearchTerm))
            {
                string term = request.SearchTerm.Trim();
                int? searchId = int.TryParse(term, out int parsedId) ? parsedId : null;
                query = query.Where(p =>
                    (searchId.HasValue && p.Id == searchId.Value) ||
                    p.NationalNo.Number.Contains(term) ||
                    p.Phone.PhoneNumber.Contains(term) ||
                    (p.Email != null && p.Email.Value != null && p.Email.Value.Contains(term)) ||
                    (p.FullName.FirstName + " " + p.FullName.LastName).Contains(term));
            }

            var totalCount = await query.CountAsync(cancellationToken);

            var items = await query
                .OrderBy(p => p.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new GetAllPersonResponse
                {
                    DateOfBirth = p.DateOfBirth,

                    CountryId = p.NationalityCountryId,

                    Email = p.Email != null ? p.Email.Value : null,
                    FirstName = p.FullName.FirstName,
                    LastName = p.FullName.LastName,
                    SecondName = p.FullName.SecondName,
                    ThirdName = p.FullName.ThirdName,
                    Gender = (int)p.Gender,

                    NationalNo = p.NationalNo.Number,
                    PersonId = p.Id,
                    Phone = p.Phone.PhoneNumber,

                })
                .ToListAsync(cancellationToken);


            PagedList<GetAllPersonResponse> response = new PagedList<GetAllPersonResponse>(
                items,
                totalCount,
                request.PageNumber,
                request.PageSize);


            return Result<PagedList<GetAllPersonResponse>>.Success(response);
        }
    }
}
