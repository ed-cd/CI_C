using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Three_3_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = {5, 4, 3, 2, 1};
            var A = new Stack<int>(arr);
            var B = new Stack<int>();
            var C = new Stack<int>();
            var height = A.Count;
            Three_3.solveTowersOfHanoi(A, C, B);
            Assert.AreEqual(C.CheckTower(height), true);
        }
    }
}