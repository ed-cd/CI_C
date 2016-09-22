using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Four_6_Test
    {
        [TestMethod]
        public void TestMethod1() {
            var tree = new BinaryTreeWithBackLinks<float>();  
            tree.Add(4);
            tree.Add(2);
            tree.Add(6);
            tree.Add(1);
            tree.Add(3);
            tree.Add(5);
            tree.Add(7);
            tree.Add(2.5f);
            tree.Add(3.5f);
            tree.Add(4.5f);
            tree.Add(5.5f);
            Assert.AreEqual((tree.Root.Left as TreeNodeWithBackLink<float>).NextNodeInOrder().Value,2.5);
            Assert.AreEqual((tree.Root.Left.Left as TreeNodeWithBackLink<float>).NextNodeInOrder().Value, 2);
            Assert.AreEqual((tree.Root as TreeNodeWithBackLink<float>).NextNodeInOrder().Value, 4.5);
            Assert.AreEqual((tree.Root.Right as TreeNodeWithBackLink<float>).NextNodeInOrder().Value, 7);
            Assert.AreEqual((tree.Root.Right.Right as TreeNodeWithBackLink<float>).NextNodeInOrder(), null);
        }
    }
}
