using System.Collections.Generic;

namespace CI
{
    using System;

    public class Graph<N,E>
    {
        public readonly List<GraphNode<N,E>> Vertices = new List<GraphNode<N,E>>();

        public void AddVertex(GraphNode<N,E> vertex)
        {
            Vertices.Add(vertex);
        }

        // ReSharper disable once InconsistentNaming
        public void AddEdge(GraphNode<N,E> from, GraphNode<N,E> to, E weight, bool isDirected)
        {
            if (to == null) throw new ArgumentNullException(nameof(to));
            if (!Vertices.Contains(from) || !Vertices.Contains(to))
            {
                throw new GraphException();
            }
            var newEdge = new GraphEdge<N, E>(from, to, weight);
            
            from.OutgoingEdges.Add(newEdge);
            to.IncomingEdges.Add(newEdge);
            if (isDirected) return;
            var newEdgeReversed = new GraphEdge<N, E>(to, from, weight);
            from.IncomingEdges.Add(newEdgeReversed);
            to.OutgoingEdges.Add(newEdgeReversed);
        }

        public bool isRouteDfs(GraphNode<N, E> from, GraphNode<N, E> to)
        {
            return false;
        }
    }

    public class GraphException : Exception
    {
    }

    public class GraphEdge<N, E>
    {
        public GraphNode<N,E> From { get; private set; }
        public GraphNode<N,E> To { get; private set; }

        public E Weight { get; private set; }

        public GraphEdge(GraphNode<N,E> from, GraphNode<N,E> to, E weight)
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
#pragma warning disable 660,661
    public class GraphNode<N, E>
#pragma warning restore 660,661
    {
        public override int GetHashCode()
        {
            return Uuid.GetHashCode();
        }

        public N Value { get; private set; }
        public readonly List<GraphEdge<N, E>> OutgoingEdges = new List<GraphEdge<N, E>>();
        public readonly List<GraphEdge<N, E>> IncomingEdges = new List<GraphEdge<N, E>>();

        public Guid Uuid { get; }

        public GraphNode(N value)
        {
            Uuid = Guid.NewGuid();
            Value = value;
        }

        public static bool operator ==(GraphNode<N,E> node1, GraphNode<N,E> node2)
        {
            if (node1 == null || node2 == null)
            {
                return false;
            }
            return node1.Equals(node2);
        }

        public static bool operator !=(GraphNode<N,E> node1, GraphNode<N,E> node2)
        {
            return !(node1 == node2);
        }
    }
}