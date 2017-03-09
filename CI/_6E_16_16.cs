using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class _6E_16_16
    {
        [TestMethod]
        public void TestMethod1()
        {
            var arr = new[] {1, 2, 4, 7, 10, 11, 7, 12, 6, 7, 16, 18, 19};
            var res = FindSmallestArrayThatNeedsToBeSorted(arr);
            Assert.AreEqual(res.Item1,3);
            Assert.AreEqual(res.Item2, 9);
        }

        public static Tuple<int, int> FindSmallestArrayThatNeedsToBeSorted(int[] arr)
        {
            var first = 0;
            for (var n = 1; n < arr.Length; n++)
            {
                if (arr[n] >= arr[n - 1]) continue;
                first = n;
                break;
            }
            var last = arr.Length-1;
            for (var n = last-1; n > first; n--)
            {
                if (arr[n] < arr[n + 1]) continue;
                last = n;
                break;
            }
            var smallest = arr[first];
            var largest = arr[last];
            Array.Sort(arr);
            return null;
        }
    }
}
