namespace CsExpressionParser
{
    /// <summary>
    /// A literal represents a <see cref="Token"/> whose string representation is also a direct representation of its value
    /// </summary>
    /// <typeparam name="T">Type of the literal</typeparam>
    /// <remarks>
    /// Creates a new literal
    /// </remarks>
    /// <param name="name">Literal value, expressed as a string</param>
    /// <param name="value">Literal value, expressed as a native literal type</param>
    public abstract class Literal<T>(string name, T value) : Token(name) 
    {
        /// <inheritdoc/>
        public override bool IsLiteral => true;
        /// <summary>
        /// Value of the literal
        /// </summary>
        public T Value { get; private set; } = value;
    }
}
