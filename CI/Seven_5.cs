using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CI {
    [TestClass]
    public class Seven_5 {
        [TestMethod]
        public void TestMethod1() {}
    }

    public class Square {
        public Point corner1, corner2, corner3, corner4;

        public Point Center => new Point((corner1.X + corner3.X)/2, (corner1.Y + corner3.Y)/2);
    }
}