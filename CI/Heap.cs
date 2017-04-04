using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI
{
    public class Heap<T> where T : IComparable
    {
        private IComparer<T> _comparer;


        public Heap(IComparer<T> comparer = null)
        {
            _comparer = comparer ?? new DefaultComparer();
        }

        public HeapNode<T> Root { get; set; }

        private void _Add(HeapNode<T> root, HeapNode<T> nodeToAdd)
        {
//            var nodeToAdd = new HeapNode<T>() {Count = 0,Left = null,Right = null,Prev = null,Value = value};
            T valueToAdd;
            var leftCount = root.Left?.Count ?? 0;
            var rightCount = root.Right?.Count ?? 0;
            var comparison = nodeToAdd.Value.CompareTo(root.Value);
            if (comparison > 0)
            {              
                nodeToAdd.Value = root.Value;
                nodeToAdd.Left = root.Left;
                nodeToAdd.Right = root.Right;
                nodeToAdd.Count = root.Count;
            }
        }

        private class DefaultComparer : IComparer<T>
        {
            public int Compare(T x, T y)
            {
                return x.CompareTo(y);
            }
        }
    }

    public class HeapNode<T> where T : IComparable
    {       
        public T Value { get; set; }
        public long Count { get; set; }
        public HeapNode<T> Left { get; set; }
        public HeapNode<T> Right { get; set; }
        public int Age { get; set; }
    }
}