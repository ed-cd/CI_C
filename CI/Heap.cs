using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CI
{
    class Heap<T> where T:IComparable
    {

        public HeapNode<T> Root { get; set; }

        private void _Add(HeapNode<T> root, T value)
        {
//            root.Count++;
//            var valueToAdd = 
//            var leftCount = root.Left?.Count ?? 0;
//            var rightCount = root.Right?.Count ?? 0;
//            if (leftCount > rightCount)
//            {
//                if (root.Right == null)
//                {
//                    root.Right = new HeapNode<T>() {Count = 1, Value = value};
//                }
//                else
//                {
//                    _Add(root.Right,valu);
//                }
//
//            }
        }
    }

    public class HeapNode<T> where T:IComparable
    {
        public T Value { get; set; }
        public long Count { get; set; }
        public HeapNode<T> Left { get; set; }
        public HeapNode<T> Right { get; set; }
    }
}
