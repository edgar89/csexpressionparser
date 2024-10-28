namespace CsExpressionParser
{
    /// <summary>
    /// Represents a <see cref="Literal"/> of type double, i.e. a real number
    /// </summary>
    public class RealLiteral : Literal<double>
    {
        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="value">Literal value</param>
        public RealLiteral(double value) : this(value.ToString(), value) { }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="value">Literal value</param>
        /// <param name="format">String format used to determine the literal string value</param>
        public RealLiteral(double value, string? format) : this(value.ToString(format), value) { }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="value">Literal value</param>
        /// <param name="formatProvider">Format provider to obtain the literal string value</param>
        public RealLiteral(double value, IFormatProvider? formatProvider) : this(value.ToString(formatProvider), value) { }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="value">Literal value</param>
        /// <param name="format">String format used to determine the literal string value</param>
        /// <param name="formatProvider">Format provider to obtain the literal string value</param>
        public RealLiteral(double value, string? format, IFormatProvider? formatProvider) : this(value.ToString(format, formatProvider), value) { }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="name">Literal string representation</param>
        /// <param name="value">Literal value</param>
        private RealLiteral(string name, double value) : base(name, value) { }

        /// <summary>
        /// Parses given string into a <see cref="RealLiteral"/>, i.e. trying to parse it into a double. Standard rules apply when performing the parsing
        /// </summary>
        /// <param name="value">String value to parse</param>
        /// <returns>The RealLiteral instance</returns>
        public static RealLiteral Parse(string value)
        {
            return new RealLiteral(value, double.Parse(value));
        }

        /// <summary>
        /// Parses given string into a <see cref="RealLiteral"/>, i.e. trying to parse it into a double. Standard rules apply when performing the parsing
        /// </summary>
        /// <param name="value">String value to parse</param>
        /// <param name="provider">Format provider to use when parsing the string</param>
        /// <returns>The RealLiteral instance</returns>
        public static RealLiteral Parse(string value, IFormatProvider? provider)
        {
            return new RealLiteral(value, double.Parse(value, provider));
        }

        /// <summary>
        /// Parses given string into a <see cref="RealLiteral"/>, i.e. trying to parse it into a double. Standard rules apply when performing the parsing
        /// </summary>
        /// <param name="style">Number styles allowed in the string representation and checked when performing the parsing</param>
        /// <returns>The RealLiteral instance</returns>
        public static RealLiteral Parse(string value, System.Globalization.NumberStyles style)
        {
            return new RealLiteral(value, double.Parse(value, style));
        }

        /// <summary>
        /// Parses given string into a <see cref="RealLiteral"/>, i.e. trying to parse it into a double. Standard rules apply when performing the parsing
        /// </summary>
        /// <param name="value">String value to parse</param>
        /// <param name="style">Number styles allowed in the string representation and checked when performing the parsing</param>
        /// <param name="provider">Format provider to use when parsing the string</param>
        /// <returns>The RealLiteral instance</returns>
        public static RealLiteral Parse(string value, System.Globalization.NumberStyles style, IFormatProvider? provider)
        {
            return new RealLiteral(value, double.Parse(value, style, provider));
        }

        /// <summary>
        /// Parses given value into a <see cref="RealLiteral"/>, i.e. trying to parse it into a double. Standard rules apply when performing the parsing
        /// </summary>
        /// <param name="value">Span value to parse</param>
        /// <param name="style">Number styles allowed in the string representation and checked when performing the parsing</param>
        /// <param name="provider">Format provider to use when parsing the string</param>
        /// <returns>The RealLiteral instance</returns>
        public static RealLiteral Parse(ReadOnlySpan<char> value, System.Globalization.NumberStyles style = System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.Float, IFormatProvider? provider = null)
        {
            return new RealLiteral(value.ToString(), double.Parse(value, style, provider));
        }

    }
}
