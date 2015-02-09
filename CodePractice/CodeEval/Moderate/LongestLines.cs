using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodePractice.CodeEval.Moderate
{
    public class MinPQ<T> where T : IComparable
    {
        private T[] pq;

        private int N = 0;
        private int _capacity = 0;
        private MinPQ()
        {

        }
        public MinPQ(int capacity)
        {
            pq = new T[capacity + 1]; //As Zeroth index is unused
            _capacity = pq.Length - 1; //As Zeroth index is unused
        }

        private void Swim(int start)
        {
            while (start > 1)
            {
                //Compare child with parent 
                if (pq[start].CompareTo(pq[start / 2]) < 0)
                {
                    //if Child < Parent, swap positions
                    Swap(start, start / 2);
                }

                //Move to the parent
                start = start / 2;
            }
        }



        public T Max()
        {
            //Add checks
            return pq[1];
        }

        public void Insert(T item)
        {
            if (N < _capacity)
            {
                pq[++N] = item;
                Swim(N);
            }
            else
            {
                //If incoming element is less than root
                if (item.CompareTo(pq[1]) > 0)
                {
                    pq[1] = item;
                    Sink(1);
                }
            }
        }

        private void Swap(int from, int to)
        {
            var temp = pq[from];
            pq[from] = pq[to];
            pq[to] = temp;
        }

        private void Sink(int start)
        {
            //Take the first child
            var child = start * 2;

            //Verify if we're within the limits
            while (child <= N)
            {
                //check if sibling is also within limit 
                //compare siblings
                if (child + 1 <= N
                    && pq[child + 1].CompareTo(pq[child]) < 0)
                {
                    child++;
                }
                if (pq[child].CompareTo(pq[start]) < 0)
                {
                    Swap(child, start);
                }

                start = child;
                child = start * 2;
            }
        }

        public void Sort()
        {
            for (int i = N; i > 1; i--)
            {
                Swap(i, 1);
                Sink(1);
            }

        }


    }

    public class MaxPQ<T> where T : IComparable
    {
        private T[] pq;

        private int N = 0;
        private int _size = 0;
        private MaxPQ()
        {

        }
        public MaxPQ(int capacity)
        {
            pq = new T[capacity + 1]; //As Zeroth index is unused
            _size = pq.Length - 1; //As Zeroth index is unused
        }

        private void Swim(int start)
        {
            while (start > 1)
            {
                if (pq[start].CompareTo(pq[start / 2]) > 0)
                {
                    Swap(start, start / 2);
                }
                start = start / 2;
            }
        }



        public T Max()
        {
            //Add checks
            return pq[1];
        }

        public void Insert(T item)
        {
            if (N < _size)
            {
                pq[++N] = item;
                Swim(N);
            }
            else
            {
                //If incoming element is less than root
                if (item.CompareTo(pq[1]) < 0)
                {
                    pq[1] = item;
                    Sink(1);
                }
            }
        }

        private void Swap(int from, int to)
        {
            var temp = pq[from];
            pq[from] = pq[to];
            pq[to] = temp;
        }

        private void Sink(int start)
        {
            var child = start * 2;
            while (child <= N)
            {
                if (child + 1 <= N
                    && pq[child + 1].CompareTo(pq[child]) > 0)
                {
                    child++;
                }
                if (pq[child].CompareTo(pq[start]) > 0)
                {
                    Swap(child, start);
                }

                start = child;
                child = start * 2;
            }
        }

        public void Sort()
        {
            for (int i = N; i > 1; i--)
            {
                Swap(i, 1);
                Sink(1);
            }

        }


    }

    public class Liner : IComparable<Liner>, IComparable
    {
        public string Context { get; set; }

        private int length = -1;
        public int Length {
            get
            {
                if (length == -1)
                    length = Context.Length;
                 return length;

            }
          }


        public int CompareTo(Liner other)
        {
            return other.Length.CompareTo(Length);
        }

        public int CompareTo(object obj)
        {
            return CompareTo((Liner)obj);
        }
    }

    public class LongestLines
    {
        public static void Code()
        {
            
            int N = 0;
            MaxPQ<Liner> queue; 
            using (StreamReader reader = File.OpenText(@"D:\Learning\JabsStudyGroup\CodeEval\Data\LongestLines.txt"))
            {
                if (!reader.EndOfStream)
                {
                    N = Convert.ToInt32(reader.ReadLine());
                }

                queue = new MaxPQ<Liner>(N);
                var counter = -1; 
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(line))
                        continue;
                    
                   queue.Insert(new Liner(){ Context = line.Trim()});
                }
            }

            queue.Sort();

            for (int i = N; i > 0; i++)
            {
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        
    }

    
}
