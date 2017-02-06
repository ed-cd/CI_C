using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CI
{
    [DebuggerDisplay("Value = {Value}")]
    public class TreeNode<T>
        where T : IComparable
    {
        private T rootValue;

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }

        public T Value { get; set; }

        public TreeNode()
        {
        }

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
            return !(left < right) && left != right;
        }

        public static bool operator <=(TreeNode<T> left, TreeNode<T> right)
        {
            return left < right || left == right;
        }

        public static bool operator >=(TreeNode<T> left, TreeNode<T> right)
        {
            return !(left < right);
        }

        public static bool operator ==(TreeNode<T> left, TreeNode<T> right)
        {
            return (ReferenceEquals(left, null) && ReferenceEquals(right, null)) ||
                   (right != null && left?.Value.CompareTo(right.Value) == 0);
        }

        public static bool operator !=(TreeNode<T> left, TreeNode<T> right)
        {
            return !(left == right);
        }
    }

    public class TreeNodeWithBackLink<T> : TreeNode<T> where T : IComparable
    {
        public TreeNodeWithBackLink<T> Parent { get; set; }

        public TreeNodeWithBackLink(T value, TreeNodeWithBackLink<T> parent)
        {
            Value = value;
            Parent = parent;
        }

        public TreeNodeWithBackLink<T> NextNodeInOrder()
        {
            var current = this;

            if (current.Right != null)
            {
                return _TraverseToEndOfLeftSubBranch(current.Right as TreeNodeWithBackLink<T>);
            }
            if (current.Parent == null || current.Parent.Right == current)
            {
                return null;
            }
            return current.Parent;
        }

        private static TreeNodeWithBackLink<T> _TraverseToEndOfLeftSubBranch(TreeNodeWithBackLink<T> current)
        {
            if (current == null || current.Left == null)
            {
                return current;
            }
            return _TraverseToEndOfLeftSubBranch(current.Left as TreeNodeWithBackLink<T>);
        }

        public static TreeNodeWithBackLink<T> GetClosestMutualAncestorNode(TreeNodeWithBackLink<T> node1,
            TreeNodeWithBackLink<T> node2, TreeNodeWithBackLink<T> calledFrom = null)
        {
            bool found;
            if (calledFrom == null)
            {
                found = IsNodeInSubtree(node1.Left as TreeNodeWithBackLink<T>, node2) ||
                        IsNodeInSubtree(node1.Right as TreeNodeWithBackLink<T>, node2);
            }
            else if (ReferenceEquals(node1, node2))
            {
                found = true;
            }
            else if (ReferenceEquals(calledFrom, node1.Left))
            {
                found = IsNodeInSubtree(node1.Right as TreeNodeWithBackLink<T>, node2);
            }
            else
            {
                found = IsNodeInSubtree(node1.Left as TreeNodeWithBackLink<T>, node2);
            }
            return found ? node1 : GetClosestMutualAncestorNode(node1.Parent, node2, node1);
        }

        private static bool IsNodeInSubtree(TreeNodeWithBackLink<T> root,
            TreeNodeWithBackLink<T> toFind)
        {
            if (root == null)
            {
                return false;
            }
            if (ReferenceEquals(root, toFind))
            {
                return true;
            }
            return IsNodeInSubtree(root.Left as TreeNodeWithBackLink<T>, toFind) ||
                   IsNodeInSubtree(root.Right as TreeNodeWithBackLink<T>, toFind);
        }
    }

    public class BinaryTreeWithBackLinks<T> : Tree<T> where T : IComparable
    {
        public new void Add(T value)
        {
            Root = Add(value, Root as TreeNodeWithBackLink<T>, null);
            Count++;
        }

        protected TreeNodeWithBackLink<T> Add(T value, TreeNodeWithBackLink<T> root, TreeNodeWithBackLink<T> parent)
        {
            if (root == null)
            {
                return new TreeNodeWithBackLink<T>(value, parent);
            }
            if (value.CompareTo(root.Value) < 0)
            {
                root.Left = Add(value, root.Left as TreeNodeWithBackLink<T>, root);
            }
            else
            {
                root.Right = Add(value, root.Right as TreeNodeWithBackLink<T>, root);
            }
            return root;
        }
    }

    public class Tree<T>
        where T : IComparable
    {
        public int Count { get; protected set; }

        public TreeNode<T> Root { get; set; }

        public bool IsValid => checkIfValid(Root);

        public void Add(T value)
        {
            var nodeToAdd = new TreeNode<T>(value);
            Root = Add(nodeToAdd, Root);
            Count++;
        }

        public bool IsBalanced => getDepth(Root) != -1;

        protected virtual TreeNode<T> Add(TreeNode<T> nodeToAdd, TreeNode<T> root)
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

        protected static int getDepth(TreeNode<T> root)
        {
            if (root == null)
            {
                return 0;
            }

            var leftDepth = getDepth(root.Left);
            var rightDepth = getDepth(root.Right);
            if (leftDepth == -1 || rightDepth == -1 || Math.Abs(leftDepth - rightDepth) > 1)
            {
                return -1;
            }

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        protected static bool checkIfValid(TreeNode<T> root)
        {
            if (root == null)
            {
                return true;
            }
            var ret = true;
            if (root.Left != null)
            {
                ret &= root.Left < root;
            }
            if (root.Right != null)
            {
                ret &= root.Right >= root;
            }
            return ret && checkIfValid(root.Left) && checkIfValid(root.Right);
        }

        public bool IsSubtree(Tree<T> candidateTree)
        {
            return _IsSubtree(Root, candidateTree.Root);
        }

        private static bool _IsSubtree(TreeNode<T> parentTreeRoot, TreeNode<T> candidateTreeRoot, bool inSubtree = false)
        {
            if ((parentTreeRoot == null ^ candidateTreeRoot == null))
            {
                return false;
            }
            if (parentTreeRoot == null && candidateTreeRoot == null)
            {
                return true;
            }

            if (parentTreeRoot == candidateTreeRoot)
            {
                return _IsSubtree(parentTreeRoot.Left, candidateTreeRoot.Left, true) &&
                       _IsSubtree(parentTreeRoot.Right, candidateTreeRoot.Right, true);
            }
            if (inSubtree)
            {
                return false;
            }
            return _IsSubtree(parentTreeRoot.Left, candidateTreeRoot) ||
                   _IsSubtree(parentTreeRoot.Right, candidateTreeRoot);
        }

        public List<T> InOrderTraversal
        {
            get
            {
                var list = new List<T>();
                _InOrderTraversal(Root, list);
                return list;
            }
        }

        private void _InOrderTraversal(TreeNode<T> root, List<T> list)
        {
            if (root == null) return;
            _InOrderTraversal(root.Left, list);
            list.Add(root.Value);
            _InOrderTraversal(root.Right, list);
        }

        public List<T> PreOrderTraversal
        {
            get
            {
                var list = new List<T>();
                _PreOrderTraversal(Root, list);
                return list;
            }
        }

        private void _PreOrderTraversal(TreeNode<T> root, List<T> list)
        {
            if (root == null) return;
            list.Add(root.Value);
            _PreOrderTraversal(root.Left, list);
            _PreOrderTraversal(root.Right, list);
        }

        public List<T> PostOrderTraversal
        {
            get
            {
                var list = new List<T>();
                _PostOrderTraversal(Root, list);
                return list;
            }
        }

        private void _PostOrderTraversal(TreeNode<T> root, List<T> list)
        {
            if (root == null) return;
            _PostOrderTraversal(root.Left, list);
            _PostOrderTraversal(root.Right, list);
            list.Add(root.Value);
        }

        public List<T> By_LevelTraversal
        {
            get
            {
                var ret = new List<T>();
                var queue = new Queue<TreeNode<T>>();
                Action<TreeNode<T>> f = t =>
                {
                    ret.Add(t.Value);
                    if (t.Left != null) queue.Enqueue(t.Left);
                    if (t.Right != null) queue.Enqueue(t.Right);
                };
                queue.Enqueue(Root);
                do
                {
                    f.Invoke(queue.Dequeue());
                } while (queue.Count > 0);
                return ret;
            }
        }

        public void ConvertToDoublyLinkedList()
        {
            _ConvertToDoublyLinkedList(Root);
        }

        private void _ConvertToDoublyLinkedList(TreeNode<T> root)
        {
            var leftRightMost = _GetRightMostNode(root.Left);
            var rightleftMost = _GetLeftMostNode(root.Right);
            if (leftRightMost != null)
            {
                _ConvertToDoublyLinkedList(root.Left);
                leftRightMost.Right = root;
                root.Left = leftRightMost;
            }
            if (rightleftMost != null)
            {
                _ConvertToDoublyLinkedList(root.Right);
                rightleftMost.Left = root;
                root.Right = rightleftMost;
            }
        }

        public TreeNode<T> _GetRightMostNode(TreeNode<T> root)
        {
            if (root == null) return null;
            var ret = root.Right != null ? _GetRightMostNode(root.Right) : root;
            return ret;
        }

        public TreeNode<T> _GetLeftMostNode(TreeNode<T> root)
        {
            if (root == null) return null;
            var ret = root.Left != null ? _GetLeftMostNode(root.Left) : root;
            return ret;
        }


        public static Tree<T> ReconstructFromInorderAndPostOrder(List<T> inOrder, List<T> postOrder)
        {
            var tree = new Tree<T>();
            if (postOrder.Count != inOrder.Count) throw new Exception("length mismatch");
            var count = 0;
            if (postOrder.Count > 0)
            {
                tree.Root = _ReconstructFromInorderAndPostOrder(inOrder, new Stack<T>(postOrder), ref count);
                tree.Count = count;
            }
            return tree;
        }

        private static TreeNode<T> _ReconstructFromInorderAndPostOrder(List<T> inOrder, Stack<T> postOrder,
            ref int count)
        {
            var rootValue = postOrder.Pop();
            count++;
            var root = new TreeNode<T>(rootValue);
            var rootIndex = inOrder.LastIndexOf(rootValue);
            root.Right = (inOrder.Count > 0 && postOrder.Count > 0 && inOrder.LastIndexOf(postOrder.Peek()) > rootIndex)
                ? _ReconstructFromInorderAndPostOrder(inOrder.GetRange(rootIndex + 1, inOrder.Count - rootIndex - 1),
                    postOrder, ref count)
                : null;
            root.Left = (inOrder.Count > 0 && postOrder.Count > 0 && inOrder.LastIndexOf(postOrder.Peek()) <= rootIndex &&
                         inOrder.LastIndexOf(postOrder.Peek()) >= 0)
                ? _ReconstructFromInorderAndPostOrder(inOrder.GetRange(0, rootIndex), postOrder, ref count)
                : null;
            return root;
        }

        public static bool operator ==(Tree<T> t1, Tree<T> t2)
        {
            if (t1?.Root == null || t2?.Root == null) return false;
            return _equals(t1.Root, t2.Root);
        }

        public static bool _equals(TreeNode<T> n1, TreeNode<T> n2)
        {
            if (ReferenceEquals(n1, null) && ReferenceEquals(n2, null)) return true;
            return n1 == n2 && _equals(n1.Left, n2.Left) && _equals(n1.Right, n2.Right);
        }

        public static bool operator !=(Tree<T> t1, Tree<T> t2)
        {
            return !(t1 == t2);
        }
    }

    public static class TreeExtensions
    {
        public static List<List<int>> GetAllPathsThatSumTo(this Tree<int> tree, int goal)
        {
            var result = new List<List<int>>();
            if (tree?.Root != null)
            {
                _GetAllPathsThatSumTo(tree.Root, result,
                    new List<int>(), 0, goal, false);
            }
            return result;
        }

        private static void _GetAllPathsThatSumTo(TreeNode<int> root, List<List<int>> mainList, List<int> soFarList,
            int soFarValue, int goal, bool notFromTreeRoot = true)
        {
            soFarList.Add(root.Value);
            soFarValue += root.Value;
            if (soFarValue == goal)
            {
                mainList.Add(soFarList);
            }
            if (root.Left != null)
            {
                _GetAllPathsThatSumTo(root.Left, mainList, new List<int>(soFarList), soFarValue, goal);
                if (notFromTreeRoot)
                {
                    _GetAllPathsThatSumTo(root.Left, mainList, new List<int>() {root.Value}, root.Value, goal);
                }
            }
            if (root.Right != null)
            {
                _GetAllPathsThatSumTo(root.Right, mainList, new List<int>(soFarList), soFarValue, goal);
                if (notFromTreeRoot)
                {
                    _GetAllPathsThatSumTo(root.Right, mainList, new List<int>(root.Value) {root.Value}, root.Value, goal);
                }
            }
        }
    }

    public class BTree<T> : Tree<T>
        where T : IComparable
    {
        protected override TreeNode<T> Add(TreeNode<T> nodeToAdd, TreeNode<T> root)
        {
            if (root == null)
            {
                return nodeToAdd;
            }

            if (nodeToAdd == root)
            {
                throw new BTreeDuplicateException();
            }

            var dLeft = getDepth(root.Left);
            var dRight = getDepth(root.Right);
            if (dLeft == dRight)
            {
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
            if (dLeft > dRight)
            {
                if (nodeToAdd >= root)
                {
                    root.Right = Add(nodeToAdd, root.Right);
                    return root;
                }
                if (nodeToAdd == root.Left)
                {
                    throw new BTreeDuplicateException();
                }
                if (nodeToAdd > root.Left)
                {
                    var temp = root.Value;
                    root.Value = nodeToAdd.Value;
                    nodeToAdd.Value = temp;
                    root.Right = Add(nodeToAdd, root.Right);
                    reShuffle(root.Left);
                    return root;
                }
                else
                {
                    var temp = root.Left.Value;
                    root.Left.Value = nodeToAdd.Value;
                    nodeToAdd.Value = temp;
                    temp = root.Value;
                    root.Value = nodeToAdd.Value;
                    nodeToAdd.Value = temp;
                    root.Right = Add(nodeToAdd, root.Right);
                    reShuffle(root.Left);
                    return root;
                }
            }
            //dRight > dleft
            if (nodeToAdd < root)
            {
                root.Left = Add(nodeToAdd, root.Left);
                return root;
            } //else
            if (nodeToAdd == root.Right)
            {
                throw new BTreeDuplicateException();
            }
            if (nodeToAdd < root.Right)
            {
                var temp = root.Value;
                root.Value = nodeToAdd.Value;
                nodeToAdd.Value = temp;
                root.Left = Add(nodeToAdd, root.Left);
                reShuffle(root.Right);
                return root;
            }
            else
            {
                var temp = root.Right.Value;
                root.Right.Value = nodeToAdd.Value;
                nodeToAdd.Value = temp;
                temp = root.Value;
                root.Value = nodeToAdd.Value;
                nodeToAdd.Value = temp;
                root.Left = Add(nodeToAdd, root.Left);
                reShuffle(root.Right);
                return root;
            }
        }

        protected static void reShuffle(TreeNode<T> root)
        {
            if (root == null) return;
            if (root.Left != null && root > root.Left)
            {
                var temp = root.Value;
                root.Value = root.Left.Value;
                root.Left.Value = temp;
                reShuffle(root.Left);
            }
            else if (root.Left != null && root.Right < root)
            {
                var temp = root.Value;
                root.Value = root.Right.Value;
                root.Right.Value = temp;
                reShuffle(root.Right);
            }
        }
    }

    public static class TreeExtensionMethods
    {
        public static string AsString(this List<int> list)
        {
            var result = new StringBuilder();
            list.ForEach(element =>
            {
                result.Append(element);
                result.Append(',');
            });
            if (result.Length > 1)
            {
                result.Remove(result.Length - 1, 1);
            }
            return result.ToString();
        }
    }

    public class BTreeDuplicateException : Exception
    {
    }
}