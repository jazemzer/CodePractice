using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank.Warmup
{
    class AcmIcpcTeam
    {

        public static void Code()
        {
            var NandM = (Console.ReadLine()).Split(' ');
            int N = Convert.ToInt32(NandM[0]);
            int M = Convert.ToInt32(NandM[1]);

            var topics = new List<string>();
            var loop = N;
            while (loop > 0)
            {
                topics.Add(Console.ReadLine());
                loop--;
            }

            int maxTopics = 0;
            int teamsWithMaxTopics = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    var P1 = topics[i];
                    var P2 = topics[j];

                    var knownTopics = 0;
                    for (int k = 0; k < M; k++)
                    {
                        if (P1[k] == '1' || P2[k] == '1')
                        {
                            knownTopics++;
                        }
                    }

                    if (knownTopics > maxTopics)
                    {
                        maxTopics = knownTopics;
                        teamsWithMaxTopics = 1;
                    }
                    else if (knownTopics == maxTopics)
                    {
                        teamsWithMaxTopics++;
                    }
                }
            }

            Console.WriteLine(maxTopics);
            Console.WriteLine(teamsWithMaxTopics);

            Console.ReadLine();
        }
                
    }
}
