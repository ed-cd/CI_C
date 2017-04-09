using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CI
{
    [DebuggerDisplay("{FormatForDebugger()}")]
    public class SinglyLinkedList<T> where T : IComparable
    {
        public Node Head;
        public Node Tail;
        public int Count;

        public SinglyLinkedList(IEnumerable<T> e)
        {
            Add(e);
        }

        public string FormatForDebugger()
        {
            var sb = new StringBuilder();
            foreach (var t in ToEnumerable())
            {
                sb.Append(t+",");
            }
            return sb.ToString();
        }

        public void AddFirst(T val)
        {
            var nodeToAdd = new Node {Val = val};
            if (Count == 0)
            {
                Head = nodeToAdd;
                Tail = Head;
            }
            else
            {
                nodeToAdd.Next = Head;
                Head = nodeToAdd;
            }
            Count++;
        }

        public void Addlast(T val)
        {
            var nodeToAdd = new Node {Val = val};
            if (Count == 0)
            {
                Head = nodeToAdd;
                Tail = Head;
            }
            else
            {
                Tail.Next = nodeToAdd;
                Tail = nodeToAdd;
            }
            Count++;
        }

        public void Add(IEnumerable<T> e)
        {
            foreach (var x in e)
            {
                Addlast(x);
            }
        }

        public void Add(Node n)
        {
            if (Count == 0)
            {
                Head = n;
                Tail = n;
            }
            else
            {
                Tail.Next = n;
                Tail = n;
            }
        }
       

        public void InsertionSort()
        {
            if (Count < 2) return;
            var dummy = new Node { Next = Head, Val = default(T) };
            dummy.Next = Head;
            var runner = dummy;
            while (runner.Next != null)
            {
                if (!_tryToInsert(runner, runner.Next))
                {
                    runner = runner.Next;
                }
            }
            Head = dummy.Next;
        }

        private static bool _tryToInsert(Node first, Node second)
        {
            while (true)
            {
                if (second.Next == null) return false;
                if (second.Val.CompareTo(second.Next.Val) < 1)
                {
                    first = second;
                    second = second.Next;
                }
                else break;
            }
            var tmp = second.Next.Next;
            first.Next = second.Next;
            second.Next.Next = second;
            second.Next = tmp;
            return true;
        }

        public LinkedList<T> Merge(LinkedList<T> l1, LinkedList<T> l2)
        {
            return null;
        }


        public IEnumerable<T> ToEnumerable()
        {
            var runner = Head;
            while (runner != null)
            {
                yield return runner.Val;
                runner = runner.Next;
            }
        }

        [DebuggerDisplay("{Val}")]
        public class Node
        {
            public T Val { get; set; }
            public Node Next { get; set; } = null;
        }
    }
}