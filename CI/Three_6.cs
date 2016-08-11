using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI
{
    class Three_6
    {
        public static void SortStackInAscendingOrder<T>(Stack<T> myStack) where T : IComparable {
            var auxillary = new Stack<T>();
            var rightStack = true;
            var sortNeeded = true;
            if (myStack.Count == 0) return;
            while (sortNeeded)
            {
                if (rightStack)
                {
                    sortNeeded = Sieve(myStack, auxillary, true);
                    rightStack = false;
                }
                else
                {
                    sortNeeded = Sieve(auxillary, myStack, false);
                    rightStack = true;
                }
            }
            if (!rightStack)
            {
                Sieve(auxillary, myStack, false);
            } 
        }

        private static bool Sieve<T>(Stack<T> fromStack, Stack<T> toStack, bool ascending) where T:IComparable
        {
            var toCompare = fromStack.Pop();
            var sortNeeded = false;
            while (fromStack.Count > 0)
            {
                var top = fromStack.Pop();
                if (ascending)
                {
                    if (top.CompareTo(toCompare) > 0)
                    {
                        toStack.Push(top);
                        sortNeeded = true;
                    }
                    else
                    {
                        toStack.Push(toCompare);
                        toCompare = top;
                    }
                }
                else
                {
                    if (top.CompareTo(toCompare) <= 0) {
                        toStack.Push(top);
                        sortNeeded = true;
                    }
                    else {
                        toStack.Push(toCompare);
                        toCompare = top;
                    }
                }
            }
            toStack.Push(toCompare);
            return sortNeeded;
        }
    }
}
