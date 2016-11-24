using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class _6E_16_2
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        int getFrequency(string[] book, string word, ref Dictionary<string,int> hash)
        {
            if (!hash.ContainsKey(word.ToLower()))
            {
                hash[word.ToLower()] = book.Aggregate(0,
                    (count, currentWord) => count + currentWord.ToLower() == word.ToLower() ? 1 : 0);
            }
            return hash[word.ToLower()];
        }


    }
}
