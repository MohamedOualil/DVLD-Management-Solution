using DVLD.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD.Domain.ValueObjects
{
    public record  Money
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "USD";

        private Money()
        {
            Amount = 0;
            Currency = "USD";
        }

        private Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
            
        }

        public static Result<Money> Create(decimal amount, string currency = "USD")
        {
            if (amount < 0)
                return Result<Money>.Failure(new Error("Money.Negative", "Money amount cannot be negative."));

            if (string.IsNullOrWhiteSpace(currency))
                return Result<Money>.Failure(new Error("Money.InvalidCurrency", "Currency cannot be empty."));

            return Result<Money>.Success(new Money(amount,currency));


        }

        public static Money operator -(Money left,Money right)
        {
            if (left.Currency != right.Currency)
                throw new InvalidOperationException($"Cannot subtract {right.Currency} from {left.Currency}.");

            if (left.Amount - right.Amount < 0)
                throw new InvalidOperationException("Resulting money balance cannot be negative.");

            return new Money(left.Amount - right.Amount, left.Currency);
        }

        }

        public static Money operator +(Money left, Money right)
        {

            if (left.Currency != right.Currency)
                throw new InvalidOperationException($"Cannot add {left.Currency} to {right.Currency}.");

            return new Money(left.Amount + right.Amount, left.Currency);
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
