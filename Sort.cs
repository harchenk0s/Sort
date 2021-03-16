using System;
using System.Diagnostics;

namespace Sort
{
    public static class Sort
    {
        static void Swap<T>(ref T v1, ref T v2)
        {
            T tmpV = v1;
            v1 = v2;
            v2 = tmpV;
        }

        static int Partition(int[] array, int minIndex, int maxIndex) // For Quick Sort
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


        static int GetNextStep(int s) // For Comb Sort
        {
            s = s * 1000 / 1247;
            return s > 1 ? s : 1;
        }


        public static int[] Bubble(int[] array)
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


        public static int[] Shaker(int[] array)
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


        public static int[] Insertion(int[] array)
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


        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
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


        public static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }


        public static int[] Gnome(int[] array)
        {
            int index = 1;
            int nextIndex = index + 1;

            while (index < array.Length)
            {
                if (array[index - 1] < array[index])
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    Swap(ref array[index - 1], ref array[index]);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }
                }
            }

            return array;
        }


        public static int[] Shell(int[] array)
        {
            int d = array.Length / 2;
            while (d >= 1)
            {
                for (int i = d; i < array.Length; i++)
                {
                    int j = i;
                    while ((j >= d) && (array[j - d] > array[j]))
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }

                d = d / 2;
            }

            return array;
        }


        public static int[] CombSort(int[] array)
        {
            int arrayLength = array.Length;
            int currentStep = arrayLength - 1;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    if (array[i] > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }

                currentStep = GetNextStep(currentStep);
            }

            for (int i = 1; i < arrayLength; i++)
            {
                bool swapFlag = false;
                for (int j = 0; j < arrayLength - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                {
                    break;
                }
            }

            return array;
        }
    }
}
