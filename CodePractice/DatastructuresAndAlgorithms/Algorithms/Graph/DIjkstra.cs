using System;

namespace DSArrays
{


    /*
     * Dijkstra's algorithm, named after its discoverer, Dutch computer scientist Edsger Dijkstra,
     * is a greedy algorithm that solves the single-source shortest path problem for a directed graph
     * with non negative edge weights. For example, if the vertices (nodes) of the graph represent cities
     * and edge weights represent driving distances between pairs of cities connected by a direct road,
     * Dijkstra's algorithm can be used to find the shortest route between two cities. Also, this algorithm 
     * can be used for shortest path to destination in traffic network.    
     */
    class Dijkstra
    {
        private int noOfNodes = 0;
        private int[,] AdjacencyMatrix;
        private bool[] IsVisited;
        public int[] NodeCost;
        public int[] PreviousNode;

        public Dijkstra(int[,] adjacencyMatrix)
        {
            this.AdjacencyMatrix = adjacencyMatrix;
            noOfNodes =  (int)Math.Sqrt(adjacencyMatrix.Length);

            IsVisited = new bool[noOfNodes];
            NodeCost = new int[noOfNodes];
            PreviousNode = new int[noOfNodes];

            //Fill IsVisited and PreviousNode array with default values
            for (int i = 0; i < noOfNodes; i++)
            {
                IsVisited[i] = false;
                PreviousNode[i] = -1;
            }

          
        }

        public void DijkstraSolving()
        {

            #region Finding the vertex with minimum Cost
            int minValue = Int32.MaxValue;
            int minNode = 0;

            for (int i = 0; i < noOfNodes; i++)
            {
                if (IsVisited[i])
                    continue;
                if (NodeCost[i] > 0 
                    && NodeCost[i] < minValue)
                {
                    minValue = NodeCost[i];
                    minNode = i;
                }
            }
            IsVisited[minNode] = true;

            #endregion

            
            for (int i = 0; i < noOfNodes; i++)
            {
                //Ignore unreachable nodes from the current minimum
                if (IsVisited[i] || AdjacencyMatrix[minNode, i] < 0)
                    continue;

                //If the node cost is not updated yet, add it to the previous minium
                if (NodeCost[i] < 0)
                {
                    PreviousNode[i] = minNode;
                    NodeCost[i] = minValue + AdjacencyMatrix[minNode, i];
                    continue;
                }

                //Update node cost if the new value is less than the previous one
                if ((minValue + AdjacencyMatrix[minNode, i]) < NodeCost[i])
                {
                    PreviousNode[i] = minNode;
                    NodeCost[i] = minValue + AdjacencyMatrix[minNode, i];
                }
            }
        }

        public void Run(int startNode)
        {
            //Assuming we're gonna start from 0th element as source
            IsVisited[startNode] = true;

            //Because 0th element is source, populate cost values from 0th row in matrix
            for (int i = 0; i < noOfNodes; i++)
            {
                NodeCost[i] = AdjacencyMatrix[startNode, i];

                //Setting previous node
                if (NodeCost[i] != -1)
                {
                    PreviousNode[i] = startNode; //start node
                }
            }

            for (var i = 1; i < noOfNodes; i++)
            {
                DijkstraSolving();
            }
        }
        public static void Implementation()
        {
            int[,] input ={                  
                {-1,  5, -1, -1, -1,  3, -1, -1}, 
                { 5, -1,  2, -1, -1, -1,  3, -1}, 
                {-1,  2, -1,  6, -1, -1, -1, 10}, 
                {-1, -1,  6, -1,  3, -1, -1, -1},
                {-1, -1, -1,  3, -1,  8, -1,  5}, 
                { 3, -1, -1, -1,  8, -1,  7, -1}, 
                {-1,  3, -1, -1, -1,  7, -1,  2}, 
                {-1, -1, 10, -1,  5, -1,  2, -1} 
            };
            Dijkstra algo = new Dijkstra( input);
            algo.Run(4);
            Console.WriteLine("Solution is");
            foreach (int i in algo.NodeCost)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("*****************");
            foreach (int i in algo.PreviousNode)
            {
                Console.WriteLine(i);
            }
            Console.Read();
        }
    }
}