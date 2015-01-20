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
        public void AddItemTest()
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

            // TEST: Add item to the end of the list
            list.Add(2);

            // Evaluate
            //      1. Item was added (should be tail)
            //      2. Head != tail
            list.Count.Should().Be(2);
            list.Last.Should().Be(2);
            list.First.Next.Should().BeSameAs(list.Last);
        }

        [TestMethod]
        public void RemoveItemTest()
        {
            
        }
    }
}
