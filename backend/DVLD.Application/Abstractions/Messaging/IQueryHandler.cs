using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD.Domain.Common;

namespace DVLD.Application.Abstractions.Messaging
{
    public interface IQueryHandler<TQuery,TResponed> : IRequestHandler<TQuery,Result<TResponed>> 
        where TQuery : IQuery<TResponed>
    {
    }
}
