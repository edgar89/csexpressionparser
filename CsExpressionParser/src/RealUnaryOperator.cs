namespace CsExpressionParser
{
    /// <summary>
    /// Represents an unary operator that acts on one real value
    /// </summary>
    /// <remarks>
    /// Creates a new instance of this class
    /// </remarks>
    /// <param name="name">Operator symbol</param>
    /// <param name="f">Function applying the operator</param>
    public abstract class RealUnaryOperator(string name, UnaryOperatorType type, OperatorAssociativity associativity) : UnaryOperator<double>(name, type, associativity)
    {

        /// <summary>
        /// Creates an instance given its representation
        /// </summary>
        /// <param name="token">The token</param>
        /// <returns>The <see cref="RealUnaryOperator"/></returns>
        /// <exception cref="ArgumentException">if the string is not a valid operator</exception>
        public static RealUnaryOperator From(string token)
        {
            return token switch
            {
                "+" => new RealUnaryPlusOperator(),
                "-" => new RealUnaryMinusOperator(),
                _ => throw new ArgumentException(string.Format("{0} is not a valid unary operator", token)),
            };
        }
    }
}
