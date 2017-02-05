using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class _6E_16_6
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new[] {1, 15, 11, 2};
            var b = new[] {23, 127, 235, 19, 4, 12};
            var r = FindPairWithSmallestDifference(a, b);
/*            Assert.AreEqual(r.Item1,11);
            Assert.AreEqual(r.Item2,12);*/
        }


        public static Tuple<int, int> FindPairWithSmallestDifference(int[] a, int[] b)
        {
            Array.Sort(a);
            Array.Sort(b);

            var _a = 0;
            var _b = 0;

            var al = a.Length - 1;
            var bl = b.Length - 1;

            var smallest = Diff(a[_a], b[_b]);
            while (true)
            {
                if (_a < al)
                {
                    var diff = Diff(a[_a + 1], b[_b]);
                    if (diff < smallest)
                    {
                        smallest = diff;
                        _a++;
                        continue;
                    }
                    if (_b < bl)
                    {
                        diff = Diff(a[_a], b[_b + 1]);
                        if (diff < smallest)
                        {
                            smallest = diff;
                            _b++;
                            continue;
                        }
                    }
                }
                break;
            }
            return new Tuple<int, int>(a[_a], b[_b]);
        }

        private static int Diff(int x, int y)
        {
            return x > y ? x - y : y - x;
        }
    }
}