using System;
using System.Collections.Generic;

namespace SelectionSort
{
    public static class Sorter
    {
        public static void SelectionSort(List<Car> cars)
        {
            int n = cars.Count;
            for (int i = 0; i < n - 1; i++)
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
            }
        }

        private static void Swap(List<Car> cars, int i, int j)
        {
            var temp = cars[i];
            cars[i] = cars[j];
            cars[j] = temp;
        }
    }
}

