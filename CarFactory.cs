﻿using System.Collections.Generic;

namespace SelectionSort
{
    public static class CarFactory
    {
        private const int NumberOfCars = 10000;

        public static List<Car> GenerateCars()
        {
            var cars = new List<Car>();
            for (int i = 0; i < NumberOfCars; i++)
            {
                cars.Add(new Car(i));
            }
            return cars;
        }
    }
}

