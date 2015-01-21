using System;
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

        /// <summary>
        /// Removes the first node in the list which equals the provided value.
        /// </summary>
        /// <param name="item">The item value to remove.</param>
        /// <returns>True if the item was removed, false otherwise.</returns>
        /// <remarks>Performance: O(n)</remarks>
        public Boolean Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = _head;

            // 1) Empty list:   Do nothing
            // 2) Single node : Previous is null
            // 3) Many Nodes:
            //      a) Node to remove is the first node
            //      b) Node to remove is middle or last

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        // Case 3b
                        previous.Next = current.Next;

                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        // Case 2, 3a

                        _head = current.Next;

                        if (_head == null)
                        {
                            // List is empty
                            _tail = null;
                        }
                    }

                    Count--;

                    return true;
                }

                previous = current;
                current = current.Next;
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