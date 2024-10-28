using System.Text;

namespace CsExpressionParser.Collections
{
    /// <summary>
    /// A Binary Tree of tokens
    /// </summary>
    internal class ExpressionTree<T>
    {
        /// <summary>
        /// Root of the tree
        /// </summary>
        private readonly BinaryTreeNode<Token>? root;

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="root">Root node</param>
        internal ExpressionTree(BinaryTreeNode<Token>? root)
        {
            this.root = root;
        }

        /// <summary>
        /// Evaluates the expression contained in this tree
        /// </summary>
        /// <param name="variables">Variable map</param>
        /// <returns>The value of the expression</returns>
        internal T? Evaluate(IDictionary<string, T> variables)
        {
            int pos = 0;
            return (T?) EvaluateRec(root, variables, ref pos);
        }

        /// <summary>
        /// Recursively evaluate this tree
        /// </summary>
        /// <param name="root">Current node</param>
        /// <param name="variables">Variables</param>
        /// <param name="position">Current position</param>
        /// <returns>The value of the expression backed by this tree</returns>
        /// <exception cref="FormatException">If an unexpected token is met</exception>
        private static object? EvaluateRec(BinaryTreeNode<Token>? root, IDictionary<string, T> variables, ref int position)
        {
            if (root == null)
                return default;

            object? leftArg = EvaluateRec(root.Left, variables, ref position);
            object? rightArg = EvaluateRec(root.Right, variables, ref position);

            Token t = root.Data!;
            position++;
            if (t.IsLiteral)
            {
                return ((Literal<T>)t).Value;
            }
            else if (t.IsOperator && ((Operator)t).IsUnaryOperator)
            {
                return ((UnaryOperator<T>)t).Evaluate((T)leftArg!);
            }
            else if (t.IsFunction)
            {
                return leftArg is IList<T> list
                    ? ((Function<T>)t).EvaluateFunction(variables, list)
                    : (object?)((Function<T>)t).EvaluateFunction(variables, [(T)leftArg!]);
            }
            else if (t.IsIdentifier)
            {
                return ((Identifier<T>)t).Evaluate(variables);
            }
            else if (t is Comma)
            {
                if (leftArg is IList<T> list)
                {
                    List<T> result = [.. list, (T)rightArg!];
                    return result;
                }
                else
                {
                    return new List<T>() { (T)leftArg!, (T)rightArg! };
                }
            }
            else if (t.IsOperator && ((Operator)t).IsBinaryOperator)
            {
                return ((BinaryOperator<T>)t).Evaluate((T)leftArg!, (T)rightArg!);
            }
            else
            {
                throw new FormatException(string.Format("Token {0} is not valid at position {1}", t.ToString(), position));
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            StringBuilder sb = new();
            ToStringRec(sb, root, "", "");
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Recursively builds a string representation of this object
        /// </summary>
        /// <param name="sb">String builder</param>
        /// <param name="root">Current node</param>
        /// <param name="prefix">String prefix</param>
        /// <param name="childrenPrefix">Children prefix</param>
        private static void ToStringRec(StringBuilder sb, BinaryTreeNode<Token>? root, string prefix, string childrenPrefix)
        {
            if (root == null)
                return;

            sb.Append(prefix);
            sb.Append(root.ToString());
            sb.Append(Environment.NewLine);
            string withChildPrefix = childrenPrefix + "├─ ";
            string withNoChildPrefix = childrenPrefix + "└─ ";

            ToStringRec(sb, root.Left, root.Right != null ? withChildPrefix : withNoChildPrefix, childrenPrefix + "│  ");
            ToStringRec(sb, root.Right, childrenPrefix + "└─ ", childrenPrefix + "   ");
        }
    }
}
