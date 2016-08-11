using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Three_5_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var queue = new QueueFromStacks<int>();

            queue.Push(1);
            queue.Push(2);
            queue.Push(3);
            queue.Pop();
            queue.Pop();
            queue.Push(4);
            queue.Push(5);

            /*Assert.AreEqual(queue.Pop(), 1);
            Assert.AreEqual(queue.Pop(), 2);*/
            Assert.AreEqual(queue.Pop(), 3);
            Assert.AreEqual(queue.Pop(), 4);
            Assert.AreEqual(queue.Pop(), 5);
        }
    }
}