namespace CsExpressionParser
{
    /// <summary>
    /// An abstract representation of a binary operator, i.e. an operator which acts on two arguments
    /// </summary>
    /// <typeparam name="T">Type of the returned value and argument</typeparam>
    /// <remarks>
    /// Creates a new instance of this class
    /// </remarks>
    /// <param name="name">Operator symbol</param>
    /// <param name="priority">Operator priority</param>
    public abstract class BinaryOperator<T>(string name, BinaryOperatorType type, OperatorAssociativity associativity) : Operator(name, OperatorType.Binary, associativity)
    {
        /// <summary>
        /// Binary operator type
        /// </summary>
        public BinaryOperatorType Type { get; protected set; } = type;

        /// <summary>
        /// Applies the operator to the given value
        /// </summary>
        /// <param name="left">Left Value</param>
        /// <param name="right">Right Value</param>
        /// <returns>The result of this operator applied to supplied values</returns>
        public abstract T Evaluate(T left, T right);
    }
}
