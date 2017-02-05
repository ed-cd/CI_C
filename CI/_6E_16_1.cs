using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class _6E_16_1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var numbers = new List<Tuple<int, int>>() {new Tuple<int, int>(12,47),new Tuple<int, int>(-12,47),new Tuple<int, int>(-12,-47),new Tuple<int, int>(12,-47)};
            numbers.ForEach(t =>
            {
                var old1 = t.Item1;
                var old2 = t.Item2;
                var new1 = old1;
                var new2 = old2;
                SwapInPlace1(ref new1, ref new2);
                Assert.AreEqual(old1,new2);
                Assert.AreEqual(old2,new1);
                SwapInPlace2(ref new1, ref new2);
                Assert.AreEqual(old1, new1);
                Assert.AreEqual(old2, new2);
            });
        }

        public void SwapInPlace1(ref int a, ref int b)
        {
            a = a - b;
            b = b + a;
            a = b - a;
        }

        public void SwapInPlace2(ref int a, ref int b)
        {
            a = a ^ b;
            b = b ^ a;
            a = b ^ a;
        }
    }
}
