namespace CsExpressionParser
{
    /// <summary>
    /// The divide binary operator. This divides the arguments
    /// </summary>
    public class RealBinaryDivideOperator : RealBinaryOperator
    {
        /// <inheritdoc/>
        public override OperatorPrecedence OperatorPrecedence { get => OperatorPrecedence.MEDIUM; }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RealBinaryDivideOperator() : base("/", BinaryOperatorType.Divide, OperatorAssociativity.LEFT) { }

        /// <inheritdoc/>
        public override double Evaluate(double left, double right)
        {
            if (right == 0d)
                throw new ArithmeticException("Cannot divide by 0!");
            return left / right;
        }
    }
}
