namespace CsExpressionParser
{
    /// <summary>
    /// The possible unary operators are in this class
    /// </summary>
    public class UnaryOperatorType
    {
        /// <summary>
        /// Unary plus operator
        /// </summary>
        public static readonly UnaryOperatorType Plus = new('+');
        /// <summary>
        /// Unary minus operator
        /// </summary>
        public static readonly UnaryOperatorType Minus = new('-');

        /// <summary>
        /// The character
        /// </summary>
        private readonly char c;
        
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="c">The character</param>
        private UnaryOperatorType(char c)
        {
            this.c = c;
        }

        /// <summary>
        /// Gets a value indicating if the provided character value represents a <see cref="UnaryOperator{T}"/>
        /// </summary>
        /// <param name="c">The character</param>
        /// <returns><c>true</c> if it is a <see cref="UnaryOperator{T}"/>, <c>false</c> otherwise</returns>
        public static bool IsUnaryOperator(char c)
        {
            return typeof(UnaryOperatorType)
                .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .Select(f => f.GetValue(null))
                .Where(v => v!.GetType() == typeof(UnaryOperatorType))
                .Select(v => (UnaryOperatorType)v!)
                .Any(u => u.c == c);
        }
    }
}
