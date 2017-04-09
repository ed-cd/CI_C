using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class FindBiggestSubArraySum
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(Find(new[] {-2, -5, 6, -2, -3, 1, 5, -6}), 7);
        }

        public static int Find(int[] arr)
        {
            var curMax = arr[0];
            var tMax = arr[0];
            foreach (var i in arr)
            {
                curMax = Math.Max(i, curMax + i);
                tMax = Math.Max(tMax, curMax);
            }
            return tMax;
        }
    }
}