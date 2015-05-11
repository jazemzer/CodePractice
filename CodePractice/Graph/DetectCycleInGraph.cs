using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CodePractice.Graph
{
    class DetectCycleInGraph
    {


        public static void Implementation()
        {
            var graph = new Graph<int>();
            for (int i = 0; i < 4; i++)
            {
                graph.AddNode(i);
            }

            graph.AddDirectedEdge(0, 1, 1);
            graph.AddDirectedEdge(0, 2, 1);
            graph.AddDirectedEdge(1, 2, 1);
            graph.AddDirectedEdge(2, 0, 1);
            graph.AddDirectedEdge(2, 3, 1);
            graph.AddDirectedEdge(3, 3, 1);

            Console.WriteLine(graph.IsCyclic());
        }

        internal class Graph<T> 
        {
            public bool IsCyclic()
            {

                //Search for each node in order to handle for disconnected graphs
                foreach(var node in nodeSet)
                {
                    var isVisisted = new bool[Nodes.Count];
                    if (isCyclicUtil(node, ref isVisisted))
                        return true;
                }
                return false;
            }

            private bool isCyclicUtil(GraphNode<T> current, ref bool[] isVisited)
            {
                var index = Nodes.IndexOf(current);
                if (isVisited[index])
                    return true;

                isVisited[index] = true;
                foreach (var neighbour in current.Neighbours)
                {
                    if (isCyclicUtil(neighbour, ref isVisited))
                        return true;

                }
                return false;
            }

            private NodeList<T> nodeSet = new NodeList<T>();
            public NodeList<T> Nodes
            {
                get { return nodeSet; }
            }

            public void AddNode(T value)
            {
                nodeSet.Add(new GraphNode<T>(value));
            }

            public void AddDirectedEdge(T from, T to, int cost)
            {
                var u = nodeSet.FindByValue(from);
                var v = nodeSet.FindByValue(to);

                u.Neighbours.Add(v);
                u.Costs.Add( cost);
            }

            public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
            {
                from.Neighbours.Add(to);
                from.Costs.Add(cost);
            }

            public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost)
            {
                from.Neighbours.Add(to);
                from.Costs.Add(cost);

                to.Neighbours.Add(from);
                to.Costs.Add(cost);
            }

        }

        internal class GraphNode<T>
        {
            public GraphNode() { }
            public GraphNode(T data) : this(data, null) { }
            public GraphNode(T data, NodeList<T> neighbours)
            {
                this.data = data;
                this.neighbours = neighbours;
            }

            private T data;
            public T Value
            {
                get
                {
                    return data;
                }
                set
                {
                    data = value;
                }
            }

            private NodeList<T> neighbours = null;
            public NodeList<T> Neighbours
            {
                get
                {
                    if (neighbours == null)
                        neighbours = new NodeList<T>();
                    return neighbours;
                }
                set
                {
                    neighbours = value;
                }
            }

            private List<int> costs;
            public List<int> Costs
            {
                get
                {
                    if (costs == null)
                        costs = new List<int>();

                    return costs;
                }
            }

        }

        internal class NodeList<T> : Collection<GraphNode<T>>
        {
            public GraphNode<T> FindByValue(T value)
            {
                foreach (GraphNode<T> node in Items)
                    if (node.Value.Equals(value))
                        return node;

                return null;
            }

            
        }
        
                
                
    }
}
