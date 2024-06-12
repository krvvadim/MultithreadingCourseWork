using System;

namespace SelectionSort
{
    public class Car
    {
        public int Number { get; set; }
        public double Wheelbase { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }

        private static Random random = new Random();

        public Car(int number)
        {
            Number = number;
            Wheelbase = random.NextDouble() * (3500.0 - 2000.0) + 2000.0; // Random double between 2000.0 and 3500.0
            Length = random.NextDouble() * (5000.0 - 3000.0) + 3000.0; // Random double between 3000.0 and 5000.0
            Width = random.NextDouble() * (2500.0 - 1500.0) + 1500.0; // Random double between 1500.0 and 2500.0
        }
    }
}
