namespace CsExpressionParser
{
    /// <summary>
    /// The plus binary operator. This sums the arguments
    /// </summary>
    public class RealBinaryPlusOperator : RealBinaryOperator
    {
        /// <inheritdoc/>
        public override OperatorPrecedence OperatorPrecedence { get => OperatorPrecedence.MEDIUM; }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RealBinaryPlusOperator() : base("+", BinaryOperatorType.Plus, OperatorAssociativity.LEFT) { }

        /// <inheritdoc/>
        public override double Evaluate(double left, double right)
        {
            return left + right;
        }
    }
}
