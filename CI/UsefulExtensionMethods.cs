using System;
using System.Collections.Generic;
using System.Linq;

namespace CI {
    public static class UsefulExtensionMethods {
        public static bool In<T>(this T item, params T[] list) {
            return list.Contains(item);
        }

        public static void nTimes(this int times, Action whatToDo) {
            for (var n = 0; n < times; n++) {
                whatToDo.Invoke();
            }
        }

        public static bool ListEquals<T>(this LinkedList<T> thisList, LinkedList<T> otherList) {
            if (thisList.Count != otherList.Count) {
                return false;
            }
            var node1 = thisList.First;
            var node2 = otherList.First;
            while (node1 != null) {
                if (!node1.Value.Equals(node2.Value)) {
                    return false;
                }
                node1 = node1.Next;
                node2 = node2.Next;
            }
            return true;
        }
    }
}