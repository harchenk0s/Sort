using System;

namespace Sort
{
    public class Sort
    {
        static void Swap<T>(ref T v1, ref T v2)
        {
            T tmpV = v1;
            v1 = v2;
            v2 = tmpV;
        }

        public int[] Bubble(int[] array)
        {
            Console.WriteLine("Bubble Sort");
            int arrayAccess = 0;
            int actions = 0;
            bool isSorting = true;

            while (isSorting)
            {
                isSorting = false;

                for (int i = 0; i < array.Length-1; i++)
                {
                    arrayAccess++;
                    if(array[i] > array[i + 1])
                    {
                        actions++;
                        Swap(ref array[i + 1], ref array[i]);
                        isSorting = true;
                    }
                }
            }
            Console.WriteLine($"Actions: {actions}, Accesses: {arrayAccess}");
            return array;
        }

        public int[] Shaker(int[] array)
        {
            Console.WriteLine("Shaker Sort");
            int actions = 0;
            int accessions = 0;
            for (int i = 0; i < array.Length / 2; i++)
            {
                bool isSwap = false;

                for (int j = i; j < array.Length - i - 1; j++)
                {
                    accessions++;
                    if (array[j] > array[j + 1])
                    {
                        actions++;
                        Swap(ref array[j], ref array[j + 1]);
                        isSwap = true;
                    }
                }

                for (int j = array.Length - 2 - i; j > i; j--)
                {
                    accessions++;
                    if (array[j - 1] > array[j])
                    {
                        actions++;
                        Swap(ref array[j - 1], ref array[j]);
                        isSwap = true;
                    }
                }

                if (!isSwap)
                {
                    actions++;
                    break;
                }
            }
            Console.WriteLine($"Actions: {actions}, Accesses: {accessions}");
            return array;
        }

    }
}
