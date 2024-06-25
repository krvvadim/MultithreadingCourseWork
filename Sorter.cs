using System;
using System.Collections.Generic;

namespace SelectionSort
{
    public static class Sorter
    {
        public static void SelectionSort<T>(List<T> list) where T : IComparable<T>
        {
            int n = list.Count;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (list[j].CompareTo(list[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                Swap(list, i, minIndex);
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

