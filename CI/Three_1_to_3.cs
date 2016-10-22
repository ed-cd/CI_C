using System.Collections.Generic;

namespace CI
{
    public class Three_1_to_3
    {
 /*       static void XXX(string[] args) {
            var stack = new MyStack<int>();
            stack.push(1);
            stack.push(2);
            stack.push(3);
            stack.push(-1);
            var x = stack.Min;

            var setOfStacks = new SetOfStacks<int>(2);
            setOfStacks.push(1);
            setOfStacks.push(2);
            setOfStacks.push(3);
            setOfStacks.push(4);
            setOfStacks.push(5);
            setOfStacks.push(6);

            var y = setOfStacks.CanPop;
            System.Console.WriteLine(setOfStacks.PopAt(1));
            System.Console.WriteLine(setOfStacks.PopAt(1));
            try {
                while (true) {
                    var val = setOfStacks.pop();
                    System.Console.WriteLine(val);
                }
            }
            catch (EmptyStackException e) { }
            var q = 1;

            var tower1 = new MyStack<int>();
            var tower2 = new MyStack<int>();
            var tower3 = new MyStack<int>();
            stack.push(1);
            stack.push(2);
            stack.push(3);
        }*/

        public static void RemoveDuplicates<T>(LinkedList<T> list) {
            var node = list.First;
            if (node == null) return;
            while (node?.Next != null) {
                RemoveDuplicates(node.Next, node.Value);
                node = node.Next;
            }
        }

        private static void RemoveDuplicates<T>(LinkedListNode<T> node, T val) {
            if (node.Value.Equals(val)) {

            }
        }

        public static void SolveTowersOfHanoi(MyStack<int> tower1, MyStack<int> tower2, MyStack<int> tower3) {

        }
    }
}