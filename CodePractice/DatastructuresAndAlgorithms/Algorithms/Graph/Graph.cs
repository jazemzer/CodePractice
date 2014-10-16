using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Graph
    {

        public int V { get; set; }
        public int E { get; set; }

        private List<List<int>> _adjacencyList;

        public Graph(int v)
        {
            Initialize(v);
        }

        private void Initialize(int v)
        {
            V = v;
            //Initializing empty list 
            _adjacencyList = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
            {
                _adjacencyList.Add(new List<int>());
            }
        }

        public Graph(string inputFilePath)
        {

            using (StreamReader reader = File.OpenText(inputFilePath))
            {
                int v = 0, e = 0 ;
                if (!reader.EndOfStream)
                {
                   v = Convert.ToInt32(reader.ReadLine());
                }

                if (!reader.EndOfStream)
                {
                    e = Convert.ToInt32(reader.ReadLine());
                }

                Initialize(v);

                while (!reader.EndOfStream && e >0)
                {
                    var aAndb = reader.ReadLine().Split(' ');
                    var a = Convert.ToInt32(aAndb[0]);
                    var b = Convert.ToInt32(aAndb[1]);

                    AddEdge(a, b);

                    e--;
                }
            }
        }

        public void AddEdge(int a, int b)
        {
            _adjacencyList[a].Add(b);
            _adjacencyList[b].Add(a);
            E++;
        }

        public List<int> FindAdjacentVertices(int v)
        {
            return _adjacencyList[v];
        }
    }
}
