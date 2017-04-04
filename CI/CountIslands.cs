using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class CountIslands
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mtx = new bool[4][]
            {
                new [] {true, false, false, false},
                new [] {true, false, true, false},
                new [] {false, false, true, false},
                new [] {true, false, false, false}
            };
            Assert.AreEqual(3,_countIslands(mtx));
        }

        private int _countIslands(bool[][] arr)
        {
            var count = 0;
            for (var r = 0; r < arr.Length; r++)
                for (var c = 0; c < arr[0].Length; c++)
                {
                    if (arr[r][c]) count++;
                    _explore(r,c,arr);
                }
            return count;
        }

        private void _explore(int r, int c, bool[][] arr)
        {
            if (arr[r][c])
            {
                arr[r][c] = false;
                if (r >= 1) _explore(r - 1, c, arr);
                if (r <= arr.Length - 2) _explore(r + 1, c, arr);
                if (c >= 1) _explore(r, c - 1, arr);
                if (c <= arr[0].Length - 2) _explore(r, c + 1, arr);
            }
        }
    }
}