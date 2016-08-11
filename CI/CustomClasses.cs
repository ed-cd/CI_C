using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI
{
    public class EmptyStackException : Exception
    {
    }
    public class SetOfStacks<T> where T : IComparable
    {
        private List<MyStack<T>> Stacks { get; set; }
        private uint MaxStackSize { get; set; }

        public SetOfStacks(uint maxStackSize) {
            this.MaxStackSize = maxStackSize;
            Stacks = new List<MyStack<T>>();
        }

        public void push(T value) {
            if (Stacks.Count == 0) {
                var firstStack = new MyStack<T>();
                firstStack.push(value);
                Stacks.Add(firstStack);
            }
            else {
                if (Stacks.Last().Count < MaxStackSize) {
                    Stacks.Last().push(value);
                }
                else {
                    var newStack = new MyStack<T>();
                    newStack.push(value);
                    Stacks.Add(newStack);
                }
            }
        }

        public bool CanPop => Stacks.Count > 0;

        public int NumberOfStacks => Stacks.Count;

        public T pop() {
            if (!CanPop) {
                throw new EmptyStackException();
            }
            else {
                var lastStack = Stacks.Last();
                var value = lastStack.pop();
                if (!lastStack.CanPop) {
                    Stacks.RemoveAt(Stacks.Count - 1);
                }
                return value;
            }
        }

        public T PopAt(int stackNumber) {
            if (stackNumber > Stacks.Count - 1) {
                throw new EmptyStackException();
            }
            else {
                var stack = Stacks[stackNumber];
                var value = stack.pop();
                if (!stack.CanPop) {
                    Stacks.RemoveAt(stackNumber);
                }
                return value;
            }
        }
    }

    public class MyStack<T> where T : IComparable
    {
        class Node<T> where T : IComparable
        {
            public Node<T> Next { get; set; }
            public T Value { get; set; }
            public T Min;
        }

        private Node<T> stack = null;
        public int Count { get; private set; }

        public void push(T value) {
            stack = new Node<T>
            {
                Next = stack,
                Value = value,
                Min = stack == null ? value : value.CompareTo(stack.Min) < 0 ? value : stack.Min
            };
            Count++;
        }

        public T pop() {
            if (stack != null) {
                Count--;
                var value = stack.Value;
                stack = stack.Next;
                return value;
            }
            else {
                throw new EmptyStackException();
            }
        }

        public bool CanPop => stack != null;

        public T Min => stack.Min;
    }
}
