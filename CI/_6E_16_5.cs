using System;
using System.Diagnostics.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class _6E_16_5
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public static int findTrailing0zOfFactorial(int factorialPower)
        {
            var fives = 0;
            for (var n = 2; n <= factorialPower; n++)
            {
                var tmp = n;
                while (tmp%5 == 0)
                {
                    fives++;
                    tmp /= 5;
                }
            }
            return fives;
        }
    }
}