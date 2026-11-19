using DVLD.Domain.Common;

namespace DVLD.Application.Abstractions
{
    public interface IValidate<T> where T : class
    {
        Result Validate(T request);
    }
}
