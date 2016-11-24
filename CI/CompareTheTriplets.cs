using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class CompareTheTriplets
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        public static void _main(string[] args)
        {
            var tokens_a0 = Console.ReadLine().Split(' ');
            var a = new int[3];
            a[0] = Convert.ToInt32(tokens_a0[0]);
            a[1] = Convert.ToInt32(tokens_a0[1]);
            a[2] = Convert.ToInt32(tokens_a0[2]);
            var tokens_b0 = Console.ReadLine().Split(' ');
            var b = new int[3];
            b[0] = Convert.ToInt32(tokens_b0[0]);
            b[1] = Convert.ToInt32(tokens_b0[1]);
            b[2] = Convert.ToInt32(tokens_b0[2]);
            var result = Compare(a, b);
            Console.WriteLine($"{result.Item1} {result.Item2}");
        }

        public static Tuple<int, int> Compare(int[] a, int[] b)
        {
            var Alice = 0;
            var Bob = 0;

            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    Alice++;
                }
                else if (a[i] < b[i])
                {
                    Bob++;
                }
            }
            return new Tuple<int, int>(Alice, Bob);
        }
    }
}