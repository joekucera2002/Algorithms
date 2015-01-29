using System;
using System.CodeDom;
using System.Collections;
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

        /// <summary>
        /// Clears the linked list.
        /// </summary>
        /// <remarks>Performance: O(1)</remarks>
        public void Clear()
        {
            _head = null;
            _tail = null;

            Count = 0;
        }

        /// <summary>
        /// Gets a value indicating whether the provided value exists within the linked list.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns>True if the item exists, false otherwise.</returns>
        /// <remarks>Performance: O(n)</remarks>
        public Boolean Contains(T item)
        {
            LinkedListNode<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Copies the contents of the linked list to the supplied array beginning at the specified index.
        /// </summary>
        /// <param name="array">The target array.</param>
        /// <param name="arrayIndex">The starting index.</param>
        /// <remarks>Performance: O(n).
        /// It is the responsibility of the caller to provide an array which has enough capacity to contain all 
        /// of the items in the linked list.
        /// </remarks>
        public void CopyTo(T[] array, Int32 arrayIndex)
        {
            LinkedListNode<T> currentNode = _head;
            Int32 index = arrayIndex;

            while (currentNode != null)
            {
                array[index] = currentNode.Value;

                currentNode = currentNode.Next;
                index++;
            }
        }

        /// <summary>
        /// Gets the number of items currently in the linked list.
        /// </summary>
        /// <remarks>Performance: O(1)</remarks>
        public Int32 Count { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the linked list is read only.
        /// </summary>
        /// <remarks>Performance: O(1)</remarks>
        public bool IsReadOnly
        {
            get { return false; }
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

        /// <summary>
        /// Gets an enumerator that allows enumeration of the linked list from first to last.
        /// </summary>
        /// <returns>The enumerator instance.</returns>
        /// <remarks>Performance: O(1) - Returning enumerator, O(n) - enumerating each item.</remarks>
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = _head;

            while (current != null)
            {
                yield return current.Value;

                current = current.Next;
            }
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Gets an enumerator that allows enumeration of the linked list from first to last.
        /// </summary>
        /// <returns>The enumerator instance.</returns>
        /// <remarks>Performance: O(1) - Returning enumerator, O(n) - enumerating each item.</remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerable<T> thisEnumerable = (IEnumerable<T>) this;

            return thisEnumerable.GetEnumerator();
        }

        #endregion
    }
}