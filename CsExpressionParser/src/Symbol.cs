namespace CsExpressionParser
{
    /// <summary>
    /// A Symbol is a <see cref="Token"/> which has some syntactic/semantic significance inside an expression. It is also the fallback value for any token that cannot be classified into something else
    /// </summary>
    /// <remarks>
    /// Creates a new Symbol with the given name
    /// </remarks>
    /// <param name="name">Symbol name</param>
    public class Symbol(string name) : Token(name)
    {
        /// <inheritdoc/>
        public override bool IsSymbol => true;

        /// <summary>
        /// Indicates if this symbol is a comma
        /// </summary>
        public bool IsComma => ",".Equals(Name);
        /// <summary>
        /// Indicates if this symbol is a semicolon
        /// </summary>
        public bool IsSemicolon => ";".Equals(Name);
        /// <summary>
        /// Indicates if this symbol is an open parenthesis
        /// </summary>
        public bool IsOpenParenthesis => "(".Equals(Name);
        /// <summary>
        /// Indicates if this symbol is a closed parenthesis
        /// </summary>
        public bool IsClosedParenthesis => ")".Equals(Name);
        /// <summary>
        /// Indicates if this symbol is a separator
        /// </summary>
        public bool IsSeparator => IsComma || IsSemicolon;
        /// <summary>
        /// Indicates if this symbol is a parenthesis
        /// </summary>
        public bool IsParenthesis => IsOpenParenthesis || IsClosedParenthesis;
    }
}
