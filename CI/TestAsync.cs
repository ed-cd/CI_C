using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class TestAsync
    {
        //https://blogs.msdn.microsoft.com/benwilli/2015/09/10/tasks-are-still-not-threads-and-async-is-not-parallel/
        [TestMethod]
        public void TestMethod1()
        {
        }

        private async Task _testBasicAsync(int delay)
        {
            var stopWatch = new Stopwatch();
        }
    }
}
