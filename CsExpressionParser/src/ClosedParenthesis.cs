namespace CsExpressionParser
{
    /// <summary>
    /// A closed parenthesis is a <see cref="Symbol"/> that ends a sub expression
    /// </summary>
    public class ClosedParenthesis : Symbol
    {
        /// <summary>
        /// Creates a new Symbol with the given name
        /// </summary>
        public ClosedParenthesis() : base(")") { }
    }
}
