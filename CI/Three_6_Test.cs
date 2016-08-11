using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Three_6_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var stack = new Stack<int>();
            stack.Push(6);
            stack.Push(7);
            stack.Push(3);
            stack.Push(2);
            stack.Push(5);
            stack.Push(4);
            stack.Push(1);
            Three_6.SortStackInAscendingOrder(stack);
            Assert.AreEqual(stack.Pop(), 7);
            Assert.AreEqual(stack.Pop(), 6);
            Assert.AreEqual(stack.Pop(), 5);
            Assert.AreEqual(stack.Pop(), 4);
            Assert.AreEqual(stack.Pop(), 3);
            Assert.AreEqual(stack.Pop(), 2);
            Assert.AreEqual(stack.Pop(), 1);
        }
    }
}