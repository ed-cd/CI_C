using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI {
    [TestClass]
    public class Seven_3_Test {
        [TestMethod]
        public void TestMethod1() {
            Assert.AreEqual(7-3,7.mySubtract(3));
            Assert.AreEqual(7 - 9, 7.mySubtract(9));
            Assert.AreEqual(7 + 9, 7.mySubtract(-9));
            Assert.AreEqual(-7 + 9, 7.mySubtract(9));

            Assert.AreEqual(7 * 3, 7.myMultiply(3));
            Assert.AreEqual(7 * -3, 7.myMultiply(-3));
            Assert.AreEqual(-7 * 3, -7.myMultiply(3));
            Assert.AreEqual(-7 * -3, -7.myMultiply(-3));

            Assert.AreEqual(7 / 3, 7.myDivide(3));
            Assert.AreEqual(7 / -3, 7.myDivide(-3));
            Assert.AreEqual(-7 / 3, -7.myDivide(3));
            Assert.AreEqual(-7 / -3, 7.myDivide(-3));
        }
    }

    public static class Seven_3_Extensions {
        public static int mySubtract(this int n1, int n2) {
            var twosCompliment = ~n2 + 1;
            return n1 + twosCompliment;
        }

        public static int myMultiply(this int n1, int n2) {
            if (n1 == 0 || n2 == 0) {
                return 0;
            }
            var result = n1;
            if (n1 > 0) {
                if (n2 > 0) {
                    for (var n = 0; n < n2 - 1; n++) {
                        result += n1;
                    }
                } else {
                    result = 0.mySubtract(n1);
                    n2 = 0.mySubtract(n2);
                    for (var n = 0; n < n2 - 1; n++) {
                        result = result.mySubtract(n1);
                    }
                }
            } else {
                if (n2 > 0) {
                    for (var n = 0; n < n2 - 1; n++) {
                        result = result.mySubtract(n1);
                    }
                }
            }
            return result;
        }

        public static int myDivide(this int n1, int n2) {
            var n = 0;
            if (n1 > 0) {
                for (; n1 > 0; n++) {
                    n1 = n1.mySubtract(n2);
                }
            } else {
                for (; n1 < 0; n++) {
                    n1 += n2;
                }
            }
            return n;
        }
    }
}