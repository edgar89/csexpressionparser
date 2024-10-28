namespace CsExpressionParser
{
    /// <summary>
    /// A real function is a function that accepts double arguments and returns a double
    /// </summary>
    /// <remarks>
    /// Creates a new instance of this function
    /// </remarks>
    /// <param name="name">Function name</param>
    public class RealFunction(string name) : Function<double>(name)
    {
        /// <inheritdoc/>
        public override int Arity { get => 1; }

        /// <inheritdoc/>
        public override double EvaluateFunction(IDictionary<string, double> variables, IList<double>? arguments)
        {
            if (arguments == null || arguments.Count != Arity)
            {
                throw new ArgumentException(
                        string.Format("Invalid number of arguments for function {0}. Expected {1}, found {2}",
                                ToString(),
                                Arity,
                                arguments?.Count));
            }

            return RealFunctions.Values()[Name].Evaluate(arguments);
        }
    }
}
