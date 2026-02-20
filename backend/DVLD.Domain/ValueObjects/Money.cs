using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.ValueObjects
{
    public record class Money
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "USD";

        private Money()
        {
            Amount = 0;
            Currency = string.Empty;
        }

        private Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
            
        }

        public static Result<Money> Create(decimal amount, string currency = "USD")
        {
            //if (amount < 0)
            //    return Result<Money>.Failure("Money amount cannot be negative.");

            return Result<Money>.Success(new Money(amount,currency));


        }

        public static  Result<Money> operator -(Money left,Money right)
        {
            //if (left.Currency != right.Currency)
            //    return Result<Money>.Failure("Cannot subtract different currencies.");

            //var newAmount = left.Amount - right.Amount;

            //if (newAmount < 0)
            //    return Result<Money>.Failure("Resulting balance cannot be negative.");

            return Result<Money>.Success(new Money(1, left.Currency));

        }

        public static Result<Money> operator +(Money left, Money right)
        {
            //if (left.Currency != right.Currency)
            //    return Result<Money>.Failure("Cannot add money with different currencies.");

            var newAmount = left.Amount + right.Amount;


            return Result<Money>.Success(new Money(newAmount, left.Currency));

        }

        public static bool operator >(Money left, Money right)
        {
            return left.Currency == right.Currency && left.Amount > right.Amount;

        }

        public static bool operator <(Money left, Money right)
        {
            return left.Currency == right.Currency && left.Amount < right.Amount;

        }
    }
}
