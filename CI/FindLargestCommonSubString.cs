using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class FindLargestCommonSubString
    {
        private const int a = 97;
        [TestMethod]
        public void TestMethod1()
        {
            var str1 = "geeksforgeeks";
            var str2 = "geeksquiz";
            Assert.AreEqual("geeks", _findLargestCommonSubString(str1,str2));
        }

        private static string _findLargestCommonSubString(string str1, string str2)
        {
            var largestSS = 0;
            var largestPosRow = 0;
            var arr = new int[str1.Length,str2.Length];
            var positions = new Dictionary<char,List<int>>();
            for (var n=0;n<str2.Length;n++)
            {
                var c = str2[n];
                if(positions.ContainsKey(c))
                    positions[c].Add(n);
                else
                {
                    positions.Add(c,new List<int> {n});
                }
            }
            for (var row = 0; row < str1.Length; row++)
            {
                var c = str1[row];
                if(!positions.ContainsKey(c)) continue;
                foreach (var col in positions[c])
                {
                    var prev = row > 0 && col > 0 ? arr[row - 1, col - 1]:0;
                    var num = prev + 1;
                    if (num > largestSS)
                    {
                        largestSS = num;
                        largestPosRow = row;
                    }
                    arr[row, col] = num;                    
                }
            }
            return str1.Substring(largestPosRow-largestSS,largestSS);
        }
    }
}
