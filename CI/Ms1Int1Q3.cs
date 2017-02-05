using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Ms1Int1Q3
    {
        [TestMethod]
        public void TestMethod1()
        {
            var tree = new Tree<char>();
            tree.Add('F');
            tree.Add('B');
            tree.Add('G');
            tree.Add('A');
            tree.Add('D');
            tree.Add('I');
            tree.Add('C');
            tree.Add('E');
            tree.Add('H');
            var inOrderList = new List<char>() {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I'};
            var preOrderList = new List<char>() {'F', 'B', 'A', 'D', 'C', 'E', 'G', 'I', 'H'};
            var postOrderList = new List<char>() {'A', 'C', 'E', 'D', 'B', 'H', 'I', 'G', 'F'};
            var result = tree.InOrderTraversal;
            Assert.IsTrue(result.SequenceEqual(inOrderList));
            result = tree.PreOrderTraversal;
            Assert.IsTrue(result.SequenceEqual(preOrderList));
            result = tree.PostOrderTraversal;
            Assert.IsTrue(result.SequenceEqual(postOrderList));
            var reconstructedTree = Tree<char>.ReconstructFromInorderAndPostOrder(tree.InOrderTraversal, tree.PostOrderTraversal);
            Assert.IsTrue(reconstructedTree.InOrderTraversal.SequenceEqual(inOrderList));
            Assert.IsTrue(reconstructedTree.PostOrderTraversal.SequenceEqual(postOrderList));
            Assert.IsTrue(reconstructedTree.PreOrderTraversal.SequenceEqual(preOrderList));
            Assert.IsTrue(reconstructedTree == tree);

            var testArray = new int[] { 5, 3, 6, 4, 2, 9, 1, 8, 7 };
            //Quicksort(testArray);
            var x = 1;
        }

        public static void Quicksort(IList<int> data,int from = 0, int to = -1)
        {
            if (to < 0) to = data.Count;
            if (to == from) return;
            int pivot = from + (to - from) / 2;

            while (from != pivot || to != pivot)
            {
                if (data[from] > data[pivot] && data[to] <= data[pivot])
                {
                    data.Swap(from, to);
                } else if(data[from] <= data[pivot] && data[to] <= data[pivot])
                {
                    data.Swap(pivot, to);
                }
                else if (data[from] > data[pivot] && data[to] > data[pivot])
                {
                    data.Swap(pivot, from);
                }
                if (from < pivot) from++;
                if (to > pivot) to--;
            }
            Quicksort(data, from, pivot);
            Quicksort(data, pivot, to);
            ;
        }
    }

    public static class IListExtensions
    {
        public static void Swap<T>(this IList<T> list,int A, int B)
        {
            var temp = B;
            B = A;
            A = temp;
        }
    }
}