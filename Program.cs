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
            //PrintCars(carsSequential);
            DateTime time1 = DateTime.Now;
            Sorter.SelectionSort(carsSequential);
            DateTime time2 = DateTime.Now;

            Console.WriteLine("\nTime for sequential sorting: " + time2.Subtract(time1).TotalSeconds * 1000000 + " microseconds");

            //Console.WriteLine("\nSequential Sort:");
            //PrintCars(carsSequential);

            int[] array = new int[3] { 2, 4, 8 };
            for (int i = 0; i < array.Length; i++)
            {
                // Parallel sort
                var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = array[i] }; // Example: using n processors
                var carsParallel = new List<Car>(cars);
                //Console.WriteLine("\nList of cars:");
                //PrintCars(carsParallel);
                DateTime time3 = DateTime.Now;
                ParallelSorter.ParallelSelectionSort(carsParallel, parallelOptions);
                DateTime time4 = DateTime.Now;

                Console.WriteLine("\nTime for parallel sorting " + array[i] + ": " + time4.Subtract(time3).TotalSeconds * 1000000 + " microseconds");

                //Console.WriteLine("\nParallel Sort:");
                //PrintCars(carsParallel);
            }
        }

        private static void PrintCars(List<Car> cars)
        {
            const int maxToPrint = 15; // Number of elements to print
            Console.WriteLine("First 15 cars:");
            for (int i = 0; i < maxToPrint; i++)
            {
                Console.WriteLine($"Car {cars[i].Number}: Length = {cars[i].Length:F2}");
            }
            Console.WriteLine("\nLast 15 cars:");
            for (int i = cars.Count - maxToPrint; i < cars.Count; i++)
            {
                Console.WriteLine($"Car {cars[i].Number}: Length = {cars[i].Length:F2}");
            }
        }
    }
}
