namespace CsExpressionParser
{
    /// <summary>
    /// Basic class for all expressions supported by this library
    /// </summary>
    /// <typeparam name="T">Type of values handled by this expression</typeparam>
    /// <remarks>
    /// Creates a new instance of this class
    /// </remarks>
    /// <param name="expression">The expression</param>
    public abstract class Expression<T>(string expression) : IExpression<T>, IEquatable<Expression<T>?>
    {
        /// <summary>
        /// The variables which may have a value in the expression
        /// </summary>
        protected readonly IDictionary<string, T> values = new Dictionary<string, T>();
        /// <summary>
        /// THe expression
        /// </summary>
        protected readonly string expression = expression;
        /// <summary>
        /// Flag used during tokenization
        /// </summary>
        protected bool expectUnaryOperator = true;
        /// <summary>
        /// The list of token. This is not-null only when tokenized is true
        /// </summary>
        protected List<Token>? tokenList;
        /// <summary>
        /// Indicates if this expression has already been tokenized. Tokenization is a pre-requirement for evaluation
        /// </summary>
        private bool tokenized = false;

        /// <inheritdoc/>
        public void SetVariableValue(string variableName, T value)
        {
            this.values[variableName] = value;
        }

        /// <inheritdoc/>
        public void RemoveVariableValue(string variableName)
        {
            if (this.values.ContainsKey(variableName)) 
                this.values.Remove(variableName);
        }

        /// <inheritdoc/>
        public abstract T Evaluate();

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Expression<T>);
        }

        /// <inheritdoc/>
        public bool Equals(Expression<T>? other)
        {
            return other is not null &&
                   expression == other.expression;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return expression.GetHashCode();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return expression;
        }

        /// <summary>
        /// Tokenize the expression
        /// </summary>
        /// <exception cref="FormatException">If the expression is invalid</exception>
        protected void Tokenize()
        {
            if (tokenized)
                return;

            tokenList = [];
            int i = 0;
            int len = expression.Length;

            do
            {
                try
                {
                    HandleChar(ref i);
                }
                catch (FormatException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw new FormatException(string.Format("Invalid character at index {0}", i), e);
                }
            }
            while (i < len);

            tokenized = true;
        }

        /// <summary>
        /// During tokenization this method is called to parse an <see cref="Operator"/>
        /// </summary>
        /// <param name="i">Current parsing position</param>
        /// <param name="c">Character to parse</param>
        protected abstract void HandleOperator(ref int i, char c);
        /// <summary>
        /// During tokenization this method is called to parse a <see cref="Literal{T}"/>
        /// </summary>
        /// <param name="i">Current parsing position</param>
        /// <param name="c">Character to parse</param>
        protected abstract void HandleLiteral(ref int i, char c);
        /// <summary>
        /// During tokenization this method is called to parse an <see cref="Identifier{T}"/>
        /// </summary>
        /// <param name="i">Current parsing position</param>
        /// <param name="c">Character to parse</param>
        protected abstract void HandleIdentifier(ref int i, char c);

        /// <summary>
        /// During tokenization, handles the character in given position in expression
        /// </summary>
        /// <param name="i">Current position</param>
        /// <exception cref="FormatException">If the character is invalid</exception>
        private void HandleChar(ref int i)
        {
            char c = expression[i];
            if (c.IsOperator())
            {
                HandleOperator(ref i, c);
                expectUnaryOperator = true;
                i++;
            }
            else if (char.IsDigit(c))
            {
                HandleLiteral(ref i, c);
                expectUnaryOperator = false;
            }
            else if (char.IsLetter(c))
            {
                HandleIdentifier(ref i, c);
                expectUnaryOperator = false;
            }
            else if (c == '(')
            {
                tokenList!.Add(new OpenParenthesis());
                expectUnaryOperator = true;
                i++;
            }
            else if (c == ')')
            {
                tokenList!.Add(new ClosedParenthesis());
                expectUnaryOperator = false;
                i++;
            }
            else if (c == ',')
            {
                tokenList!.Add(new Comma());
                expectUnaryOperator = true;
                i++;
            }
            else if (c == ' ') // skip spaces
            {
                i++;
            }
            else
            {
                throw new FormatException(string.Format("Unexpected character ({0}) at index {1} ", c, i));
            }
        }       
    }
}
