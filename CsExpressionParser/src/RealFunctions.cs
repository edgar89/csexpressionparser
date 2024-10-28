namespace CsExpressionParser
{
    /// <summary>
    /// Class that contains the standard mathematical real valued functions
    /// </summary>
    public static class RealFunctions
    {
        /// <summary>
        /// Private class to provide evaluators for real functions 
        /// </summary>
        /// <remarks>
        /// Creates a new instance of this class
        /// </remarks>
        /// <param name="name">Function name</param>
        /// <param name="f">Function evaluation function</param>
        private class RealFunctionEvaluator(string name, Func<double, double> f) : IFunctionEvaluator<double>
        {
            /// <summary>
            /// The actual underlying function
            /// </summary>
            private readonly Func<double, double> f = f;

            /// <inheritdoc/>
            public string Name { get; private set; } = name;

            /// <inheritdoc/>
            public double Evaluate(IList<double> arguments)
            {
                return f.Invoke(arguments[0]);
            }
        }

        /// <summary>
        /// Returns all the real-valued standard functions supported by the library
        /// </summary>
        /// <returns>All the real-valued standard functions supported by the library</returns>
        public static Dictionary<string, IFunctionEvaluator<double>> Values()
        {
            return new Dictionary<string, IFunctionEvaluator<double>>
            {
                { "sin", new RealFunctionEvaluator("sin", Math.Sin) },
                { "cos", new RealFunctionEvaluator("cos", Math.Cos) },
                { "tan", new RealFunctionEvaluator("tan", Math.Tan) },
                { "csc", new RealFunctionEvaluator("csc", t => 1 / Math.Sin(t)) },
                { "sec", new RealFunctionEvaluator("sec", t => 1 / Math.Cos(t)) },
                { "cot", new RealFunctionEvaluator("cot", t => 1 / Math.Tan(t)) },
                { "sinh", new RealFunctionEvaluator("sinh", Math.Sinh) },
                { "cosh", new RealFunctionEvaluator("cosh", Math.Cosh) },
                { "tanh", new RealFunctionEvaluator("tanh", Math.Tanh) },
                { "csch", new RealFunctionEvaluator("csch", t => 1 / Math.Sinh(t)) },
                { "sech", new RealFunctionEvaluator("sech", t => 1 / Math.Cosh(t)) },
                { "coth", new RealFunctionEvaluator("coth", t => 1 / Math.Tanh(t)) },
                { "asin", new RealFunctionEvaluator("asin", Math.Asin) },
                { "acos", new RealFunctionEvaluator("acos", Math.Acos) },
                { "atan", new RealFunctionEvaluator("atan", Math.Atan) },
                { "acsc", new RealFunctionEvaluator("acsc", t => Math.Asin(1 / t)) },
                { "asec", new RealFunctionEvaluator("asec", t => Math.Cos(1 / t)) },
                { "acot", new RealFunctionEvaluator("acot", t => Math.PI -  Math.Atan(t)) },
                { "asinh", new RealFunctionEvaluator("asinh", Math.Sinh) },
                { "acosh", new RealFunctionEvaluator("acosh", Math.Cosh) },
                { "atanh", new RealFunctionEvaluator("atanh", Math.Tanh) },
                { "acsch", new RealFunctionEvaluator("acsch", t => Math.Log(1/t + Math.Sqrt(1+1/(t*t)))) },
                { "asech", new RealFunctionEvaluator("asech", t => Math.Log(1/t + Math.Sqrt(-1+1/(t*t)))) },
                { "acoth", new RealFunctionEvaluator("acoth", t => 0.5 * Math.Log((t+1)/(t-1))) },
                { "exp", new RealFunctionEvaluator("exp", Math.Exp) },
                { "abs", new RealFunctionEvaluator("abs", Math.Abs) },
                { "sqrt", new RealFunctionEvaluator("sqrt", Math.Sqrt) },
                { "cbrt", new RealFunctionEvaluator("cbrt", Math.Cbrt) },
                { "floor", new RealFunctionEvaluator("floor", Math.Floor) },
                { "ceil", new RealFunctionEvaluator("ceil", Math.Ceiling) },
                { "int", new RealFunctionEvaluator("int", t => t < 0 ? Math.Ceiling(t) : Math.Floor(t)) },
                { "ln", new RealFunctionEvaluator("ln", Math.Log) },
                { "log", new RealFunctionEvaluator("log", Math.Log10) },
                { "round", new RealFunctionEvaluator("round", Math.Round) },
                { "sign", new RealFunctionEvaluator("sign", t => (double)Math.Sign(t)) },
            };  
        }
    }
}
