using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelectionSort
{
    public static class ParallelSorter
    {
        public static void ParallelSelectionSort(List<Car> cars, ParallelOptions parallelOptions)
        {
            int n = cars.Count;
            Parallel.For(0, n - 1, parallelOptions, i =>
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (cars[j].Length < cars[minIndex].Length)
                    {
                        minIndex = j;
                    }
                }
                Swap(cars, i, minIndex);
            });
        }

        private static void Swap(List<Car> cars, int i, int j)
        {
            lock (cars)
            {
                var temp = cars[i];
                cars[i] = cars[j];
                cars[j] = temp;
            }
        }
    }
}

