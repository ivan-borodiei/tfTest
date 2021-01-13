using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwinField.Sales.Model.Exceptions
{
    public class NonUniquePricePerUnitException: ApplicationException
    {
        public NonUniquePricePerUnitException(string message, Exception innerException) : base(message, innerException) { }
    }
}
