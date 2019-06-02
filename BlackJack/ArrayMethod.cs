using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    //building deck to make sure no duplicates
    class ArrayMethod
    {
        public static bool ArrayContainsValue(int[] array, int value)
        {
            for (var i = 0; i < array.Length; i++)
            {
                //if array already contains value
                if (array[i] == value)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
