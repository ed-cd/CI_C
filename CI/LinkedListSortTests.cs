using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class LinkedListSortTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = new SinglyLinkedList<int>(new[] {3, 1, -3, 6, 9, 4, 2, -11, 12, 14, 15});
            data.InsertionSort();
            
        }

        [TestMethod]
        public void TestMethod2()
        {
            var data = new SinglyLinkedList<int>(new[] {3, 1, -3, 6, 9, 4, 2, -11, 12, 14, 15});
            data.MergeSort();
            Assert.IsTrue(data.ToEnumerable().SequenceEqual(new[] { -11, -3, 1, 2, 3, 4, 6, 9, 12, 14, 15 }));
        }
    }
}