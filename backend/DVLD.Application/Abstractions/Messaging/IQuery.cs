using DVLD.Domain.Common;
using MediatR;

namespace DVLD.Application.Abstractions.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
