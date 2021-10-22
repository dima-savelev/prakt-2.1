using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace LibMas
{
    public class ArrayOperation
    {
        public static void SaveArray(int[] array, string path)
        {
           using (StreamWriter save = new StreamWriter(path))
           {
                save.WriteLine(array.Length);
             for (int i = 0; i < array.Length; i++)
             {
               save.WriteLine(array[i]);
             }
           }
        }
        public static void OpenArray(out int[] array, string path)
        {
            using (StreamReader open = new StreamReader(path))
            {
                array = new int[Convert.ToInt32(open.ReadLine())];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = Convert.ToInt32(open.ReadLine());
                }
            }
        }
        public static void ClearArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }
        }
        public static void FillArray(int[] array, int fillValue)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = fillValue;
            }
        }
        public static void FillArrayRandom(int[] array, int minValue, int maxValue)
        {
            Random randomNumber = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomNumber.Next(minValue, maxValue);
            }
        }
    }
}
