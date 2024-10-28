namespace CsExpressionParser
{
    /// <summary>
    /// An interface whose purpose is to allow user to extend the library with custom functions
    /// </summary>
    /// <typeparam name="T">Type of the values accepted and returned by a given function</typeparam>
    public interface IFunctionEvaluator<T>
    {
        /// <summary>
        /// Function name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Evaluates the function using given arguments
        /// </summary>
        /// <param name="arguments">Arguments</param>
        /// <returns>The function value</returns>
        T Evaluate(IList<T?> arguments);
    }
}
