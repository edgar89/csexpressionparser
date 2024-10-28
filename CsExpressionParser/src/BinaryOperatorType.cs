namespace CsExpressionParser
{
    /// <summary>
    /// The possible binary operators are in this class
    /// </summary>
    public class BinaryOperatorType
    {
        /// <summary>
        /// Binary plus operator
        /// </summary>
        public static readonly BinaryOperatorType Plus = new('+');
        /// <summary>
        /// Binary minus operator
        /// </summary>
        public static readonly BinaryOperatorType Minus = new('-');
        /// <summary>
        /// Binary multiply operator
        /// </summary>
        public static readonly BinaryOperatorType Multiply = new('*');
        /// <summary>
        /// Binary divide operator
        /// </summary>
        public static readonly BinaryOperatorType Divide = new('/');
        /// <summary>
        /// Binary power operator
        /// </summary>
        public static readonly BinaryOperatorType Power = new('^');
        /// <summary>
        /// Binary modulus operator
        /// </summary>
        public static readonly BinaryOperatorType Modulus = new('%');

        /// <summary>
        /// The character
        /// </summary>
        private readonly char c;
        
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="c">The character</param>
        private BinaryOperatorType(char c)
        {
            this.c = c;
        }

        /// <summary>
        /// Gets a value indicating if the provided character value represents a <see cref="BinaryOperator{T}"/>
        /// </summary>
        /// <param name="c">The character</param>
        /// <returns><c>true</c> if it is a <see cref="BinaryOperator{T}"/>, <c>false</c> otherwise</returns>
        public static bool IsBinaryOperator(char c)
        {
            return typeof(BinaryOperatorType)
                .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static)
                .Select(f => f.GetValue(null))
                .Where(v => v!.GetType() == typeof(BinaryOperatorType))
                .Select(v => (BinaryOperatorType)v!)
                .Any(u => u.c == c);
        }
    }
}
