using DVLD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Domain.Common;
using DVLD.Application.Abstractions.Messaging;
using DVLD.Application.Persons.GetPerson;

namespace DVLD.Application.Persons.GetPersonByNationalNo
{
    public sealed record GetPersonByNationalNoQuery(string nationalNo) : IQuery<PersonResponse>
    {
    }
}
