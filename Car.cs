﻿using System;

namespace SelectionSort
{
    public class Car : IComparable<Car>
    {
        public int Number { get; set; }
        public double Wheelbase { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }

        private static Random random = new Random();

        public Car(int number)
        {
            Number = number;
            Wheelbase = random.NextDouble() * (3500.0 - 2000.0) + 2000.0;
            Length = random.NextDouble() * (5000.0 - 3000.0) + 3000.0;
            Width = random.NextDouble() * (2500.0 - 1500.0) + 1500.0;
        }

        public int CompareTo(Car other)
        {
            return this.Length.CompareTo(other.Length);
        }
    }
}
