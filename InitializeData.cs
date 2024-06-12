using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectionSort
{
    public static class InitializeData
    {
        public static int[] InitData()
        {
            Random rnd = new Random();

            int[] arraySize = new int[4];
            int[] array = new int[100000];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 10000);
            }

            return array;
        }       
    }
}
