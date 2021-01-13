using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TwinField.Sales.Model.Tests
{
    [TestClass]
    public class SaleTerminalTests
    {
        [TestInitialize]
        public void Init()
        {
            this.terminal = new SaleTerminal(new InMemoryRepository(), new DefaultCalculator());
        }

        private SaleTerminal terminal;

        [TestMethod]
        public void TestCase1()
        {
            var expected = new Money(1325, Currency.USD);

            terminal.BulkScan("A", "B", "C", "D", "A", "B", "A" );
            var actual = terminal.TotalAmount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCase4()
        {
            var expected = new Money(600, Currency.USD);

            terminal.BulkScan("AФ", "A", "A", "A", "A", "A");
            var actual = terminal.TotalAmount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCase2()
        {
            var expected = new Money(600, Currency.USD);

            terminal.BulkScan("C", "C", "C", "C", "C", "C", "C");
            var actual = terminal.TotalAmount;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCase3()
        {
            var expected = new Money(725, Currency.USD);

            terminal.BulkScan("A", "B", "C", "D");
            var actual = terminal.TotalAmount;

            Assert.AreEqual(expected, actual);
        }
    }

    public static class TerminalExtensions
    {
        public static void BulkScan(this SaleTerminal terminal, params string[] barCodes)
        {
            foreach (var barCode in barCodes)
                terminal.Scan(barCode);
        }
    }
}
