using CsExpressionParser;
using System.Globalization;

namespace CsExpressionParserTests
{
    [TestClass]
    public class TokensTest
    {
        private sealed class DummyToken : Token
        {
            public DummyToken() : base("\0")
            {
            }
        }

        private sealed class DummyFunction : Function<double>
        {
            public override int Arity => 0;

            public DummyFunction() : base("x")
            {

            }

            public override double EvaluateFunction(IDictionary<string, double> variables, IList<double> arguments)
            {
                return 0d;
            }
        }

        private sealed class DummyLiteral : Literal<double>
        {
            public DummyLiteral() : base("0", 0d)
            {

            }
        }

        private sealed class DummyOperator1 : Operator
        {
            public DummyOperator1() : base("$", OperatorType.Unary, OperatorAssociativity.RIGHT) { }

        }

        private sealed class DummyOperator2 : Operator
        {
            public DummyOperator2() : base("$", OperatorType.Binary, OperatorAssociativity.LEFT)
            {

            }
        }

        private sealed class DummyUnaryOperator : UnaryOperator<double>
        {
            public DummyUnaryOperator() : base("$", UnaryOperatorType.Plus, OperatorAssociativity.RIGHT)
            {

            }
            public override double Evaluate(double value)
            {
                return 0d;
            }
        }

        private sealed class DummyBinaryOperator : BinaryOperator<double>
        {
            public DummyBinaryOperator() : base("$", BinaryOperatorType.Plus, OperatorAssociativity.LEFT)
            {

            }

            public override double Evaluate(double left, double right)
            {
                return 0d;
            }
        }

        [TestMethod]
        public void ShouldTestToken()
        {
            var dummyToken = new DummyToken();
            Assert.IsFalse(dummyToken.IsIdentifier);
            Assert.IsFalse(dummyToken.IsLiteral);
            Assert.IsFalse(dummyToken.IsOperator);
            Assert.IsFalse(dummyToken.IsSymbol);

            dummyToken.GetHashCode();
            Assert.AreEqual(dummyToken, new DummyToken());
            Assert.AreNotEqual(null, dummyToken);
        }

        [TestMethod]
        public void ShouldTestIdentifier()
        {
            const string x = "x";
            const double value = 1;
            var ids = new Dictionary<string, double> { { x, value } };
            var empty = new Dictionary<string, double>();
            var identifier = new Identifier<double>("x");
            Assert.IsFalse(identifier.IsLiteral);
            Assert.IsFalse(identifier.IsOperator);
            Assert.IsFalse(identifier.IsSymbol);
            Assert.IsTrue(identifier.IsIdentifier);
            Assert.IsFalse(identifier.IsFunction);
            Assert.AreEqual(value, identifier.Evaluate(ids));
            Assert.ThrowsException<InvalidOperationException>(() => identifier.Evaluate(empty));
        }

        [TestMethod]
        public void ShouldTestFunction()
        {
            var dummyFunction = new DummyFunction();
            Assert.IsFalse(dummyFunction.IsLiteral);
            Assert.IsFalse(dummyFunction.IsOperator);
            Assert.IsFalse(dummyFunction.IsSymbol);
            Assert.IsTrue(dummyFunction.IsIdentifier);
            Assert.IsTrue(dummyFunction.IsFunction);
            Assert.AreEqual(0, dummyFunction.Evaluate(new Dictionary<string, double>()));

            _ = dummyFunction.Arity;

            dummyFunction.GetHashCode();
            Assert.AreEqual(dummyFunction, new DummyFunction());
            Assert.AreNotEqual(null, dummyFunction);
        }

        [TestMethod]
        public void ShouldTestRealFunction()
        {
            var map = new Dictionary<string, double>();

            var realFunction = new RealFunction("sin");
            Assert.AreEqual(0, realFunction.EvaluateFunction(map, [0]));

            var list = new List<double> { 0 };
            var realFunction2 = new RealFunction("xxx");
            Assert.ThrowsException<KeyNotFoundException>(() => realFunction2.EvaluateFunction(map, list));

            var list2 = new List<double> { 0, 1 };
            Assert.ThrowsException<ArgumentException>(() => realFunction.EvaluateFunction(map, list2));

            Assert.ThrowsException<ArgumentException>(() => realFunction.EvaluateFunction(map, null));
        }

        [TestMethod]
        public void ShouldTestLiteral()
        {
            var dummyLiteral = new DummyLiteral();
            Assert.IsTrue(dummyLiteral.IsLiteral);
            Assert.IsFalse(dummyLiteral.IsOperator);
            Assert.IsFalse(dummyLiteral.IsSymbol);
            Assert.IsFalse(dummyLiteral.IsIdentifier);
            Assert.AreEqual(0, dummyLiteral.Value);

            dummyLiteral.GetHashCode();
            Assert.AreEqual(dummyLiteral, dummyLiteral); // NOSONAR
            Assert.AreNotEqual(null, dummyLiteral); // NOSONAR
        }

        [TestMethod]
        public void ShouldTestRealLiteral()
        {
            var realLiteral = new RealLiteral(0);
            Assert.IsTrue(realLiteral.IsLiteral);
            Assert.IsFalse(realLiteral.IsOperator);
            Assert.IsFalse(realLiteral.IsSymbol);
            Assert.IsFalse(realLiteral.IsIdentifier);
            Assert.AreEqual(0, realLiteral.Value);

            _ = new RealLiteral(0, CultureInfo.InvariantCulture);
            _ = new RealLiteral(0, "0");
            _ = new RealLiteral(0, "0", CultureInfo.InvariantCulture);

            RealLiteral.Parse("0");
            RealLiteral.Parse("0", CultureInfo.InvariantCulture);
            RealLiteral.Parse("0", NumberStyles.Integer);
            RealLiteral.Parse("0", NumberStyles.Integer, CultureInfo.InvariantCulture);
            RealLiteral.Parse(new Span<char>(['0']));
        }

        [TestMethod]
        public void ShouldTestSymbol()
        {
            Symbol s1 = new Comma();
            Symbol s2 = new(";");
            Symbol s3 = new OpenParenthesis();
            Symbol s4 = new ClosedParenthesis();

            Assert.IsTrue(s1.IsSymbol);
            Assert.IsTrue(s1.IsComma);
            Assert.IsFalse(s1.IsSemicolon);
            Assert.IsTrue(s1.IsSeparator);
            Assert.IsFalse(s1.IsParenthesis);
            Assert.IsFalse(s1.IsOpenParenthesis);
            Assert.IsFalse(s1.IsClosedParenthesis);

            Assert.IsTrue(s2.IsSymbol);
            Assert.IsFalse(s2.IsComma);
            Assert.IsTrue(s2.IsSemicolon);
            Assert.IsTrue(s2.IsSeparator);
            Assert.IsFalse(s2.IsParenthesis);
            Assert.IsFalse(s2.IsOpenParenthesis);
            Assert.IsFalse(s2.IsClosedParenthesis);

            Assert.IsTrue(s3.IsSymbol);
            Assert.IsFalse(s3.IsComma);
            Assert.IsFalse(s3.IsSemicolon);
            Assert.IsFalse(s3.IsSeparator);
            Assert.IsTrue(s3.IsParenthesis);
            Assert.IsTrue(s3.IsOpenParenthesis);
            Assert.IsFalse(s3.IsClosedParenthesis);

            Assert.IsTrue(s4.IsSymbol);
            Assert.IsFalse(s3.IsComma);
            Assert.IsFalse(s3.IsSemicolon);
            Assert.IsFalse(s3.IsSeparator);
            Assert.IsTrue(s4.IsParenthesis);
            Assert.IsFalse(s4.IsOpenParenthesis);
            Assert.IsTrue(s4.IsClosedParenthesis);
        }

        [TestMethod]
        public void ShouldTestOperator()
        {
            DummyOperator1 d1 = new();
            DummyOperator2 d2 = new();

            Assert.IsFalse(d1.IsLiteral);
            Assert.IsTrue(d1.IsOperator);
            Assert.IsFalse(d1.IsSymbol);
            Assert.IsFalse(d1.IsIdentifier);

            Assert.IsFalse(d2.IsLiteral);
            Assert.IsTrue(d2.IsOperator);
            Assert.IsFalse(d2.IsSymbol);
            Assert.IsFalse(d2.IsIdentifier);

            _ = d1.OperatorType;
            _ = d1.Associativity;
            _ = d1.OperatorPrecedence;
            d1.GetHashCode();
            Assert.IsTrue(d1.IsUnaryOperator);
            Assert.IsFalse(d1.IsBinaryOperator);

            _ = d2.OperatorType;
            _ = d2.Associativity;
            _ = d2.OperatorPrecedence;
            d2.GetHashCode();
            Assert.IsFalse(d2.IsUnaryOperator);
            Assert.IsTrue(d2.IsBinaryOperator);

            Assert.AreEqual(d1, d1); // NOSONAR
            Assert.AreNotEqual(null, d2); // NOSONAR
        }

        [TestMethod]
        public void ShouldTestUnaryOperator()
        {
            DummyUnaryOperator d1 = new();

            Assert.IsFalse(d1.IsLiteral);
            Assert.IsTrue(d1.IsOperator);
            Assert.IsFalse(d1.IsSymbol);
            Assert.IsFalse(d1.IsIdentifier);

            Assert.IsTrue(d1.IsUnaryOperator);
            Assert.IsFalse(d1.IsBinaryOperator);

            d1.GetType();
            d1.GetHashCode();
            Assert.AreEqual(d1, d1); // NOSONAR
            Assert.AreNotEqual(null, d1); // NOSONAR
            Assert.AreEqual(0, d1.Evaluate(4d));
        }

        [TestMethod]
        public void ShouldTestBinaryOperator()
        {
            DummyBinaryOperator d1 = new();

            Assert.IsFalse(d1.IsLiteral);
            Assert.IsTrue(d1.IsOperator);
            Assert.IsFalse(d1.IsSymbol);
            Assert.IsFalse(d1.IsIdentifier);

            Assert.IsFalse(d1.IsUnaryOperator);
            Assert.IsTrue(d1.IsBinaryOperator);

            d1.GetType();
            d1.GetHashCode();
            Assert.AreEqual(d1, d1); // NOSONAR
            Assert.AreNotEqual(null, d1); // NOSONAR
            Assert.AreEqual(0, d1.Evaluate(4d, 6d));
        }

        [TestMethod]
        public void ShouldTestRealUnaryOperators()
        {
            RealUnaryPlusOperator up = (RealUnaryPlusOperator)RealUnaryOperator.From("+");
            RealUnaryMinusOperator um = (RealUnaryMinusOperator)RealUnaryOperator.From("-");
            Assert.ThrowsException<ArgumentException>(() => RealUnaryOperator.From("$"));

            _ = up.OperatorPrecedence;
            _ = um.OperatorPrecedence;
            Assert.AreEqual(1, up.Evaluate(1d));
            Assert.AreEqual(-1, um.Evaluate(1d));
        }

        [TestMethod]
        public void ShouldTestRealBinaryOperators() // NOSONAR: They are all similar assertions
        {
            var bpl = (RealBinaryPlusOperator)RealBinaryOperator.From("+");
            var bmi = (RealBinaryMinusOperator)RealBinaryOperator.From("-");
            var bmu = (RealBinaryMultiplyOperator)RealBinaryOperator.From("*");
            var bdv = (RealBinaryDivideOperator)RealBinaryOperator.From("/");
            var bpw = (RealBinaryPowerOperator)RealBinaryOperator.From("^");
            var bmd = (RealBinaryModulusOperator)RealBinaryOperator.From("%");
            Assert.ThrowsException<ArgumentException>(() => RealBinaryOperator.From("$"));

            _ = bpl.OperatorPrecedence;
            _ = bmi.OperatorPrecedence;
            _ = bmu.OperatorPrecedence;
            _ = bdv.OperatorPrecedence;
            _ = bpw.OperatorPrecedence;
            _ = bmd.OperatorPrecedence;

            Assert.AreEqual(3, bpl.Evaluate(1d, 2d));
            Assert.AreEqual(-1, bmi.Evaluate(1d, 2d));
            Assert.AreEqual(2, bmu.Evaluate(1d, 2d));
            Assert.AreEqual(0.5d, bdv.Evaluate(1d, 2d));
            Assert.ThrowsException<ArithmeticException>(() => bdv.Evaluate(1d, 0d));
            Assert.AreEqual(1, bpw.Evaluate(1d, 2d));
            Assert.AreEqual(1, bmd.Evaluate(5d, 2d));
            Assert.ThrowsException<ArithmeticException>(() => bmd.Evaluate(1d, 0d));
        }
    }
}