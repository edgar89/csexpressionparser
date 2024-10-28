namespace CsExpressionParser
{
    /// <summary>
    /// The elementary component of an <see cref="IExpression{T}"/>
    /// </summary>
    /// <remarks>
    /// Creates a new instance of this class
    /// </remarks>
    /// <param name="name">Token name</param>
    public abstract class Token(string name)
    {
        /// <summary>
        /// Token name, i.e. its string representation
        /// </summary>
        public string Name { get; private set; } = name;

        /// <summary>
        /// Indicates if this token is a symbol or not
        /// </summary>
        public virtual bool IsSymbol => false;
        /// <summary>
        /// Indicates if this token is an operator or not
        /// </summary>
        public virtual bool IsOperator => IsBinaryOperator || IsUnaryOperator;
        /// <summary>
        /// Indicates if this token is a binary operator or not
        /// </summary>
        public virtual bool IsBinaryOperator => false;
        /// <summary>
        /// Indicates if this token is an unary operator or not
        /// </summary>
        public virtual bool IsUnaryOperator => false;
        /// <summary>
        /// Indicates if this token is a literal value or not
        /// </summary>
        public virtual bool IsLiteral => false;
        /// <summary>
        /// Indicates if this token is an identifier or not
        /// </summary>
        public virtual bool IsIdentifier => false;
        /// <summary>
        /// Indicates if this token is a function or not
        /// </summary>
        public virtual bool IsFunction => false;
        /// <summary>
        /// Operator associativity, if this is an operator
        /// </summary>
        public virtual OperatorAssociativity Associativity { get; protected set; } = OperatorAssociativity.NONE;
        /// <summary>
        /// Operator precedence, if this is an operator
        /// </summary>
        public virtual OperatorPrecedence OperatorPrecedence { get; protected set; } = OperatorPrecedence.INVALID;

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return Name.Equals((obj as Token)?.Name);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return Name;
        }
    }
}