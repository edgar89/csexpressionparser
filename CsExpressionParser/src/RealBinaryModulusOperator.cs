namespace CsExpressionParser
{
    /// <summary>
    /// The modulus binary operator. This extract the remainder of left divided by right
    /// </summary>
    public class RealBinaryModulusOperator : RealBinaryOperator
    {
        /// <inheritdoc/>
        public override OperatorPrecedence OperatorPrecedence { get => OperatorPrecedence.HIGH; }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RealBinaryModulusOperator() : base("%", BinaryOperatorType.Modulus, OperatorAssociativity.LEFT) { }

        /// <inheritdoc/>
        public override double Evaluate(double left, double right)
        {
            if (right == 0d)
                throw new ArithmeticException("Cannot divide by 0!");
            return (int)left % (int)right;
        }
    }
}
