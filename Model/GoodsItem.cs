namespace TwinField.Sales.Model
{
    public class GoodsItem
    {
        internal string BarCode { get; set; }

        public string Name { get; set; }

        internal PricePolicy PricePolicy { get; set; }
    }
}
