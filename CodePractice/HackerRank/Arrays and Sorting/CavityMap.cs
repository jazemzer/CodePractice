using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Algorithms
{
    public class CavityMap
    {
        public static void Code()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            var matrix = new int[n, n];

            for (int i = 0; i <n ; i++)
            {
                var currentRow = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToInt32(currentRow[j].ToString());
                }
            }


            for (int i = 1; i < n - 1; i++)
            {
                for (int j = 1; j < n - 1; j++)
                {
                    var currentCell = matrix[i, j];
                    if (currentCell > matrix[i, j - 1]%1000
                        && currentCell > matrix[i, j + 1]%1000
                        && currentCell > matrix[i - 1, j]%1000
                        && currentCell > matrix[i + 1, j]%1000)
                    {
                        matrix[i, j] += 1000;
                    }
                }
            }

            for (int i = 0; i <= n - 1; i++)
            {
                for (int j = 0; j <= n - 1; j++)
                {
                    Console.Write(matrix[i, j] >1000 ? "X" : matrix[i, j].ToString());
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
                
    }
}
