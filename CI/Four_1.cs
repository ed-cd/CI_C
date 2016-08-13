using System;
using System.Diagnostics;

namespace CI
{
    [DebuggerDisplay("Value = {Value}")]
    public class TreeNode<T> where T : IComparable
    {
        public T Value { get; set; }
        public TreeNode<T> Left = null;
        public TreeNode<T> Right = null;

        public TreeNode(T value)
        {
            Value = value;
        }

        public static bool operator <(TreeNode<T> left, TreeNode<T> right)
        {
            return left.Value.CompareTo(right.Value) < 0;
        }

        public static bool operator >(TreeNode<T> left, TreeNode<T> right)
        {
            return !(left < right);
        }
    }

    public class Btree<T> where T : IComparable
    {
        private TreeNode<T> _root;

        public void Add(T value)
        {
            var nodeToAdd = new TreeNode<T>(value);
            _root = Add(nodeToAdd, _root);
        }

        private static TreeNode<T> Add(TreeNode<T> nodeToAdd, TreeNode<T> root)
        {
            if (root == null)
            {
                return nodeToAdd;
            }
            if (nodeToAdd < root)
            {
                root.Left = Add(nodeToAdd, root.Left);
            }
            else
            {
                root.Right = Add(nodeToAdd, root.Right);
            }
            return root;
        }

        public bool IsBalanced()
        {
            return _isBalanced(_root) != -1;
        }

        private int _isBalanced(TreeNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }
            var leftDepth = _isBalanced(root.Left);
            var rightDepth = _isBalanced(root.Right);
            if (leftDepth == -1 || rightDepth == -1 || Math.Abs(leftDepth - rightDepth) > 1)
            {
                return -1;
            }
            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }
}