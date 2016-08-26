namespace CI {
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("Value = {Value}")]
    public class TreeNode<T>
        where T : IComparable {
        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public T Value { get; set; }

        public TreeNode(T value) {
            Value = value;
        }

        public static bool operator <(TreeNode<T> left, TreeNode<T> right) {
            return left.Value.CompareTo(right.Value) < 0;
        }

        public static bool operator >(TreeNode<T> left, TreeNode<T> right) {
            return !(left < right) && left != right;
        }
        public static bool operator <=(TreeNode<T> left, TreeNode<T> right) {
            return left < right || left == right;
        }
        public static bool operator >=(TreeNode<T> left, TreeNode<T> right) {
            return !(left < right);
        }

        public static bool operator ==(TreeNode<T> left, TreeNode<T> right) {
            return right != null && left?.Value.CompareTo(right.Value) == 0;
        }

        public static bool operator !=(TreeNode<T> left, TreeNode<T> right) {
            return !(left == right);
        }
    }

    public class Tree<T>
        where T : IComparable {
        public int Count { get; protected set; }

        protected TreeNode<T> Root { get; set; }

        public void Add(T value) {
            var nodeToAdd = new TreeNode<T>(value);
            Root = Add(nodeToAdd, Root);
            Count++;
        }

        public bool IsBalanced() {
            return getDepth(Root) != -1;
        }

        protected virtual TreeNode<T> Add(TreeNode<T> nodeToAdd, TreeNode<T> root) {
            if (root == null) {
                return nodeToAdd;
            }

            if (nodeToAdd < root) {
                root.Left = Add(nodeToAdd, root.Left);
            }
            else {
                root.Right = Add(nodeToAdd, root.Right);
            }

            return root;
        }

        protected static int getDepth(TreeNode<T> root) {
            if (root == null) {
                return 0;
            }

            var leftDepth = getDepth(root.Left);
            var rightDepth = getDepth(root.Right);
            if (leftDepth == -1 || rightDepth == -1 || Math.Abs(leftDepth - rightDepth) > 1) {
                return -1;
            }

            return Math.Max(leftDepth, rightDepth) + 1;
        }
    }

    public class BTree<T> : Tree<T>
        where T : IComparable {
        protected override TreeNode<T> Add(TreeNode<T> nodeToAdd, TreeNode<T> root) {
            if (root == null) {
                return nodeToAdd;
            }

            if (nodeToAdd == root) {
                throw new BTreeDuplicateException();
            }

            var dLeft = getDepth(root.Left);
            var dRight = getDepth(root.Right);
            if (dLeft == dRight) {
                if (nodeToAdd < root) {
                    root.Left = Add(nodeToAdd, root.Left);
                }
                else {
                    root.Right = Add(nodeToAdd, root.Right);
                }
                return root;
            }
            if (dLeft > dRight) {
                if (nodeToAdd >= root) {
                    root.Right = Add(nodeToAdd, root.Right);
                    return root;
                }
                if (nodeToAdd == root.Left) {
                    throw new BTreeDuplicateException();
                }
                if (nodeToAdd > root.Left) {
                    var temp = root.Value;
                    root.Value = nodeToAdd.Value;
                    nodeToAdd.Value = temp;
                    root.Right = Add(nodeToAdd, root.Right);
                    return root;
                }
                else {
                    var temp = root.Left.Value;
                    root.Left.Value = nodeToAdd.Value;
                    temp = root.Value;
                    root.Value = nodeToAdd.Value;
                    nodeToAdd.Value = temp;
                    root.Right = Add(nodeToAdd, root.Right);
                    return root;
                }
            }
            else {
                
            }

            if (nodeToAdd < root) {
                if (root.Left == null) {
                    root.Left = nodeToAdd;
                }
                else {
                    root.Left = Add(nodeToAdd, root.Left);
                }
            }
            else {
                root.Right = Add(nodeToAdd, root.Right);
            }

            return null;
        }

        public class BTreeDuplicateException : Exception {}
    }
}