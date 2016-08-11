using System;
using System.Collections.Generic;

namespace CI
{
    public class QueueFromStacks<T>
    {
        Stack<T> stack1 = new Stack<T>();
        Stack<T> stack2 = new Stack<T>();
        private bool canPop = false;

        public void Push(T data)
        {
            if (canPop)
            {
                while (stack2.Count > 0)
                {
                    stack1.Push(stack2.Pop());
                }
            }
            stack1.Push(data);
            canPop = false;
        }

        public T Pop()
        {
            if (!canPop)
            {
                while (stack1.Count > 0)
                {
                    stack2.Push(stack1.Pop());
                }
                canPop = true;
            }
            if (stack2.Count > 0)
            {
                return stack2.Pop();
            }
            else
            {
                throw new EmptyQueueException();
            }
        }

        class EmptyQueueException : Exception
        {
        }
    }
}