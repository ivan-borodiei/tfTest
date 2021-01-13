using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinField.Sales.Model.Exceptions
{
    public class NonUniqueGoodsItemException: ApplicationException
    {
        public NonUniqueGoodsItemException(string message, Exception innerException) : base(message, innerException) { }
    }
}
