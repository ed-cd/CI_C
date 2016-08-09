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
            const string original1 = "AABABBA";
            const string rotation1 = "BABBAAA";
            const string notRotation1А = "BABBAAB";
            const string notRotation1Б = "АABBAAB";
            const string original2 = "abcdefgh";
            const string rotation2A = "abcdefgh";
            const string rotation2B = "habcdefg";
            const string notRotation2A = "abcdefah";
            const string notRotation2B = "hahcdefg";
            Assert.AreEqual(One_11.IsRotation(original1, rotation1), true);
            Assert.AreEqual(One_11.IsRotation(original1, notRotation1А), false);
            Assert.AreEqual(One_11.IsRotation(original1, notRotation1Б), false);
            Assert.AreEqual(One_11.IsRotation(original2, rotation2A), true);
            Assert.AreEqual(One_11.IsRotation(original2, rotation2B), true);
            Assert.AreEqual(One_11.IsRotation(original2, notRotation2A), false);
            Assert.AreEqual(One_11.IsRotation(original2, notRotation2B), false);
        }
    }
}
