using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    struct FromTo
    {
        public int From;
        public int To;
    }

    [TestClass]
    public class _6E_16_17
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(FindContiguousSumNaive(new List<int>() {2, -8, 3, -2, 4, -10}), 5);
        }

        public static int FindContiguousSumNaive(List<int> list)
        {
            var greatest = list.FirstOrDefault();
            for (var n = 0; n < list.Count; n++)
            {
                _findContiguousSumNaive(list, new FromTo() {From = n, To = n}, new Dictionary<FromTo, bool>(),
                    ref greatest);
            }
            return greatest;
        }

        private static void _findContiguousSumNaive(List<int> list, FromTo fromTo,
            Dictionary<FromTo, bool> calculated, ref int largest)
        {
            if (calculated.ContainsKey(fromTo))
            {
                return;
            }
            calculated[fromTo] = true;
            var sum = list.GetRange(fromTo.From, fromTo.To - fromTo.From + 1).Sum();
            if (sum > largest)
            {
                largest = sum;
            }
            if (fromTo.From > 0)
            {
                fromTo.From--;
                
                _findContiguousSumNaive(list, fromTo, calculated, ref largest);
            }
            if (fromTo.To < list.Count-1)
            {
                fromTo.To++;
                _findContiguousSumNaive(list, fromTo, calculated, ref largest);
            }
        }
    }
}