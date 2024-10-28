namespace CsExpressionParser
{
    /// <summary>
    /// A function is a special kind of <see cref="Identifier{T}"/> whose value is retrieved by applying a given logic to a series of arguments 
    /// </summary>
    /// <typeparam name="T">Type of the values used as arguments and returned by the function</typeparam>
    /// <remarks>
    /// Creates a new function having given name and given arguments
    /// </remarks>
    /// <param name="name">Function name</param>
    public abstract class Function<T>(string name) : Identifier<T>(name)
    {
        /// <inheritdoc/>
        public override bool IsFunction => true;
        /// <summary>
        /// Number of arguments for this function
        /// </summary>
        public abstract int Arity { get; }

        /// <inheritdoc/>
        public override T Evaluate(IDictionary<string, T> variables)
        {
            return EvaluateFunction(variables, []);
        }

        /// <summary>
        /// Returns the value obtained by applying this instance of {@link Function} to the underlying argument
        /// </summary>
        /// <param name="variables">Variables map</param>
        /// <param name="arguments">Function args, if any</param>
        /// <returns>Function result</returns>
        public abstract T EvaluateFunction(IDictionary<string, T> variables, IList<T> arguments);
    }
}
