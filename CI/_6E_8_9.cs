using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class _6E_8_9
    {
        [TestMethod]
        public void TestMethod1()
        {
            var valid3 = new List<string>() {"((()))", "(()())", "(())()", "()(())", "()()()"};
            var generated3 = generateAllValidBracketPermutations(3);
            Assert.IsTrue(valid3.Select(str => generated3.Contains(str))
                .Aggregate(true, (memo, contains) => memo && contains));
        }

        public static IEnumerable<string> generateAllValidBracketPermutations(int n)
        {
            var list = new List<string>();
            _generateAllValidBracketPermutations("()", 1, n, 1, list);
            return list;
            throw new NotImplementedException();
        }

        private static void _generateAllValidBracketPermutations(string str, int level, int target, int pos,
            List<string> list)
        {
            if (level == target)
            {
                list.Add(str);
            }
            else
            {
                if (pos > 0)
                {
                    _generateAllValidBracketPermutations(str.Insert(pos - 1, "()"), level + 1, target, pos - 1, list);
                }
                _generateAllValidBracketPermutations(str.Insert(pos, "()"), level + 1, target, pos, list);
                if (pos < str.Length - 1)
                {
                    _generateAllValidBracketPermutations(str.Insert(pos + 1, "()"), level + 1, target, pos + 1, list);
                }
            }
        }
    }
}