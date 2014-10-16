using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    public class MinPQ<T> where T : IComparable
    {
        private T[] pq;

        private int N = 0;
        private int _size = 0;
        private MinPQ()
        {
            
        }
        public MinPQ(int capacity)
        {
            pq = new T[capacity + 1]; //As Zeroth index is unused
            _size = pq.Length - 1; //As Zeroth index is unused
        }

        private void Swim(int start)
        {
            while (start > 1)
            {
                if (pq[start].CompareTo(pq[start/2]) < 0)                
                {
                    Swap(start, start/2);
                }
                start = start/2;
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
                pq[N++] = item;
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
            var child = start*2;
            while (child <= N)
            {
                if (pq[child + 1].CompareTo(pq[child]) < 0)
                {
                    child++;
                }
                if (pq[child].CompareTo(pq[start]) < 0)
                {
                   Swap(child, start);
                }

                start = child;
                child = start*2;
            }
        }

        public void Sort()
        {
            
            for (int i = N - 1; i > 1; i++)
            {
                Swap(i, 1);
                Sink(1);
            }            
        }


    }
}
