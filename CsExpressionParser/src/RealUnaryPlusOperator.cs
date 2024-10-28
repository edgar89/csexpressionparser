namespace CsExpressionParser
{
    /// <summary>
    /// The plus unary operator. This maintains the sign to its argument
    /// </summary>
    public class RealUnaryPlusOperator : RealUnaryOperator
    {
        /// <summary>
        /// The precedence
        /// </summary>
        public override OperatorPrecedence OperatorPrecedence { get => OperatorPrecedence.HIGHER; }
     
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RealUnaryPlusOperator() : base("+", UnaryOperatorType.Plus, OperatorAssociativity.RIGHT) { }

        /// <inheritdoc/>
        public override double Evaluate(double value)
        {
            return value;
        }
    }
}
