using System;

namespace TwinField.Sales.Model
{
    public class IncompartibleCurrencyException: ApplicationException
    {
        public IncompartibleCurrencyException() : base() { }

        public IncompartibleCurrencyException(string message) : base(message) { }
    }
}
