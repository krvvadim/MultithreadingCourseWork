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

            // Sequential sort
            var carsSequential = new List<Car>(cars);
            Console.WriteLine("List of cars:");
            PrintCars(carsSequential);
            DateTime time1 = DateTime.Now;
            Sorter.SelectionSort(carsSequential);
            DateTime time2 = DateTime.Now;

            Console.WriteLine("\nTime for sequential sorting: " + time2.Subtract(time1).TotalSeconds + " seconds");

            // Parallel sort
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = 8 }; // Example: using n processors
            var carsParallel = new List<Car>(cars);
            DateTime time3 = DateTime.Now;
            ParallelSorter.ParallelSelectionSort(carsParallel, parallelOptions);
            DateTime time4 = DateTime.Now;

            Console.WriteLine("\nTime for parallel sorting: " + time4.Subtract(time3).TotalSeconds + " seconds");

            Console.WriteLine("\nSequential Sort:");
            PrintCars(carsSequential);

            Console.WriteLine("\nParallel Sort:");
            PrintCars(carsParallel);
        }

        private static void PrintCars(List<Car> cars)
        {
            const int maxToPrint = 30; // Number of elements to print
            for (int i = 0; i < cars.Count && i < maxToPrint; i++)
            {
                Console.WriteLine($"Car {cars[i].Number}: Length = {cars[i].Length:F2}");
            }
        }

    }
}
