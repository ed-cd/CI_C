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

        public static async Task Test5Tasks(bool configureAwait = true)
        {
            await Task.WhenAll(TestBasicAsync(1111, "Task 1"), TestBasicAsync(1111, "Task 2"), TestBasicAsync(1111, "Task 3"),
                TestBasicAsync(1111, "Task 4"), TestBasicAsync(1111, "Task 5"));
        }

        public static async Task TestBasicAsync(int delay,string name)
        {
            await Task.Delay(0);
            var sw = Stopwatch.StartNew();
            var start = sw.ElapsedMilliseconds;
            var duration = start + delay;
            while (sw.ElapsedMilliseconds < duration) { }
            var end = sw.ElapsedMilliseconds;
            var runTime = end - start;
            Console.WriteLine($"Task {name} completed in {runTime} milliseconds");
        }
    }
}
