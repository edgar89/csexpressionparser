using CsExpressionParser;

namespace CsExpressionParserTests
{
    [TestClass]
    public class RealExpressionTest
    {
        private readonly string expr = "-2+x*-2.3e1+1.4564E-2+(-sin(x2)-1)";

        [TestMethod]
        public void ShouldParse()
        {
            RealExpression rx = new(expr);

            double value = -25.985436d;
            rx.SetVariableValue("x", 1);
            rx.SetVariableValue("x2", 0);
            Assert.AreEqual(value, rx.Evaluate());
        }

        [TestMethod]
        public void ShouldThrowParseExceptionWhenMultipleExponent()
        {
            RealExpression rx = new("2ee");
            Assert.ThrowsException<FormatException>(() => rx.Evaluate());
        }

    }
}