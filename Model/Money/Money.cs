using System;

namespace TwinField.Sales.Model
{
    public struct Money
    {
        private readonly int amount;
        private readonly Currency currency;

        public Money(int amount, Currency currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public int Amount => this.amount;

        public Currency Currency => this.currency;

        public static Money operator +(Money x, Money y)
        {
            if (x.currency == y.currency)
                return new Money(x.Amount + y.Amount, x.Currency);
            else
                throw new InvalidOperationException("Currencies of arguments are not equal");
        }

        public static Money operator *(Money x, int multiplier)
        {
            return new Money(x.Amount * multiplier, x.Currency);
        }

        public static Money operator *(int multiplier, Money x)
        {
            return x * multiplier;
        }

        //public override string ToString()
        //{
        //    var result = (double)this.amount / 100;
        //    return $"{result} {this.currency}";
        //}
    }
}
