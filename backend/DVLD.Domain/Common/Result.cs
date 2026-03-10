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
        private List<Error> _errors = new List<Error>();
        public IReadOnlyList<Error> Errors => _errors;

        protected Result(bool success ,IReadOnlyList<Error> validationErrors)
        {
            this.IsSuccess = success;

            if (validationErrors != null)
                _errors.AddRange(validationErrors);

        }

        protected Result(bool success, Error error)
        {
            if (error != null || error != Common.Error.None)
                _errors.Add(error);

            this.IsSuccess = success;
        }


        public static Result Success()
        {
            return new Result(true, Common.Error.None);
        }

        public static Result Failure(Error error)
        {
            
            return new Result(false,error);

        }

        public static Result Failure(IReadOnlyList<Error> errors)
        {
            return new Result(false, errors);
        }


    }

    public sealed class Result<TValue> : Result
    {

        public TValue? Value { get; }


        private Result(TValue? data, bool success,IReadOnlyList<Error> errors )
            : base(success,errors)
        {

            this.Value = data;


        }

        private Result(TValue? data, Error error, bool success)
           : base(success, error)
        {

            this.Value = data;


        }

        public new static Result<TValue> Success(TValue data)
        {
            return new Result<TValue>(data, Common.Error.None,true);
        }

        public new static Result<TValue> Failure(Error error)
        {
            
            return new Result<TValue>(default, error, false);

        }

        public new static Result<TValue> Failure(IReadOnlyList<Error> errors)
        {
            return new Result<TValue>(default, false,errors);

        }


    }
}
