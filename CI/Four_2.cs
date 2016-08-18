using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CI
{
    using System;

    public class Graph<N, E>
    {
        public readonly List<GraphNode<N, E>> Vertices = new List<GraphNode<N, E>>();
        public int Count => Vertices.Count;
        public int NumberOfEdges { get; private set; } = 0;

        public void AddVertex(GraphNode<N, E> vertex)
        {
            Vertices.Add(vertex);
        }

        // ReSharper disable once InconsistentNaming
        public void AddEdge(GraphNode<N, E> from, GraphNode<N, E> to, E weight, bool isDirected)
        {
            if (to == null) throw new ArgumentNullException(nameof(to));
            if (!Vertices.Contains(from) || !Vertices.Contains(to))
            {
                throw new GraphException();
            }
            var newEdge = new GraphEdge<N, E>(from, to, weight);

            from.OutgoingEdges.Add(newEdge);
            to.IncomingEdges.Add(newEdge);
            NumberOfEdges++;
            if (isDirected) return;
            var newEdgeReversed = new GraphEdge<N, E>(to, from, weight);
            from.IncomingEdges.Add(newEdgeReversed);
            to.OutgoingEdges.Add(newEdgeReversed);
            NumberOfEdges++;
        }

        public bool IsRouteDfs(GraphNode<N, E> from, GraphNode<N, E> to)
        {
            return @from == to || IsRouteDfs(@from, to, new Dictionary<GraphNode<N, E>, bool>());
        }

        private static bool IsRouteDfs(GraphNode<N, E> current, GraphNode<N, E> to,
            Dictionary<GraphNode<N, E>, bool> visitedNodes)
        {
            if (current == to)
            {
                return true;
            }
            visitedNodes.Add(current, true);
            foreach (var edge in current.OutgoingEdges)
            {
                var nextNode = edge.To;
                if (visitedNodes.Keys.Contains(nextNode)) continue;
                if (IsRouteDfs(nextNode, to, visitedNodes))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsRouteBfs(GraphNode<N, E> currentNode, GraphNode<N, E> to)
        {
            if (currentNode == to)
            {
                return true;
            }
            var visitedNodes = new Dictionary<GraphNode<N, E>, bool>();
            var nodesToCheck = new Queue<GraphNode<N, E>>();
            while (visitedNodes.Count < Count)
            {
                visitedNodes[currentNode] = true;
                foreach (var edge in currentNode.OutgoingEdges)
                {
                    var nodeToCheck = edge.To;
                    if (nodeToCheck == to)
                    {
                        return true;
                    }
                    if (!visitedNodes.ContainsKey(nodeToCheck))
                    {
                        nodesToCheck.Enqueue(nodeToCheck);
                    }
                }
                if (nodesToCheck.Count == 0)
                {
                    break;
                }
                currentNode = nodesToCheck.Dequeue();
            }

            return false;
        }
    }

    public class GraphException : Exception
    {
    }

    [DebuggerDisplay("From {From.Value} to {To.Value}")]
    public class GraphEdge<N, E>
    {
        public GraphNode<N, E> From { get; private set; }
        public GraphNode<N, E> To { get; private set; }

        public E Weight { get; private set; }

        public GraphEdge(GraphNode<N, E> from, GraphNode<N, E> to, E weight)
        {
            if (from == null || to == null || from == to)
            {
                throw new GraphException();
            }
            From = from;
            To = to;
            Weight = weight;
        }
    }

    [DebuggerDisplay("{Value}")]
    public class GraphNode<N, E>
    {
        public N Value { get; private set; }
        public readonly List<GraphEdge<N, E>> OutgoingEdges = new List<GraphEdge<N, E>>();
        public readonly List<GraphEdge<N, E>> IncomingEdges = new List<GraphEdge<N, E>>();

        protected bool Equals(GraphNode<N, E> other)
        {
            return !ReferenceEquals(null, other) && Uuid.Equals(other.Uuid);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((GraphNode<N, E>) obj);
        }

        public override int GetHashCode()
        {
            return Uuid.GetHashCode();
        }

        public Guid Uuid { get; }

        public GraphNode(N value)
        {
            Uuid = Guid.NewGuid();
            Value = value;
        }

        public static bool operator ==(GraphNode<N, E> node1, GraphNode<N, E> node2)
        {
            return node1.Equals(node2);
        }

        public static bool operator !=(GraphNode<N, E> node1, GraphNode<N, E> node2)
        {
            return !(node1 == node2);
        }
    }
}