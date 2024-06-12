using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    public static class ParallelSelectionSort
    {
        public static async Task<int[]> ParallelSort(int[] array)
        {
            int numThreads = Math.Min(Environment.ProcessorCount, array.Length); // Limit threads to processors
            List<Task> tasks = new List<Task>();

            // Divide the array into chunks for parallel processing
            int chunkSize = array.Length / numThreads;
            int remaining = array.Length % numThreads;

            for (int i = 0; i < numThreads; i++)
            {
                int startIndex = i * chunkSize;
                int endIndex = (i == numThreads - 1) ? startIndex + chunkSize + remaining - 1 : startIndex + chunkSize - 1;

                tasks.Add(Task.Run(() => ParallelSelectionSortChunk(array, startIndex, endIndex)));
            }

            await Task.WhenAll(tasks); // Wait for all tasks to finish

            // Since each chunk is sorted independently, a final merge step is needed
            return MergeSortedChunks(array);
        }

        private static int[] ParallelSelectionSortChunk(int[] array, int startIndex, int endIndex)
        {
            int temp, smallest;
            for (int i = startIndex; i <= endIndex; i++)
            {
                smallest = i;
                for (int j = i + 1; j <= endIndex; j++)
                {
                    if (array[j] < array[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = array[smallest];
                array[smallest] = array[i];
                array[i] = temp;
            }
            return array;
        }

        private static int[] MergeSortedChunks(int[] array)
        {
            // Implement your preferred merge logic here (e.g., using two pointers)
            // This example uses a simple bubble sort for the final merge
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }
    }
}

