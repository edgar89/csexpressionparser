namespace CsExpressionParser
{
    /// <summary>
    /// A comma is a <see cref="Symbol"/> that separates function arguments
    /// </summary>
    public class Comma : Symbol
    {
        /// <summary>
        /// Creates a new Symbol with the given name
        /// </summary>
        public Comma() : base(",") { }
    }
}
