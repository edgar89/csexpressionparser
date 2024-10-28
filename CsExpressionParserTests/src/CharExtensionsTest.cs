using CsExpressionParser;

namespace CsExpressionParserTests
{
    [TestClass]
    public class CharExtensionsTest
    {
        [TestMethod]
        public void ShouldFindExponent()
        {
            Assert.IsTrue('e'.IsExponent());
            Assert.IsTrue('E'.IsExponent());
            Assert.IsFalse('g'.IsExponent());
        }

        [TestMethod]
        public void ShouldFindDecimalSeparator()
        {
            Assert.IsTrue('.'.IsDecimalSeparator(System.Globalization.CultureInfo.InvariantCulture));
            Assert.IsFalse('g'.IsDecimalSeparator(System.Globalization.CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void ShouldFindOperator()
        {
            Assert.IsTrue('+'.IsOperator());
            Assert.IsTrue('*'.IsOperator());
            Assert.IsFalse('g'.IsOperator());
        }
    }
}