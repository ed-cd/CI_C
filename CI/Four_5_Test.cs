using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Four_5_Test
    {
        [TestMethod]
        public void TestMethod1() {
            var tree= new Tree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(0);
            tree.Add(3);
            Assert.IsTrue(tree.IsValid);
            tree.Root.Left.Left = new TreeNode<int>(3);
            Assert.IsFalse(tree.IsValid);
        }
    }
}
