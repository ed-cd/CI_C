using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI {
    [TestClass]
    public class Four_4_Test {
        [TestMethod]
        public void TestMethod1() {
            var tree = new Tree<int>();
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);
            tree.Add(0);
            tree.Add(1);
            tree.Add(1);
            tree.Add(0);
            var nodes = Four_4.getNodesByDepth(tree);
            Assert.IsTrue(nodes[0].ListEquals(new LinkedList<int>(new int[] {1})));
            Assert.IsTrue(nodes[1].ListEquals(new LinkedList<int>(new int[] {0, 2})));
            Assert.IsTrue(nodes[2].ListEquals(new LinkedList<int>(new int[] {0, 1, 3})));
            Assert.IsTrue(nodes[3].ListEquals(new LinkedList<int>(new int[] {1})));
        }
    }
}