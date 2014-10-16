using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class DepthFirstSearch
    {
        private bool[] connected;

        private int[] edgetTo;
        private int source;
        public int TotalConnections { get; set; }

        public DepthFirstSearch(Graph graph, int source)
        {
            connected = new bool [graph.V ];
            edgetTo = new int[graph.V];
            DFS(graph, source);
        }

        private void DFS(Graph graph, int v)
        {
            connected[v] = true;
            TotalConnections++;

            foreach (var adjacentVertex in graph.FindAdjacentVertices(v))
            {

                if (!connected[adjacentVertex])
                {
                    edgetTo[adjacentVertex] = v;
                    DFS(graph, adjacentVertex);
                }


            }
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
                return null;

            var path = new Stack<int>();
            for (int x = v; x != source; x = edgetTo[x])
            {
                path.Push(x);
            }
            path.Push(source);

            return path;
        }

        public bool HasPathTo(int v)
        {
            return connected[v];
        }

        public bool IsConnected(int v)
        {
            return connected[v];
        }
    }
}
