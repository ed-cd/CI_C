using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI {
    [TestClass]
    class Seven_6 {
        [TestMethod]
        public void TestMethod1() {}

        public static double findNthIn357sequence(int N) {
            var lookup = new List<int>() {0, 3};
            var n = 1;
            var sum = 0;
            while (true) {
                sum += _findCombinations(n, lookup);
                if (sum >= N) {
                    break;
                }
                n++;
            }
            var targetCOunt = sum - N;
            var count = 0;

            var _3 = n;
            var _5 = 0;
            var _7 = 0;
            for (; _3 >= 0; _3--) {
                for (_5 = n - _3; _5 >= 0; _5--) {
                    _7 = n - _3 - _5;
                    if (++count == targetCOunt) goto Finish;
                }
            }
            Finish:
            return (Math.Pow(3, _3)*Math.Pow(5, _5)*Math.Pow(7, _7));
        }

        private static int _findCombinations(int n, List<int> lookup) {
            if (lookup.Count < n + 1) {
                lookup.Add(n + 1 + _findCombinations(n - 1, lookup));
            }
            return lookup[n];
        }
    }
}