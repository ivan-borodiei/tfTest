using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

using TwinField.Sales.Model.Exceptions;

namespace TwinField.Sales.Model
{
    public class SaleTerminal
    {
        public SaleTerminal(IRepository repository, ICalculator calculator)
        {
            this.repository = repository;
            this.calculator = calculator;
        }

        private readonly IRepository repository;
        private readonly ICalculator calculator;

        private readonly IList<GoodsItem> cart = new List<GoodsItem>();

        public void Reset()
        {
            this.cart.Clear();
        }

        public void Scan(string barCode)
        {
            GoodsItem item;
            try
            {
                item = this.repository.Goods.SingleOrDefault(x => x.BarCode == barCode);
            }
            catch (InvalidOperationException e)
            {
                throw new NonUniqueGoodsItemException($"Conflict! There are several goods item with BarCode = {barCode} in repository", e);
            }

            this.cart.Add(item);
        }

        public void CancelLast()
        {
            this.cart.RemoveAt(cart.Count - 1);
        }

        public Money TotalAmount => this.calculator.CalculateTotal(new ReadOnlyCollection<GoodsItem>(this.cart));

        public IEnumerable<Tuple<string, int>> Cart => 
            this.cart.GroupBy(i => i, (k, l) => new Tuple<string, int>(k.Name, l.Count()));

    }
}
