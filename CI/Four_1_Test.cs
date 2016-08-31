using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Four_1_Test
    {
        [TestMethod]
        public void TestMethod1() {
            var tree = new Tree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(0);
            tree.Add(1);
            Assert.IsTrue(tree.IsBalanced);
            tree.Add(1);      
            Assert.IsFalse(tree.IsBalanced);      
        }
    }
}
