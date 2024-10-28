namespace CsExpressionParser
{
    /// <summary>
    /// The power binary operator. This raises left arg to the right arg power
    /// </summary>
    public class RealBinaryPowerOperator : RealBinaryOperator
    {
        /// <inheritdoc/>
        public override OperatorPrecedence OperatorPrecedence { get => OperatorPrecedence.HIGHEST; }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        public RealBinaryPowerOperator() : base("^", BinaryOperatorType.Power, OperatorAssociativity.RIGHT) { }

        /// <inheritdoc/>
        public override double Evaluate(double left, double right)
        {
            return Math.Pow(left, right);
        }
    }
}
