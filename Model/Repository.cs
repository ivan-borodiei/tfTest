using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TwinField.Sales.Model
{
    public interface IRepository
    {
        IEnumerable<GoodsItem> Goods { get; }
    }

    internal class InMemoryRepository : IRepository
    {
        public InMemoryRepository()
        {
            this.itemList = new List<GoodsItem>()
            {
                new GoodsItem()
                {
                    BarCode = "A",
                    PricePolicy = new PricePolicy()
                    {
                        Prices = new List<PricePerUnits>()
                        {
                            new PricePerUnits() { UnitCount = 1, Price = new Money(125, Currency.USD) },
                            new PricePerUnits() { UnitCount = 3, Price = new Money(300, Currency.USD) },
                        }.AsReadOnly()
                    }
                },
                new GoodsItem()
                {
                    BarCode = "B",
                    PricePolicy = new PricePolicy()
                    {
                        Prices = new List<PricePerUnits>() { new PricePerUnits() { UnitCount = 1, Price = new Money(425, Currency.USD) } }.AsReadOnly()
                    }
                },
                new GoodsItem()
                {
                    BarCode = "C",
                    PricePolicy = new PricePolicy()
                    {
                        Prices = new List<PricePerUnits>()
                        {
                            new PricePerUnits() { UnitCount = 1, Price = new Money(100, Currency.USD) },
                            new PricePerUnits() { UnitCount = 6, Price = new Money(500, Currency.USD) },
                        }.AsReadOnly()
                    }
                },
                new GoodsItem()
                {
                    BarCode = "D",
                    PricePolicy = new PricePolicy()
                    {
                        Prices = new List<PricePerUnits>() { new PricePerUnits() { UnitCount = 1, Price = new Money(75, Currency.USD) } }.AsReadOnly()
                    }
                },
            };

            this.goods = new ReadOnlyCollection<GoodsItem>(itemList);
        }

        private readonly IList<GoodsItem> itemList;
        private readonly IReadOnlyCollection<GoodsItem> goods;

        public IEnumerable<GoodsItem> Goods
        {
            get { return this.goods; }
        }
    }
}
