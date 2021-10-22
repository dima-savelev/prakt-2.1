using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_13
{
    public class Practice
    {
        public static void Multiply(int[] array, out int rezult)
        {
            rezult = 1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 2)
                {
                    if (rezult > int.MaxValue / array[i]) rezult = int.MaxValue;
                    else rezult = array[i] * rezult;
                }
            }
        }
    }
}
