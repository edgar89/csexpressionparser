using CsExpressionParser.Collections;
using System.Globalization;
using System.Text;

namespace CsExpressionParser
{
    /// <summary>
    /// Represents an expression that uses and evaluates as a real number
    /// </summary>
    public class RealExpression : Expression<double>
    {
        /// <summary>
        /// Current <see cref="NumberStyles"/> to use when parsing literals. Defaults to <c>NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent</c>
        /// </summary>
        public NumberStyles Style { get; set; }
        /// <summary>
        /// <see cref="System.Globalization.CultureInfo"/> to use when parsing literals. Defaults to <c>CultureInfo.InvariantCulture</c>
        /// </summary>
        public CultureInfo CultureInfo { get; set; }

        /// <summary>
        /// Creates a new instance of this class. 
        /// The resulting instance will support evaluation of all standard 
        /// mathematical functions and the PI, TAU, E and PHI variable names.
        /// </summary>
        /// <param name="representation">String representation of the expression</param>
        public RealExpression(string expression) : base(expression)
        {
            SetVariableValue("PI", Math.PI);
            SetVariableValue("TAU", Math.Tau);
            SetVariableValue("E", Math.E);
            SetVariableValue("PHI", 0.5 * (1 + Math.Sqrt(5)));

            Style = NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowExponent;
            CultureInfo = CultureInfo.InvariantCulture;
        }

        /// <inheritdoc/>
        protected override void HandleOperator(ref int i, char c)
        {
            if (expectUnaryOperator)
                tokenList!.Add(RealUnaryOperator.From(c.ToString()));
            else
                tokenList!.Add(RealBinaryOperator.From(c.ToString()));
        }

        /// <inheritdoc/>
        protected override void HandleLiteral(ref int i, char c)
        {
            int exp = -1;
            StringBuilder sb = new();
            while (char.IsDigit(c) || c.IsExponent() || c.IsDecimalSeparator(CultureInfo) || (i - exp == 1 && c.IsOperator()))
            {
                if (exp == -1 && c.IsExponent())
                    exp = i;
                else if (c.IsExponent())
                    throw new FormatException(string.Format("Multiple exponent found at index {0}", i));

                sb.Append(c);
                c = expression[++i];
            }
            tokenList?.Add(RealLiteral.Parse(sb.ToString().ToUpperInvariant(), Style, CultureInfo));
        }

        /// <inheritdoc/>
        protected override void HandleIdentifier(ref int i, char c)
        {
            StringBuilder sb = new();
            while (char.IsLetterOrDigit(c))
            {
                sb.Append(c);
                c = expression[++i];
            }
            string id = sb.ToString();
            if (RealFunctions.Values().ContainsKey(id))
                tokenList?.Add(new RealFunction(id));
            else
                tokenList?.Add(new Identifier<double>(id));
        }

        /// <inheritdoc/>
        public override double Evaluate()
        {
            Tokenize();
            ExpressionTreeBuilder<double> builder = new ExpressionTreeBuilder<double>(this.tokenList!);
            ExpressionTree<double> tree = builder.Build();
            return tree.Evaluate(values);
        }
    }
}
