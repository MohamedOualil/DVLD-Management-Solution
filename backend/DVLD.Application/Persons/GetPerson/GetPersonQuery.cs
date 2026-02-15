using DVLD.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Domain.Common;
using DVLD.Application.Abstractions.Messaging;

namespace DVLD.Application.Persons.GetPerson
{
    public sealed record GetPersonQuery(int personId) : IQuery<PersonResponse>
    {
    }
}
