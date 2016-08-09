using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class One_11_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var test = new One_11();
            Assert.AreEqual(test.X, true);
        }
    }
}
