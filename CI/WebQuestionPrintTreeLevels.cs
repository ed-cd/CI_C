using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class WebQuestionPrintTreeLevels
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tree = new Tree<string>();
            tree.Add("F");
            tree.Add("B");
            tree.Add("G");
            tree.Add("A");
            tree.Add("D");
            tree.Add("C");
            tree.Add("E");
            tree.Add("I");
            tree.Add("H");
            var x = tree.By_LevelTraversal;

            Assert.IsTrue(x.SequenceEqual(new List<string>() {"F", "B", "G", "A", "D", "I", "C", "E", "H"}));
        }
    }
}
