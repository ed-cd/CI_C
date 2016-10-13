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

        public string getEquationThatBisectsBothSquares(Square anotherSquare) {
            var y2_minus_y1 = anotherSquare.Center.Y - Center.Y;
            var x2_minus_x1 = anotherSquare.Center.X - Center.X;
            if (x2_minus_x1 - x2_minus_x1 == 0) {
                return $"x = {Center.X}";
            }
            var multiplicator = y2_minus_y1/x2_minus_x1;
            return $"{multiplicator}*x + {Center.Y - Center.X*multiplicator}";
        }
    }
}