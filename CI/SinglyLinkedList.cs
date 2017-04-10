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
    public class SinglyLinkedList<T>:IComparable where T : IComparable
    {
        public Node Head;
        public Node Tail;
        public int Count;
        public SinglyLinkedList() { }

        public SinglyLinkedList(IEnumerable<T> e)
        {
            Add(e);
        }

        public string FormatForDebugger()
        {
            var sb = new StringBuilder();
            foreach (var t in ToEnumerable())
            {
                sb.Append(t + ",");
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

        public void AddLast(T val)
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
                AddLast(x);
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
            Count++;
        }

        public void MergeSort()
        {
            var list = new SinglyLinkedList< SinglyLinkedList<T>>();
            foreach (var t in ToEnumerable())
            {
                var toAdd = new SinglyLinkedList<T>();
                toAdd.AddLast(t);
                list.AddLast(toAdd);
            }
            
            while (list.Count > 1)
            {
                var newList = new SinglyLinkedList<SinglyLinkedList<T>>();
                var runner = list.Head;
                while (runner != null)
                {
                    var merged = _mergeSortedLists(runner.Val, runner.Next?.Val);
                    newList.AddLast(merged);
                    runner = runner.Next?.Next;
                }
                list = newList;
            }
            Head = list.Head.Val.Head;
            Tail = list.Head.Val.Tail;
        }

        private SinglyLinkedList<T> _mergeSortedLists(SinglyLinkedList<T> l1, SinglyLinkedList<T> l2)
        {
            /*if (l2 != null)
            {
                if (l2.Tail.Val.CompareTo(l1.Head.Val) < 1)
                {
                    l2.Tail.Next = l1.Head;
                    l1.Head = l2.Head;
                }
                else if (l1.Tail.Val.CompareTo(l2.Head.Val) < 1)
                {
                    l1.Tail.Next = l2.Head;
                }
                else
                {
                    
                }
            }
            return l1;*/
            var r1 = l1.Head;
            var r2 = l2?.Head;
            var newList = new SinglyLinkedList<T>();
            while (r1 != null || r2 != null)
            {
                if (r1 == null || r2?.Val.CompareTo(r1.Val) < 1)
                {
                    newList.Add(r2);
                    r2 = r2.Next;
                }
                else if (r2 == null || r1.Val.CompareTo(r2.Val) < 1)
                {
                    newList.Add(r1);
                    r1 = r1.Next;
                }
            }
            return newList;
        }

        public void InsertionSort()
        {
            if (Count < 2) return;
            var dummy = new Node {Next = Head, Val = default(T)};
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

        public int CompareTo(object obj)
        {
            return 0;
        }
    }
}