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

            var totalCount = await _dbContext.Persons.CountAsync(cancellationToken);

            var items = await _dbContext.Persons
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(p => new GetAllPersonResponse
                {
                    DateOfBirth = p.DateOfBirth,

                    CountryId = p.NationalityCountryId,

                    Email = p.Email.Value,
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
                request.PageNumber,
                request.PageSize,
                totalCount);


            return Result<PagedList<GetAllPersonResponse>>.Success(response);
        }
    }
}
