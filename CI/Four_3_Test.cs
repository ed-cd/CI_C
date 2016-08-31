using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI {
    [TestClass]
    public class Four_3_Test {
        [TestMethod]
        public void TestMethod1() {
            var tree = new BTree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(4);
            tree.Add(5);
            tree.Add(6);
            try {
                tree.Add(1);
                Assert.IsTrue(false);
            }
            catch (BTreeDuplicateException) {}
            Assert.IsTrue(tree.IsBalanced);
            Assert.IsTrue(tree.IsValid);
        }
    }
}