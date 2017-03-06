using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class FindIntsThatSumTo
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pairs = findIntsThatSumTo(new[] {1, 2, 13, 3, 4, 5, -8, 5, 0,5,3,14,3},6);
            Assert.AreEqual(pairs.Count,4);
            
        }

        private List<Tuple<int, int>> findIntsThatSumTo(IEnumerable<int> arr,int target)
        {
            var result = new List<Tuple<int,int>>();
            var dict = new Dictionary<int,int>();
            foreach (var n in arr)
            {
                var complement = target - n;
                if (dict.ContainsKey(complement))
                {
                    if (dict[complement] == 1)
                    {
                        dict.Remove(complement);
                    }
                    else
                    {
                        dict[complement]--;
                    }
                    result.Add(new Tuple<int, int>(n,complement));
                }
                else
                    dict[n] = 1;
            }

            return result;
        }
    }
}