using System;
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

            var x = 1;
        }
    }
}
