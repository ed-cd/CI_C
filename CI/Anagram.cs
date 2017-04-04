using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Anagram
    {
        //aaa-bbb - 3
        //a-b     - 1       
        //mn-op   - 2
        //xyyx    - 0
        //xaxb bbxx - 1
        // Find the minimum number of characters of the first string that we need to change in order to make it an anagram of the second string.
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(ToMakeAnagram("aaa", "bbb"), 3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(ToMakeAnagram("a", "b"), 1);
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.AreEqual(ToMakeAnagram("mn", "op"), 2);
        }[TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(ToMakeAnagram("xy", "yx"), 0);
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual(ToMakeAnagram("xaxb", "bbxx"), 1);
        }

        private static int ToMakeAnagram(string s1, string s2) //strings will have equal lengths
        {
//The given string will contain only characters from  to .
            if (s1.Length != s2.Length || s1.Length < 1)
            {
                throw new Exception();
            }
            var arr = new int[26];
            foreach (var c in s1)
            {
                arr[c - 97]++;
            }
            foreach (var c in s2)
            {
                arr[c - 97]--;
            }
            var total = arr.Sum(Math.Abs);
            return total/2;
        }
    }
}