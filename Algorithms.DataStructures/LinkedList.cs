using System.CodeDom;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Represents a linked list data structure.
    /// </summary>
    /// <typeparam name="T">The type of the items contained within the list.</typeparam>
    public class LinkedList<T> : ICollection<T>
    {
        private LinkedListNode<T> _head;
        private LinkedListNode<T> _tail;

        #region Public Properties

        /// <summary>
        /// Gets the first node in the linked list.
        /// </summary>
        public LinkedListNode<T> First
        {
            get { return _head; }
        }

        /// <summary>
        /// Gets the last node in the linked list.
        /// </summary>
        public LinkedListNode<T> Last
        {
            get { return _tail; }
        }

        #endregion

        #region ICollection<T> Members

        /// <summary>
        /// Adds the specified item to the end of the linked list.
        /// </summary>
        /// <param name="item">The item to add.</param>
        /// <remarks>Performance: O(1)</remarks>
        public void Add(T item)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(item);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = node;
            }

            Count++;
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public int Count
        {
            get { throw new System.NotImplementedException(); }
            set { throw new System.NotImplementedException(); }
        }

        public bool IsReadOnly
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = _head;

            // 1) Empty list: Do nothing

            while (current != null)
            {
                
            }

            return false;
        }

        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}