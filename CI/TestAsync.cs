using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
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

        public static async void Test5Tasks(bool configureAwait = true)
        {
            await Task.WhenAll(TestBasicAsync(1111, "Task 1"), TestBasicAsync(1111, "Task 2"), TestBasicAsync(1111, "Task 3"),
                TestBasicAsync(1111, "Task 4"), TestBasicAsync(1111, "Task 5")).ConfigureAwait(false);
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

        Stopwatch sw = new Stopwatch();
        private async void bttnStart_Click(object sender, [CallerMemberName] string fname = null)
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
            sw.Restart();
            Task t1 = DoWorkAsync(Colors.Red, 0, 200);
            Task t2 = DoWorkAsync(Colors.Blue, 1, 300);
            Task t3 = DoWorkAsync(Colors.Green, 2, 500);
            await Task.WhenAll(t1, t2, t3);
            sw.Stop();
            txtStatus.Text = $"Finished after {sw.ElapsedMilliseconds}";
        }

        private void bttnClear_Click(object sender, RoutedEventArgs e)
        {
            theRootCanvas.Children.Clear();
        }

        private async Task DoWorkAsync(int taskNum, int delay)
        {
            for (var i = 0; i < 5; i++)
            {
                // perform some asynchronous task in various ways
                // await Task.Yield();       // yields immediately
                // await Task.Delay(0);      // continues synchronously
                // await Task.Delay(100);     // continues asynchronously on UI thread
                // await Task.Delay(0).ConfigureAwait(false);    // continues synchronously
                // await Task.Delay(100).ConfigureAwait(false);   // continues asynchronously on any thread

                var startTime = sw.ElapsedMilliseconds;

                // spin here for 'delay' milliseconds just to keep busy
                while (sw.ElapsedMilliseconds < startTime + delay) { /* do nothing */ }

                var endTime = sw.ElapsedMilliseconds;

                Dispatcher.BeginInvoke((Action)(() => AddTimeRectangle(
                                                startTime, endTime, color, taskNum)));
            }
        }

        /// <summary>
        /// add a rectangle that whose height & position represents the start and end time
        /// of an activity
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="color"></param>
        /// <param name="column"></param>
        private void AddTimeRectangle(double startTime, double endTime, Color color, int column)
        {
            const int columnWidth = 50;
            Debug.WriteLine("Adding Rect {0} {1} {2}", startTime, endTime, color);

            double left = column * (columnWidth * 2 / 3);
            double height = endTime - startTime;

            Rectangle r = new Rectangle()
            {
                Fill = new SolidColorBrush(color),
                Width = columnWidth,
                Height = height,
            };
            Canvas.SetLeft(r, left);
            Canvas.SetTop(r, startTime);

            theRootCanvas.Children.Add(r);

            if (theRootCanvas.Height < endTime)
            {
                theRootCanvas.Height = endTime;
            }
            if (theRootCanvas.Width < left + columnWidth)
            {
                theRootCanvas.Width = left + columnWidth;
            }
        }


    }
}
