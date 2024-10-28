namespace CsExpressionParser
{
    /// <summary>
    /// An Identifier is a <see cref="Token"/> which represents something that has to be evaluated at runtime. 
    /// It can be a variable or a function
    /// </summary>
    /// <typeparam name="T">Domain of the identifier value</typeparam>
    /// <remarks>
    /// Creates a new identifier with given name
    /// </remarks>
    /// <param name="name">Identifier name</param>
    public class Identifier<T>(string name) : Token(name)
    {
        /// <inheritdoc/>
        public override bool IsIdentifier => true;

        /// <summary>
        /// Obtains the value of this identifier using the provided value map
        /// </summary>
        /// <param name="variables">Value map</param>
        /// <returns>The value of the identifier</returns>
        /// <exception cref="InvalidOperationException">If provided values map does not contain a mapping for this identifier</exception>
        public virtual T Evaluate(IDictionary<string, T> variables)
        {
            if (variables.TryGetValue(Name, out T? value))
                return value;
            throw new InvalidOperationException(string.Format("Unknown variable {0}", Name));
        }
    }
}
