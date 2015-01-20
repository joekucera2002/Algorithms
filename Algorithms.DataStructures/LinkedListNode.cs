namespace Algorithms.DataStructures
{
    /// <summary>
    /// Represents a node in a linked list.
    /// </summary>
    /// <typeparam name="T">The type of value contained in the node.</typeparam>
    public class LinkedListNode<T>
    {
        #region Public Properties

        /// <summary>
        /// Gets the value contained within the node.
        /// </summary>
        public T Value { get; internal set; }

        /// <summary>
        /// Gets the next linked node.
        /// </summary>
        public LinkedListNode<T> Next { get; internal set; } 

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LinkedListNode{T}"/> class.
        /// </summary>
        /// <param name="value">The value to be contained within the node.</param>
        public LinkedListNode(T value)
        {
            Value = value;
        }

        #endregion
    }
}