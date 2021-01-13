using System;
using System.Collections.Generic;
using System.Linq;

namespace TwinField.Sales.Model
{
    public static class MoneyLinqExtensions
    {
        public static Money Sum<Source>(this IEnumerable<Source> source, Func<Source, Money> selector)
        {
            if (source.Select(x => selector(x).Currency).Distinct().Count() > 1)
                throw new IncompartibleCurrencyException();

            Money sum = new Money(0, selector(source.FirstOrDefault()).Currency);
            foreach (var x in source)
                sum += selector(x);

            return sum;
        }
    }
}
