using CsExpressionParser;

namespace CsExpressionParserTests
{
    [TestClass]
    public class RealFunctionsTest
    {
        [TestMethod]
        public void ShouldInvokeFunctions()
        {
            foreach (string key in RealFunctions.Values().Keys)
            {
                IFunctionEvaluator<double> f = RealFunctions.Values()[key];
                Assert.AreEqual(key, f.Name);
                f.Evaluate([10d]);
            }
        }
    }
}