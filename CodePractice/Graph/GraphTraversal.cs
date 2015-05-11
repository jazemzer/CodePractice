using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodePractice.Graph
{
    class GraphTraversal
    {
        public static void Implementation()
        {
            var graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 0);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 3);

            graph.BFS(2, (i) => Console.Write(" " + i));
            Console.WriteLine();
            graph.DFS(2, (i) => Console.Write(" " +i));
        }

        internal class Graph
        {
            int nodes;
            List<List<int>> adjacentNodes;
            public Graph(int numberOfNodes)
            {
                this.nodes = numberOfNodes;
                this.adjacentNodes = new List<List<int>>(numberOfNodes);
                for (int i = 0; i < numberOfNodes; i++)
                {
                    adjacentNodes.Add(new List<int>());
                }
            }

            public void AddEdge(int u, int v)
            {
                this.adjacentNodes[u].Add(v);
            }

            public void DFS(int s, Action<int> action)
            {
                var isVisited = new List<bool>(nodes);

                for (int i = 0; i < nodes; i++)
                {
                    isVisited.Add(false);
                }

                DFS(s, ref isVisited, action);
            }

            private void DFS(int node, ref List<bool> isVisited, Action<int> action)
            {
                isVisited[node] = true;

                action(node);
                foreach(var adjacentNode in adjacentNodes[node])
                {
                    if (!isVisited[adjacentNode])
                        DFS(adjacentNode, ref isVisited, action);
                }
            }

            public void BFS(int s, Action<int> action)
            {
                var isVisited = new List<bool>(nodes);

                for (int i = 0; i < nodes; i++)
                {
                    isVisited.Add(false);
                }

                var queue = new Queue<int>();
                queue.Enqueue(s);

                while(queue.Count > 0)
                {
                    var currentNode = queue.Dequeue();
                    isVisited[currentNode] = true;

                    action(currentNode);

                    foreach(var adjacentNode in adjacentNodes[currentNode])
                    {
                        if (!isVisited[adjacentNode])
                            queue.Enqueue(adjacentNode);
                    }
                }
            }
        }
                
    }
}
