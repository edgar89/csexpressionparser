namespace CsExpressionParser
{
    /// <summary>
    /// An abstract representation of a mathematical operator
    /// </summary>
    /// <remarks>
    /// Creates a new instance of this class
    /// </remarks>
    /// <param name="name">Operator symbol</param>
    /// <param name="operatorType">Operator type</param>
    /// <param name="associativity">Operator associativity</param>
    public abstract class Operator(string name, OperatorType operatorType, OperatorAssociativity associativity) : Token(name)
    {
        /// <summary>
        /// Type of the operator
        /// </summary>
        public OperatorType OperatorType { get; private set; } = operatorType;

        /// <inheritdoc/>
        public override OperatorAssociativity Associativity { get; protected set; } = associativity;

        /// <inheritdoc/>
        public override bool IsOperator => true;

        /// <summary>
        /// Indicates if this operator is unary, i.e. acts on one argument
        /// </summary>
        public override bool IsUnaryOperator => OperatorType == OperatorType.Unary;

        /// <summary>
        /// Indicates if this operator is binary, i.e. acts on two arguments
        /// </summary>
        public override bool IsBinaryOperator => OperatorType == OperatorType.Binary;
    }
}
