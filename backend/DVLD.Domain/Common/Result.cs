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
        public string MessageError { get; }



        protected Result(bool success ,string messageError)
        {
            this.MessageError = messageError;
            this.IsSuccess = success;

        }

        public static Result Success()
        {
            return new Result(true,string.Empty);
        }

        public static Result Failure(string messageError)
        {
            return new Result(false,messageError);

        }


    }

    public class Result<T> : Result
    {

        public T? Data { get; }


        private Result(T? data, string messageError, bool success)
            : base(success,messageError)
        {

            this.Data = data;

        }

        public new static Result<T> Success(T data)
        {
            return new Result<T>(data, string.Empty,true);
        }

        public new static Result<T> Failure(string messageError)
        {
            return new Result<T>(default, messageError, false);

        }


    }
}
