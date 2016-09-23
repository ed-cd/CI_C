using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI {
    [TestClass]
    public class Four_7_test {
        [TestMethod]
        public void TestMethod1() {
            var node40 = new TreeNodeWithBackLink<int>(40, null);
            var node20 = new TreeNodeWithBackLink<int>(20, node40);
            var node60 = new TreeNodeWithBackLink<int>(60, node40);
            node40.Left = node20;
            node40.Right = node60;
            var node10 = new TreeNodeWithBackLink<int>(10, node20);
            node20.Left = node10;
            var node30 = new TreeNodeWithBackLink<int>(30, node20);
            node20.Right = node30;
            var node25 = new TreeNodeWithBackLink<int>(25, node30);
            node30.Left = node25;

            Assert.AreEqual(TreeNodeWithBackLink<int>.GetClosestMutualAncestorNode(node10, node25), node20);
            Assert.AreEqual(TreeNodeWithBackLink<int>.GetClosestMutualAncestorNode(node10, node30), node20);
            Assert.AreEqual(TreeNodeWithBackLink<int>.GetClosestMutualAncestorNode(node10, node20), node20);
            Assert.AreEqual(TreeNodeWithBackLink<int>.GetClosestMutualAncestorNode(node60, node25), node40);
        }
    }
}