using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelectionSort
{
    public static class Program
    {
        public static void Main()
        {
            var cars = CarFactory.GenerateCars();

            //Sequential sort
            var carsSequential = new List<Car>(cars);
            //Console.WriteLine("List of cars:");
            //PrintList(carsSequential);
            DateTime time1 = DateTime.Now;
            Sorter.SelectionSort(carsSequential);
            DateTime time2 = DateTime.Now;

            Console.WriteLine("\nTime for sequential sorting: " + time2.Subtract(time1).TotalSeconds * 1000000 + " microseconds");

            Console.WriteLine("Is sequentially sorted list correct? " + IsSorted(carsSequential));
            //Console.WriteLine("\nSequential Sort:");
            //PrintList(carsSequential);

            int[] array = new int[3] { 2, 4, 8 };
            for (int i = 0; i < array.Length; i++)
            {
                // Parallel sort
                var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = array[i] }; // Example: using n processors
                var carsParallel = new List<Car>(cars);

                //Console.WriteLine("\nList of cars:");
                //PrintList(carsParallel);
                DateTime time3 = DateTime.Now;
                ParallelSorter.ParallelSelectionSort(carsParallel, parallelOptions);
                DateTime time4 = DateTime.Now;

                Console.WriteLine("\nTime for parallel sorting using " + array[i] + " processors: " + time4.Subtract(time3).TotalSeconds * 1000000 + " microseconds");

                Console.WriteLine("Is parallel sorted list correct? " + IsSorted(carsParallel));
                Console.WriteLine("Speedup: " + (time2.Subtract(time1).TotalSeconds * 1000000) / (time4.Subtract(time3).TotalSeconds * 1000000));

                //Console.WriteLine("\nParallel Sort:");
                //PrintList(carsParallel);
            }
        }

        private static bool IsSorted<T>(List<T> list) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i].CompareTo(list[i + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }

        private static void PrintList<T>(List<T> list) where T : IComparable<T>
        {
            const int maxToPrint = 15; 

            Console.WriteLine("First 15 elements:");
            for (int i = 0; i < maxToPrint; i++)
            {
                PrintElement(list[i]);
            }

            Console.WriteLine("\nLast 15 elements:");
            for (int i = list.Count - maxToPrint; i < list.Count; i++)
            {
                PrintElement(list[i]);
            }
        }

        private static void PrintElement<T>(T element)
        {
            var properties = element.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var value = prop.GetValue(element);
                Console.Write($"{prop.Name} = {value}, ");
            }
            Console.WriteLine();
        }
    }
}
