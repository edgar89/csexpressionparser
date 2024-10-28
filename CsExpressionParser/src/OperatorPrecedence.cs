namespace CsExpressionParser
{
    /// <summary>
    /// Enumerates possible <see cref="Operator"/> precedencies
    /// </summary>
    public enum OperatorPrecedence : int
    {
        /// <summary>
        /// Invalid precedence, for things that are not operators
        /// </summary>
        INVALID = int.MinValue,
        /// <summary>
        /// Lowest
        /// </summary>
        LOWEST = 0,
        /// <summary>
        /// Lower
        /// </summary>
        LOWER = 12,
        /// <summary>
        /// Low
        /// </summary>
        LOW = 25,
        /// <summary>
        /// Medium
        /// </summary>
        MEDIUM = 50,
        /// <summary>
        /// High
        /// </summary>
        HIGH = 75,
        /// <summary>
        /// Higher
        /// </summary>
        HIGHER = 87,
        /// <summary>
        /// Highest
        /// </summary>
        HIGHEST = 100            
    }
}
