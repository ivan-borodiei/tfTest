using System.Collections.Generic;
using System.Linq;

namespace TwinField.Sales.Model
{
    public interface ICalculator
    {
        Money CalculateTotal(IEnumerable<GoodsItem> items);
    }

    public class DefaultCalculator : ICalculator
    {
        public Money CalculateTotal(IEnumerable<GoodsItem> items)
        {
            return items
                .GroupBy(i => i, (k, l) => new { GoodsItem = k, Count = l.Count() })
                .Select(g => new { GoodsItem = g.GoodsItem, Sum = this.CalcTotalByItem(g.GoodsItem, g.Count) })
                .Sum(i => i.Sum);
        }

        private Money CalcTotalByItem(GoodsItem item, int count)
        {
            var policy = item.PricePolicy;
            var maxDiscountVolume = policy.GetMaxDiscountVolume();
            if (count >= maxDiscountVolume)
                return policy.GetPricePer(maxDiscountVolume) + (count - maxDiscountVolume) * policy.GetPricePer(1);
            else
                return count * policy.GetPricePer(1);
        }
    }
}
