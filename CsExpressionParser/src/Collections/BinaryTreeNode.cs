namespace CsExpressionParser.Collections
{
    /// <summary>
    /// Node of a binary tree, used as building blocks of the expression tree
    /// </summary>
    /// <typeparam name="T">Type of the elements in the node</typeparam>
    internal class BinaryTreeNode<T>
    {
        /// <summary>
        /// Left child
        /// </summary>
        private readonly BinaryTreeNode<T>? left;
        /// <summary>
        /// Right child
        /// </summary>
        private readonly BinaryTreeNode<T>? right;

        /// <summary>
        /// Left child
        /// </summary>
        public BinaryTreeNode<T>? Left => left;
        /// <summary>
        /// Right child
        /// </summary>
        public BinaryTreeNode<T>? Right => right;
        /// <summary>
        /// Value contained in the node
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// Creates a new instance of this class
        /// </summary>
        /// <param name="data">Data for the node</param>
        /// <param name="left">Left child</param>
        /// <param name="right">Right child</param>
        internal BinaryTreeNode(T data, BinaryTreeNode<T>? left, BinaryTreeNode<T>? right)
        {
            this.Data = data;
            this.left = left;
            this.right = right;
        }

        public override string ToString()
        {
            return Data?.ToString() ?? "";
        }
    }
}
