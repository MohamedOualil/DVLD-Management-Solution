using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.Common
{
    
    public class Result
    {
        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;
        public Error Error { get; }
        public IReadOnlyList<Error> Errors { get; }



        protected Result(bool success ,Error error,IReadOnlyList<Error> validationErrors = null)
        {
            this.Error = error;
            this.IsSuccess = success;
            this.Errors = validationErrors ?? [];

        }

        public static Result Success()
        {
            return new Result(true,Error.None);
        }

        public static Result Failure(Error error)
        {
            return new Result(false,error);

        }

        public static Result Failure(IReadOnlyList<Error> errors)
        {
            return new Result(false, errors.FirstOrDefault() ?? Error.None, errors);
        }


    }

    public sealed class Result<TValue> : Result
    {

        public TValue? Value { get; }


        private Result(TValue? data, Error error, bool success,IReadOnlyList<Error> errors = null)
            : base(success,error,errors)
        {

            this.Value = data;


        }

        public new static Result<TValue> Success(TValue data)
        {
            return new Result<TValue>(data, Error.None,true);
        }

        public new static Result<TValue> Failure(Error error)
        {
            return new Result<TValue>(default, error, false);

        }

        public new static Result<TValue> Failure(IReadOnlyList<Error> errors)
        {
            return new Result<TValue>(default, errors.FirstOrDefault() ?? Error.None, false,errors);

        }


    }
}
