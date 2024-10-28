namespace CsExpressionParser
{
    /// <summary>
    /// An abstract representation of an unary operator, i.e. an operator which acts on one argument
    /// </summary>
    /// <typeparam name="T">Type of the returned value and argument</typeparam>
    /// <remarks>
    /// Creates a new instance of this class
    /// </remarks>
    /// <param name="name">Operator symbol</param>
    public abstract class UnaryOperator<T>(string name, UnaryOperatorType type, OperatorAssociativity associativity) : Operator(name, OperatorType.Unary, associativity)
    {
        /// <summary>
        /// Unary operator type
        /// </summary>
        public UnaryOperatorType Type { get; protected set; } = type;

        /// <summary>
        /// Applies the operator to the given value
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>The result of this operator applied to supplied value</returns>
        public abstract T Evaluate(T value);
    }
}
