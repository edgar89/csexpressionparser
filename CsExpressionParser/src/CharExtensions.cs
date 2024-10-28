using System.Globalization;

namespace CsExpressionParser
{
    /// <summary>
    /// Extension method(s) for <see cref="Char"/>
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// Indicates if given char is an exponent, i.e. it is a letter 'e' or 'E'
        /// </summary>
        /// <param name="c">This char instance</param>
        /// <returns><c>true</c> if represents an exponent, <c>false</c> otherwise</returns>
        public static bool IsExponent(this char c)
        {
            return c == 'e' || c == 'E';
        }

        /// <summary>
        /// Indicates if given char is a decimal separator for given culture
        /// </summary>
        /// <param name="c">This char instance</param>
        /// <param name="cultureInfo">Culture info</param>
        /// <returns><c>true</c> if represents a decimal separator, <c>false</c> otherwise</returns>
        public static bool IsDecimalSeparator(this char c, CultureInfo cultureInfo)
        {
            return c.ToString() == cultureInfo.NumberFormat.NumberDecimalSeparator;
        }

        public static bool IsOperator(this char c)
        {
            return UnaryOperatorType.IsUnaryOperator(c) || BinaryOperatorType.IsBinaryOperator(c);
        }
    }
}
