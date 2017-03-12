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
            Assert.AreEqual(res.Item1, 4);
            Assert.AreEqual(res.Item2, 9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var arr = new[] {1, 2, 4, 7, 10, 11, 8, 12, 5, 6, 16, 18, 19};
            var res = FindSmallestArrayThatNeedsToBeSorted(arr);
            Assert.AreEqual(res.Item1, 4);
            Assert.AreEqual(res.Item2, 9);
        }

        public static Tuple<int, int> FindSmallestArrayThatNeedsToBeSorted(int[] arr)
        {
            var first = -1;
            for (var n = 1; n < arr.Length; n++)
            {
                if (arr[n] < arr[n - 1])
                {
                    first = n;
                    break;
                }
            }
            if (first == -1) return new Tuple<int, int>(-1, -1); //array sorted
            var last = arr.Length - 1;
            for (var n = last - 1; n > first; n--)
            {
                if (arr[n] > arr[n + 1])
                {
                    last = n;
                    break;
                }
            }
            var smallest = arr[first];
            var largest = arr[last];
            for (var n = first; n <= last; n++)
            {
                if (arr[n] < smallest) smallest = arr[n];
                if (arr[n] > largest) largest = arr[n];
            }
            while (first >= 1 && smallest < arr[first - 1] || last <= arr.Length - 2 && largest > arr[last + 1])
            {
                if (smallest < arr[first - 1])
                {
                    first--;
                    if (arr[first] > largest) largest = arr[first];
                }
                if (largest > arr[last + 1])
                {
                    last++;
                    if (arr[last] > smallest) smallest = arr[last];
                }
            }
            return new Tuple<int, int>(first, last);
        }
    }
}