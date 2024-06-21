using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelectionSort
{
    public static class ParallelSorter
    {
        public static void ParallelSelectionSort(List<Car> cars, ParallelOptions parallelOptions)
        {
            int n = cars.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int globalMinIndex = i;

                // Create a shared variable to track the minimum value found by parallel tasks
                double globalMinValue = cars[i].Length;

                object lockObj = new object();

                Parallel.For(i + 1, n, parallelOptions, j =>
                {
                    // Find local minimum in parallel
                    if (cars[j].Length < globalMinValue)
                    {
                        lock (lockObj)
                        {
                            if (cars[j].Length < globalMinValue)
                            {
                                globalMinValue = cars[j].Length;
                                globalMinIndex = j;
                            }
                        }
                    }
                });

                // Swap the found global minimum with the current element
                if (globalMinIndex != i)
                {
                    Swap(cars, i, globalMinIndex);
                }
            }
        }

        //public static void ParallelSelectionSort1(List<Car> cars, ParallelOptions parallelOptions)
        //{
        //    int n = cars.Count;
        //    Parallel.For(0, n - 1, parallelOptions, i =>
        //    {
        //        int minIndex = i;
        //        for (int j = i + 1; j < n; j++)
        //        {
        //            if (cars[j].Length < cars[minIndex].Length)
        //            {
        //                minIndex = j;
        //            }
        //        }
        //        Swap(cars, i, minIndex);
        //    });
        //}

        private static void Swap(List<Car> cars, int i, int j)
        {
            var temp = cars[i];
            cars[i] = cars[j];
            cars[j] = temp;
        }
    }
}
