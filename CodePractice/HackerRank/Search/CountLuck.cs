using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Search
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Point left, Point right)
        {
            if (left.X == right.X)
                return left.Y == right.Y;
            else
                return false;
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;
            Point point = (Point)obj;
            if (point.X == this.X)
                return point.Y == this.Y;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.X ^ this.Y;
        }
    }

    public class MazeGraph
    {
        public int V { get; set; }
        public int E { get; set; }

        public Dictionary<Point, List<Point>> AdjancencyList { get; set; }

        //nxm Matrix
        public MazeGraph(char[][] mazeMatrix, int n, int m)
        {
            AdjancencyList = new Dictionary<Point, List<Point>>();

            //Top Right Bottom left
            var dn = new int[] { -1, 0, 1, 0 };
            var dm = new int[] { 0, 1, 0, -1 };

            //Traversing row by row
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    //Considering only paths
                    if (mazeMatrix[i][j] == '.')
                    {
                        var currentCell = new Point(i, j);

                        if (!AdjancencyList.ContainsKey(currentCell))
                        {
                            AdjancencyList.Add(currentCell, new List<Point>());
                        }

                        // Only top and left is considered 
                        for (int k = 0; k < 4; k= k + 3)
                        {
                            var neighbour = new Point(i + dn[k], j + dm[k]);
                            if ((i + dn[k] >= 0 && i + dn[k] < n)  
                                && (j + dm[k] >= 0 && j + dm[k] < m)
                                && mazeMatrix[neighbour.X][neighbour.Y] == '.')
                            {
                                AdjancencyList[neighbour].Add(currentCell);
                                AdjancencyList[currentCell].Add(neighbour);
                                E++;
                            }
                        }
                    }
                }
            }
        }
    }

    public class MazeSearch
    {
        private HashSet<Point> _isVisited;
        private Dictionary<Point, Point> _cameFrom; 
        private MazeGraph _graph;
        private Point _source;
        public MazeSearch(MazeGraph graph, Point source)
        {
            _isVisited = new HashSet<Point>();
            _cameFrom = new Dictionary<Point, Point>();
            _graph = graph;
            _source = source;
            DFS(source);
        }

        private void DFS(Point current)
        {
            _isVisited.Add(current);
            foreach (var neighbour in _graph.AdjancencyList[current])
            {
                if (!_isVisited.Contains(neighbour))    // If not already visited
                {
                    _cameFrom[neighbour] = current;
                    DFS(neighbour);
                }
            }
        }

        public IEnumerable<Point> FindPathTo(Point destination)
        {
            if (!_isVisited.Contains(destination))
                return null;

            var path = new Stack<Point>();
            for (Point current = destination; current != _source; current = _cameFrom[current])
            {
                path.Push(current);
            }

            //path.Push(_source);

            return path;

        }
    }

    public class CountLuck
    {

        public static void Code()
        {
            int T = Convert.ToInt32(Console.ReadLine());
            //int T = 1;
            while (T > 0)
            {
                var NandM = Console.ReadLine().Split(' ');
                var N = Convert.ToInt32(NandM[0]);
                var M = Convert.ToInt32(NandM[1]);

                //var N = 5;
                //var M = 17;
                //var matrix = new List<string>
                //{
                //    "XXXXXXXXXXXXXXXXX",
                //    "XXX.XX.XXXXXXXXXX",
                //    "XX.*..M.XXXXXXXXX",
                //    "XXX.XX.XXXXXXXXXX",
                //    "XXXXXXXXXXXXXXXXX"
                //};

                Point start = new Point(), end = new Point();
                var forest = new char[N][];
                for (int i = 0; i < N; i++)
                {
                    forest[i] = Console.ReadLine().ToCharArray();
                    //forest[i] = matrix[i].ToCharArray();

                    //Finding source and target points
                    for (int j = 0; j < M; j++)
                    {
                        if (forest[i][j] == '*')
                        {
                            forest[i][j] = '.';
                            end = new Point(i, j);
                        }
                        else if (forest[i][j] == 'M')
                        {
                            forest[i][j] = '.';
                            start = new Point(i,j);
                        }
                    }
                }

                int K = Convert.ToInt32(Console.ReadLine());
                //int K = 1;

                var graph = new MazeGraph(forest, N, M);
                var search = new MazeSearch(graph, start);
                var path = search.FindPathTo(end).ToList();


                int wandWaves = 0;


                if (graph.AdjancencyList[start].Count > 1)
                {
                    wandWaves++;
                }
                for (int i = 0; i < path.Count() -1 ; i++)
                {
                    if (graph.AdjancencyList[path[i]].Count > 2)
                    {
                        wandWaves++;
                    }
                }

                Console.WriteLine(wandWaves == K ? "Impressed" : "Oops!");

                T--;
            }

            Console.ReadLine();
        }
    }
}
