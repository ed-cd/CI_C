using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI
{
    class Three_3
    {
        public static void solveTowersOfHanoi(Stack<int> A, Stack<int> B, Stack<int> C)
        {
            Move(A.Count, A, B, C);
        }

        private static void Move(int n, Stack<int> source, Stack<int> target, Stack<int> auxilliary)
        {
            if (n == 0) return;
            Move(n - 1, source, auxilliary, target);
            target.Push(source.Pop());
            Move(n - 1, auxilliary, target, source);
        }
    }

    public static class MyExtensions
    {
        public static bool CheckTower(this Stack<int> stack, int expectedCount)
        {
            if (expectedCount != stack.Count) return false;
            var arr = stack.ToArray();
            for (var n = 0; n < expectedCount - 1; n++)
            {
                if (arr[n] >= arr[n + 1]) return false;
            }
            return true;
        }
    }
}