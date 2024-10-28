namespace CsExpressionParser
{
    /// <summary>
    /// The plus unary operator. This changes the sign to its argument
    /// </summary>
    public class RealUnaryMinusOperator : RealUnaryOperator
    {
        /// <summary>
        /// The precedence
        /// </summary>
        public override OperatorPrecedence OperatorPrecedence { get => OperatorPrecedence.HIGHER; }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RealUnaryMinusOperator() : base("-", UnaryOperatorType.Minus, OperatorAssociativity.RIGHT) { }

        /// <inheritdoc/>
        public override double Evaluate(double value)
        {
            return -value;
        }
    }
}
