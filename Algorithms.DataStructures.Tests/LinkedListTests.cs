using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms.DataStructures.Tests
{
    /// <summary>
    /// Unit tests for LinkedList functionality.
    /// </summary>
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        public void AddItemToEmptyListTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();

            // TEST: Add head item to the list
            list.Add(1);

            // Evaluate
            //      1. Item was added (should be head)
            //      2. Head = Tail
            list.Count.Should().Be(1);
            list.First.Value.Should().Be(1);
            list.First.Should().BeSameAs(list.Last);
        }

        [TestMethod]
        public void AddItemToNonEmptyListTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();
            list.Add(1);

            // TEST: Add item to the end of the list
            list.Add(2);

            // Evaluate
            //      1. Item was added (should be tail)
            //      2. Head != tail
            list.Count.Should().Be(2);
            list.Last.Should().NotBeNull();
            list.Last.Value.Should().Be(2);
            list.First.Next.Should().BeSameAs(list.Last);
        }

        [TestMethod]
        public void RemoveItemFromEmptyListTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();

            // TEST: Remove a value from an empty list should do nothing.

            // Evaluate
            //      1. Method should return false
            //      2. Count = 0
            list.Remove(1).Should().BeFalse();
            list.Count.Should().Be(0);
        }

        [TestMethod]
        public void RemoveSingleItemTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();

            // TEST: Remove the single node in the list.
            list.Add(1);

            // Evaluate
            //      1. Count = 1
            //      2. Method should return true
            //      3. Count = 0
            list.Count.Should().Be(1);

            list.Remove(1).Should().BeTrue();
            list.Count.Should().Be(0);
        }

        [TestMethod]
        public void RemoveFirstItemTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();

            // TEST: Remove the first of many nodes in the list.
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);

            // Evaluate
            //      1. Count = 4
            //      2. First item.value = 1
            //      2. Method should return true
            //      3. Count = 3
            //      4. First item.value = 2
            list.Count.Should().Be(4);
            list.First.Value.Should().Be(1);
            list.Remove(1).Should().BeTrue();
            list.Count.Should().Be(3);
            list.First.Value.Should().Be(2);
        }

        [TestMethod]
        public void RemoveMiddleItemTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();

            // TEST: Remove the middle node in the list.
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Evaluate
            //      1. Count = 3
            //      2. First.Next.Value = 2
            //      3. Method should return true
            //      4. Count = 2
            //      5. First.Next.Value = 3
            list.Count.Should().Be(3);
            list.First.Next.Value.Should().Be(2);
            list.Remove(2).Should().BeTrue();
            list.Count.Should().Be(2);
            list.First.Next.Value.Should().Be(3);
        }

        [TestMethod]
        public void RemoveLastItemTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();

            // TEST: Remove the last node in the list.
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // Evaluate
            //      1. Count = 3
            //      2. Last.Value = 3
            //      3. Method should return true
            //      4. Count = 2
            //      5. Last.Value = 2
            list.Count.Should().Be(3);
            list.Last.Value.Should().Be(3);
            list.Remove(3).Should().BeTrue();
            list.Count.Should().Be(2);
            list.Last.Value.Should().Be(2);
        }

        [TestMethod]
        public void ContainsItemTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // TEST: Find an existing item in the list.
            
            // Evaluate:
            //      1. Method should return true (item found)
            list.Contains(2).Should().BeTrue();

            // TEST: Try to find an item that does not exist.

            // Evaluate:
            //      1. Method shoudl return false (item not found)
            list.Contains(4).Should().BeFalse();
        }

        [TestMethod]
        public void EnumerateListTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // TEST: Enumeration functionality using foreach

            Int32 currentItem = 1;

            foreach (Int32 item in list)
            {
                // Evaluate
                //      1. item value should equal currentItem
                item.Should().Be(currentItem);

                currentItem++;
            }
        }

        [TestMethod]
        public void ClearListTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            // TEST: Clearing the list

            // Evaluate:
            //      1. First/Last != null, Count = 3
            //      2. After clearing, First/Last = null, Count = 0
            list.First.Should().NotBeNull();
            list.Last.Should().NotBeNull();
            list.Count.Should().Be(3);

            list.Clear();

            list.First.Should().BeNull();
            list.Last.Should().BeNull();
            list.Count.Should().Be(0);
        }

        [TestMethod]
        public void CopyToArrayTest()
        {
            LinkedList<Int32> list = new LinkedList<Int32>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            // TEST: Copy list to existing array.
            Int32[] array = new Int32[10] {1, 2, 3, 5, 8, 13, 21, 34, 55, 89};

            list.CopyTo(array, 5);

            // Evaluate:
            //      1. Last half of the array equals linked list values in order.
            Int32 index = 5;

            foreach (Int32 item in list)
            {
                array[index].Should().Be(item);
            }
        }
    }
}
