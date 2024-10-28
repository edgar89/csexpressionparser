namespace CsExpressionParser
{
    /// <summary>
    /// Represents a binary operator that acts on two real values
    /// </summary>
    /// <remarks>
    /// Creates a new instance of this class
    /// </remarks>
    /// <param name="name">Operator symbol</param>
    /// <param name="priority">Operator priority</param>
    /// <param name="f">Function applying the operator</param>
    public abstract class RealBinaryOperator(string name, BinaryOperatorType type, OperatorAssociativity associativity) : BinaryOperator<double>(name, type, associativity)
    {

        /// <summary>
        /// Creates a new instance of this type of operator giving its string value
        /// </summary>
        /// <param name="token">The token</param>
        /// <returns>The <see cref="RealBinaryOperator"/></returns>
        /// <exception cref="ArgumentException">if this is not a valid binary operator</exception>
        public static RealBinaryOperator From(string token)
        {
            return token switch
            {
                "+" => new RealBinaryPlusOperator(),
                "-" => new RealBinaryMinusOperator(),
                "*" => new RealBinaryMultiplyOperator(),
                "/" => new RealBinaryDivideOperator(),
                "^" => new RealBinaryPowerOperator(),
                "%" => new RealBinaryModulusOperator(),
                _ => throw new ArgumentException(string.Format("{0} is not a valid binary operator", token)),
            };
        }
    }
}
