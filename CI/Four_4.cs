using System;
using System.Collections.Generic;

namespace CI {
    public class Four_4 {
        public static List<LinkedList<T>> getNodesByDepth<T>(Tree<T> tree) where T : IComparable {
            var list = new List<LinkedList<T>>();
            getNodesByDepth(tree.Root, list, 0);
            return list;
        }

        private static void getNodesByDepth<T>(TreeNode<T> root, List<LinkedList<T>> resultlist, int depth)
            where T : IComparable {
            if (root == null) {
                return;
            }
            if (resultlist.Count < depth + 1) {
                (depth + 1 - resultlist.Count).nTimes(() => { resultlist.Add(new LinkedList<T>()); });
            }
            resultlist[depth].AddLast(root.Value);
            getNodesByDepth(root.Left, resultlist, depth + 1);
            getNodesByDepth(root.Right, resultlist, depth + 1);
        }
    }
}