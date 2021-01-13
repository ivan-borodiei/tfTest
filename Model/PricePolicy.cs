using System;
using System.Collections.Generic;
using System.Linq;

using TwinField.Sales.Model.Exceptions;

namespace TwinField.Sales.Model
{
    internal class PricePolicy
    {
        public IEnumerable<PricePerUnits> Prices { get; set; }

        public Money GetPricePer(int unitCount)
        {
            PricePerUnits price;
            try
            {
                price = this.Prices.SingleOrDefault(x => x.UnitCount == unitCount);
            }
            catch(InvalidOperationException e)
            {
                throw new NonUniquePricePerUnitException($"Confllict! There are several prices per {unitCount} units", e);
            }

            if (price != default(PricePerUnits))
                return price.Price;
            else
                return unitCount * this.GetPricePer(1);
        }

        public int GetMaxDiscountVolume()
        {
            return this.Prices.Max(i => i.UnitCount);
        }
    }

    internal class PricePerUnits
    {
        public int UnitCount { get; set; }

        public Money Price { get; set; }
    }
}
