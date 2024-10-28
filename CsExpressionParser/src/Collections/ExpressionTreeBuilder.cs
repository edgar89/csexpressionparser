namespace CsExpressionParser.Collections
{
    /// <summary>
    /// Internal class to build <see cref="IExpression{T}"/>
    /// </summary>
    /// <typeparam name="T">Type of the expression</typeparam>
    internal class ExpressionTreeBuilder<T>
    {
        /// <summary>
        /// Input token list
        /// </summary>
        private readonly List<Token> tokenList;
        /// <summary>
        /// Processed token list, in postfix order
        /// </summary>
        private readonly List<Token> postfix;

        /// <summary>
        /// The <see cref="ExpressionTree{T}"/> being built
        /// </summary>
        private ExpressionTree<T>? tree;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="tokenList">Input token list</param>
        internal ExpressionTreeBuilder(List<Token> tokenList)
        {
            this.tokenList = tokenList;
            this.postfix = [];
        }

        /// <summary>
        /// Builds the <see cref="ExpressionTree{T}"/>
        /// </summary>
        /// <returns>The tree</returns>
        internal ExpressionTree<T> Build()
        {
            if (tree == null)
            {
                InfixToPostfix();
                BuildTree();
            }

            return tree!;
        }

        /// <summary>
        /// Internal method. Transforms input token list to postfix order. Populates <see cref="postfix"/>
        /// </summary>
        private void InfixToPostfix()
        {
            Stack<Token> stack = new();

            IEnumerator<Token> iterator = tokenList.GetEnumerator();
            int i = -1;

            while (iterator.MoveNext())
            {
                Token token = iterator.Current;
                HandleToken(stack, token, i);
            }

            CleanStack(stack, i);
        }

        /// <summary>
        /// Handles current token
        /// </summary>
        /// <param name="stack">Current stack</param>
        /// <param name="token">Current token</param>
        /// <param name="i">Current parsing position</param>
        private void HandleToken(Stack<Token> stack, Token token, int i)
        {
            if (token is OpenParenthesis)
            {
                stack.Push(token);
            }
            else if (token is ClosedParenthesis)
            {
                HandleClosedParenthesis(stack, i);
            }
            else if (token is Comma)
            {
                HandleComma(stack, i);
            }
            else if (token.IsOperator)
            {
                HandleOperator(stack, token);
            }
            else if (token.IsFunction)
            {
                // Functions are like unary operator
                stack.Push(token);
            }
            else
            {
                postfix.Add(token);
            }
        }

        /// <summary>
        /// Handles a closed parenthesis
        /// </summary>
        /// <param name="stack">Current stack</param>
        /// <param name="position">Current parsing position</param>
        /// <exception cref="FormatException">If no matching open parenthesis is found</exception>
        private void HandleClosedParenthesis(Stack<Token> stack, int position)
        {
            while (stack.Count != 0 && stack.Peek() is not OpenParenthesis)
            {
                postfix.Add(stack.Pop());
            }
            if (stack.Count == 0)
            {
                throw new FormatException(string.Format("Mismatched parenthesis at position {0}", position));
            }
            stack.Pop();
            // If the next token is a function, pop it and add it to the postfix list
            if (stack.Count != 0 && stack.Peek().IsFunction)
            {
                postfix.Add(stack.Pop());
            }
        }

        /// <summary>
        /// Handle a comma
        /// </summary>
        /// <param name="stack">Current stack</param>
        /// <param name="position">Current parsing position</param>
        /// <exception cref="FormatException">If no matching open parenthesis is found</exception>
        private void HandleComma(Stack<Token> stack, int position)
        {
            while (stack.Count != 0 && stack.Peek() is not OpenParenthesis)
            {
                postfix.Add(stack.Pop());
            }

            if (stack.Count == 0)
            {
                throw new FormatException(string.Format("Wrong use of comma at position {0} (no parenthesis)", position));
            }

            stack.Push(new Comma());
        }

        /// <summary>
        /// Handles an operator
        /// </summary>
        /// <param name="stack">Current stack</param>
        /// <param name="token">Current token (an operator)</param>
        private void HandleOperator(Stack<Token> stack, Token token)
        {
            if (token.IsBinaryOperator)
            {
                while (stack.Count != 0 &&
                       stack.Peek() is Operator &&
                       (token.OperatorPrecedence < stack.Peek().OperatorPrecedence ||
                        token.OperatorPrecedence == stack.Peek().OperatorPrecedence && token.Associativity == OperatorAssociativity.LEFT))
                {
                    postfix.Add(stack.Pop());
                }
            }
            // Stack unary operators allowing for +-++4 => +-+4 => +-4 => -4
            stack.Push(token);
        }

        /// <summary>
        /// Resolves the stack and populates <see cref="postfix"/> list
        /// </summary>
        /// <param name="stack">Current stack</param>
        /// <param name="position">Current parsing position</param>
        /// <exception cref="FormatException">If no matching open parenthesis is found</exception>
        private void CleanStack(Stack<Token> stack, int position)
        {
            while (stack.Count != 0)
            {
                if (stack.Peek() is OpenParenthesis || stack.Peek() is ClosedParenthesis)
                {
                    throw new FormatException(string.Format("Mismatched parenthesis at position {0}", position));
                }
                postfix.Add(stack.Pop());
            }
        }

        /// <summary>
        /// Builds the expression tree
        /// </summary>
        private void BuildTree()
        {
            Stack<BinaryTreeNode<Token>> stack = new();
            foreach (Token token in postfix)
            {
                if (token.IsBinaryOperator || token is Comma)
                {
                    BinaryTreeNode<Token> right = stack.Pop();
                    BinaryTreeNode<Token> left = stack.Pop();
                    BinaryTreeNode<Token> node = new(token, left, right);
                    stack.Push(node);
                }

                else if (token.IsUnaryOperator || token.IsFunction)
                {
                    BinaryTreeNode<Token> child = stack.Pop();
                    BinaryTreeNode<Token> node = new(token, child, null);
                    stack.Push(node);
                }
                else
                {
                    stack.Push(new BinaryTreeNode<Token>(token, null, null));
                }
            }
            tree = new ExpressionTree<T>(stack.Pop());
        }
    }
}
