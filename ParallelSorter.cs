using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelectionSort
{
    public static class ParallelSorter
    {
        public static void ParallelSelectionSort<T>(List<T> list, ParallelOptions parallelOptions) where T : IComparable<T>
        {
            int n = list.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int globalMinIndex = i;
                T globalMinValue = list[i];
                object lockObj = new object();

                Parallel.For(i + 1, n, parallelOptions, j =>
                {
                    if (list[j].CompareTo(globalMinValue) < 0)
                    {
                        lock (lockObj)
                        {
                            if (list[j].CompareTo(globalMinValue) < 0)
                            {
                                globalMinValue = list[j];
                                globalMinIndex = j;
                            }
                        }
                    }
                });

                if (globalMinIndex != i)
                {
                    Swap(list, i, globalMinIndex);
                }
            }
        }

        private static void Swap<T>(List<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
