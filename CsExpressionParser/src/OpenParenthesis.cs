namespace CsExpressionParser
{
    /// <summary>
    /// An open parenthesis is a <see cref="Symbol"/> that starts a sub expression
    /// </summary>
    public class OpenParenthesis : Symbol
    {
        /// <summary>
        /// Creates a new Symbol with the given name
        /// </summary>
        public OpenParenthesis() : base("(") { }
    }
}
