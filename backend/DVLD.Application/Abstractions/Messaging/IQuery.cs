using DVLD.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Application.Abstractions.Messaging
{
    public interface IQuery<TRespoend> : IRequest<Result<TRespoend>>
    {
    }
}
