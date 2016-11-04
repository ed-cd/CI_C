using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class E6_16_1_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = 7;
            var b = 11;

            Swap(ref a, ref b);
            Assert.AreEqual(a,11);
            Assert.AreEqual(b, 7);
            Swap2(ref a,ref b);
            Assert.AreEqual(a, 7);
            Assert.AreEqual(b, 11);
        }

        private static void Swap(ref int a, ref int b)
        {
            a = a ^ b;
            b = b ^ a;
            a = a ^ b;
        }
        private static void Swap2(ref int a, ref int b)
        {
            if (b >= a)
            {
                b = b - a;
                a = a + b;
                b = a - b;
            }
            else
            {
                a = a - b;
                b = a + b;
                a = b - a;
            }
        }

    }
}
