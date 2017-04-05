using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    public enum AsyncType
    {
        // perform some asynchronous task in various ways
        // await Task.Yield();       // yields immediately
        // await Task.Delay(0);      // continues synchronously
        // await Task.Delay(100);     // continues asynchronously on UI thread
        // await Task.Delay(0).ConfigureAwait(false);    // continues synchronously
        // await Task.Delay(100).ConfigureAwait(false);   // continues asynchronously on any thread
        YieldImmediately,
        ContinueSynchronously,
        ContinueAsynchronouslyAfter100Ms,
        ConfigureAwaitTrue,
        ConfigureAwaitFalse
    }

    [TestClass]
    public class TestAsync
    {
        public static int counter;
        //https://blogs.msdn.microsoft.com/benwilli/2015/09/10/tasks-are-still-not-threads-and-async-is-not-parallel/
        [TestMethod]
        public void TestMethod1()
        {
        }

        public static async void Test5Tasks(bool configureAwait = true)
        {
            await TestAsyncType(AsyncType.YieldImmediately);
        }

        public static async Task TestBasicAsync(int delay, string name)
        {
            await Task.Delay(0);
            var sw = Stopwatch.StartNew();
            var start = sw.ElapsedMilliseconds;
            var duration = start + delay;
            while (sw.ElapsedMilliseconds < duration)
            {
            }
            var end = sw.ElapsedMilliseconds;
            var runTime = end - start;
            Console.WriteLine($"Task {name} completed in {runTime} milliseconds");
        }

        private static async Task TestAsyncType(AsyncType x)
        {
            var t1 = DoWorkAsync(1, 200, x);
            var t2 = DoWorkAsync(2, 200, x);
            var t3 = DoWorkAsync(3, 200, x);
            var t4 = DoWorkAsync(4, 200, x);
            var t5 = DoWorkAsync(5, 200, x);
            await Task.WhenAll(t1, t2, t3, t4, t5);
            Console.WriteLine($"All finished");
        }

        private static async Task DoWorkAsync(int taskNum, int delay, AsyncType type)
        {
            Console.WriteLine($"Task {taskNum} started");
            switch (type)
            {
                case AsyncType.YieldImmediately:
                    await Task.Yield();
                    break;
                case AsyncType.ContinueSynchronously:
                    await Task.Delay(0);
                    break;
                case AsyncType.ContinueAsynchronouslyAfter100Ms:
                    await Task.Delay(100);
                    break;
                case AsyncType.ConfigureAwaitTrue:
                    await Task.Delay(0).ConfigureAwait(false);
                    break;
                case AsyncType.ConfigureAwaitFalse:
                    await Task.Delay(100).ConfigureAwait(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            (delay*1000).nTimes(() => ++counter);

            Console.WriteLine($"Task {taskNum} finished");
        }
    }
}