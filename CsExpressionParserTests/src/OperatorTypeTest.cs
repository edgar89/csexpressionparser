using CsExpressionParser;

namespace CsExpressionParserTests
{
    [TestClass]
    public class OperatorTypeTest
    {
        [TestMethod]
        public void ShouldSayTrue()
        {
            foreach (char c in "+-*/^%")
            {
                Assert.IsTrue(BinaryOperatorType.IsBinaryOperator(c));
            }

            foreach (char c in "+-")
            {
                Assert.IsTrue(UnaryOperatorType.IsUnaryOperator(c));
            }
        }

        [TestMethod]
        public void ShouldSayFalse()
        {
            Assert.IsFalse(BinaryOperatorType.IsBinaryOperator('g'));
            Assert.IsFalse(UnaryOperatorType.IsUnaryOperator('g'));
        }
    }
}