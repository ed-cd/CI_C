using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CI
{
    [TestClass]
    public class Four_2_Test
    {
        [TestMethod]
        public void TestMethod1()
        {
            var graph = new Graph<int, int>();
            var node1 = new GraphNode<int, int>(1);
            var node2 = new GraphNode<int, int>(2);
            var node3 = new GraphNode<int, int>(3);
            var node4 = new GraphNode<int, int>(4);
            var node5 = new GraphNode<int, int>(5);
            var node6 = new GraphNode<int, int>(6);
            var node7 = new GraphNode<int, int>(7);
            var node8 = new GraphNode<int, int>(8);
            var node9 = new GraphNode<int, int>(9);
            var node0 = new GraphNode<int, int>(0);

            graph.AddVertex(node1);
            graph.AddVertex(node2);
            graph.AddVertex(node3);
            graph.AddVertex(node4);
            graph.AddVertex(node5);
            graph.AddVertex(node6);
            graph.AddVertex(node7);
            graph.AddVertex(node8);
            graph.AddVertex(node9);
            graph.AddVertex(node0);

            graph.AddEdge(node1, node2, 1, false);
            graph.AddEdge(node4, node1, 1, true);
            graph.AddEdge(node3, node4, 1, false);
            graph.AddEdge(node3, node4, 1, false);
            graph.AddEdge(node3, node4, 1, false);
            graph.AddEdge(node3, node5, 1, false);
            graph.AddEdge(node5, node6, 1, true);
            graph.AddEdge(node5, node7, 1, false);
            graph.AddEdge(node7, node8, 1, false);
            graph.AddEdge(node9, node0, 1, false);
            graph.AddEdge(node4, node6, 1, true);
            graph.AddEdge(node5, node4, 1, true);

            Assert.IsTrue(graph.IsRouteDfs(node8, node1));
            Assert.IsFalse(graph.IsRouteDfs(node1, node8));
            Assert.IsTrue(graph.IsRouteDfs(node4, node6));
            Assert.IsFalse(graph.IsRouteDfs(node6, node4));
            Assert.IsTrue(graph.IsRouteDfs(node3, node8));
            Assert.IsFalse(graph.IsRouteDfs(node0, node4));
            Assert.IsTrue(graph.IsRouteDfs(node9, node0));

            Assert.IsTrue(graph.IsRouteBfs(node8, node1));
            Assert.IsFalse(graph.IsRouteBfs(node1, node8));
            Assert.IsTrue(graph.IsRouteBfs(node4, node6));
            Assert.IsFalse(graph.IsRouteBfs(node6, node4));
            Assert.IsTrue(graph.IsRouteBfs(node3, node8));
            Assert.IsFalse(graph.IsRouteBfs(node0, node4));
            Assert.IsTrue(graph.IsRouteBfs(node9, node0));
        }
    }
}