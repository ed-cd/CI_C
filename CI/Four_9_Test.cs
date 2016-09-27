using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI {
    [TestClass]
    public class Four_9_Test {
        [TestMethod]
        public void TestMethod1() {
            var tree = new Tree<int>();
            tree.Add(40);
            tree.Add(20);
            tree.Add(60);
            tree.Add(10);
            tree.Add(30);
            tree.Add(50);
            tree.Add(70);
            tree.Add(25);
            tree.Add(35);
            tree.Add(45);
            tree.Add(55);
            var sumTo100 = tree.GetAllPathsThatSumTo(100);
            Assert.IsTrue(sumTo100[0].AsString() == "40,60");
            var sumTo65 = tree.GetAllPathsThatSumTo(65);
            Assert.IsTrue(sumTo65[0].AsString() == "30,35");
            var sumTo90 = tree.GetAllPathsThatSumTo(90);
            Assert.IsTrue(sumTo90[0].AsString() == "40,20,30");
        }
    }
}