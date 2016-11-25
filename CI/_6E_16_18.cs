using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class _6E_16_18
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(DoesMatch("catcatgocatgo", "aabab"));
        }

        public static bool DoesMatch(string str, string pattern)
        {
            if (pattern[0] == 'b')
            {
                pattern = pattern.Replace("b", "c").Replace("a", "b").Replace("c", "a");
            }

            for (var length = 1;; length++)
            {
                var a = pattern.Substring(0, length);
                var bPos = pattern.IndexOf("b");
                var b = "";
                if (bPos > 0)
                {
                    var posAfterB = -1;
                    var bs = 1;
                    for()
                }
                

            }
            throw new NotImplementedException();
        }

        private static bool _doesMatch(string str, string pattern, string a, string b,bool single)
        {
            throw new NotImplementedException();
        }
    }
}
