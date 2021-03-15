using System;
using System.Collections;
namespace Sort
{
    public class Sort
    {
        public int[] Bubble(int[] array)
        {
            int tmpElement;
            bool isSorting = true;

            while (isSorting)
            {
                isSorting = false;
                for (int i = 0; i < array.Length-1; i++)
                {
                    if(array[i] > array[i + 1])
                    {
                        tmpElement = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = tmpElement;
                        isSorting = true;
                    }
                }
            }
            return array;
        }

    }
}
