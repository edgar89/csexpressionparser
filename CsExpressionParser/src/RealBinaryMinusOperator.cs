namespace CsExpressionParser
{
    /// <summary>
    /// The minus binary operator. This subtracts the arguments
    /// </summary>
    public class RealBinaryMinusOperator : RealBinaryOperator
    {
        /// <inheritdoc/>
        public override OperatorPrecedence OperatorPrecedence { get => OperatorPrecedence.MEDIUM; }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RealBinaryMinusOperator() : base("-", BinaryOperatorType.Minus, OperatorAssociativity.LEFT) { }

        /// <inheritdoc/>
        public override double Evaluate(double left, double right)
        {
            return left - right;
        }
    }
}
