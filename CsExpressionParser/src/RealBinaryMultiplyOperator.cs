namespace CsExpressionParser
{
    /// <summary>
    /// The multiply binary operator. This multiplies the arguments
    /// </summary>
    public class RealBinaryMultiplyOperator : RealBinaryOperator
    {
        /// <inheritdoc/>
        public override OperatorPrecedence OperatorPrecedence { get => OperatorPrecedence.HIGH; }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RealBinaryMultiplyOperator() : base("*", BinaryOperatorType.Multiply, OperatorAssociativity.LEFT) { }

        /// <inheritdoc/>
        public override double Evaluate(double left, double right)
        {
            return left * right;
        }
    }
}
