using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class _6E_8_10
    {
        [TestMethod]
        public void TestMethod1()
        {
            for (var n = 0; n < 42; n++)
            {
                Assert.IsTrue(findAllWays(n)==findAllWays2(n));
                Assert.IsTrue(findAllWays(n)==findAllWays3(n,new Dictionary<int, int>()));
            }
        }

        public static int findAllWays(int n)
        {
            var total = 0;
            _findAllWays(0, new[] {25, 10, 5, 1}, n, ref total);
            return total;
        }

        private static void _findAllWays(int current, int[] denominations, int target, ref int total)
        {
            if (current == target)
            {
                total++;
            }
            else if (current < target)
            {
                foreach (var denomination in denominations)
                {
                    _findAllWays(current + denomination, denominations, target, ref total);
                }
            }
        }

        public static int findAllWays2(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            if (n > 0)
            {
                return findAllWays2(n - 25) + findAllWays2(n - 10) + findAllWays2(n - 5) + findAllWays2(n - 1);
            }
            return 0;
        }
        public static int findAllWays3(int n,Dictionary<int,int> hash )
        {
            if (hash.ContainsKey(n))
            {
                return hash[n];
            }
            if (n == 0)
            {
                return 1;
            }
            if (n > 0)
            {                
                var ret = findAllWays2(n - 25) + findAllWays2(n - 10) + findAllWays2(n - 5) + findAllWays2(n - 1);
                if (!hash.ContainsKey(n))
                {
                    hash[n] = ret;
                }
                return ret;
            }
            return 0;
        }
    }
}