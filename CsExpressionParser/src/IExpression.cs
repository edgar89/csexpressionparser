namespace CsExpressionParser
{
    /// <summary>
    /// An interface representing an evaluable math expression. 
    /// </summary>
    /// <typeparam name="T">Type of the arguments used and returned by the expression</typeparam>
    public interface IExpression<T>
    { 
        /// <summary>
        /// Sets the value for given variable. If the variable does not appear in the expression no exception is thrown
        /// </summary>
        /// <param name="variableName">Variable name</param>
        /// <param name="value">Value</param>
        void SetVariableValue(string variableName, T value);

        /// <summary>
        /// Removes the mapping for given variable. If mapping was already non-existent then no exception is thrown
        /// </summary>
        /// <param name="variableName">Variable name</param>
        void RemoveVariableValue(string variableName);

        /// <summary>
        /// Evaluates the expression
        /// </summary>
        /// <returns>The value of the expression</returns>
        T Evaluate();
    }
}
