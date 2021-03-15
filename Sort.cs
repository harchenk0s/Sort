﻿using System;
using System.Diagnostics;

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

        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;
            for (int i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }


        public int[] Bubble(int[] array)
        {
            bool isSorting = true;

            while (isSorting)
            {
                isSorting = false;

                for (int i = 0; i < array.Length-1; i++)
                {
                    if(array[i] > array[i + 1])
                    {
                        Swap(ref array[i + 1], ref array[i]);
                        isSorting = true;
                    }
                }
            }
            return array;
        }

        public int[] Shaker(int[] array)
        {
            for (int i = 0; i < array.Length / 2; i++)
            {
                bool isSwap = false;

                for (int j = i; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        isSwap = true;
                    }
                }

                for (int j = array.Length - 2 - i; j > i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        Swap(ref array[j - 1], ref array[j]);
                        isSwap = true;
                    }
                }

                if (!isSwap)
                {
                    break;
                }
            }
            
            return array;
        }

        public int[] Insertion(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i;
                while ((j > 1) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }
            return array;
        }

        int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            int pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

    }
}
