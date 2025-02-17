using System;

namespace SortingAlgorithms
{
    static class Sorting
    {
        public static void BubbleSort(int[] array)
        {
            bool collectionChanged = true;
            int temp = 0;

            while (collectionChanged)
            {
                collectionChanged = false;

                for (int i = 1; i < array.Length; i++)
                {
                    if (array[i - 1] > array[i])
                    {
                        collectionChanged = true;

                        temp = array[i - 1];
                        array[i - 1] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }

        public static void InsertionSort(int[] array)
        {
            int sortedLength = 1;

            int position = 0;

            while (sortedLength < array.Length)
            {
                position = sortedLength;

                while (position > 0)
                {
                    if (array[position - 1] > array[position])
                        (array[position - 1], array[position]) = (array[position], array[position - 1]);
                    else
                        break;

                    position--;
                }

                sortedLength++;
            }
        }

        public static void SelectionSort(int[] array)
        {
            int min = 0;
            int min_index = 0;

            for (int position = 0; position < array.Length - 1; position++)
            {
                min = array[position];
                min_index = position;

                for (int i = position; i < array.Length; i++)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                        min_index = i;
                    }
                }

                (array[position], array[min_index]) = (array[min_index], array[position]);
            }
        }

        public static void MergeSort(int[] array)
        {
            int length = array.Length;
            if (length < 2)
                return;
            else if (length == 2 && array[0] > array[length - 1])
            {
                (array[0], array[length - 1]) = (array[length - 1], array[0]);
                return;
            }

            int midpoint = length >> 1;

            int[] arrayL = new int[midpoint];
            int[] arrayR = new int[length - midpoint];
            Array.Copy(array, 0, arrayL, 0, midpoint - 1);
            Array.Copy(array, midpoint, arrayR, 0, length - midpoint);
            MergeSort(arrayL);
            MergeSort(arrayR);

            int sortedLength = midpoint;

            int positionL = 0, positionR = 0;

            for (int i = 0; i < length; i++)
            {
                if (positionR >= arrayR.Length)
                {
                    array[i] = arrayL[positionL];
                    positionL++;
                }
                else if (positionL >= arrayL.Length)
                {
                    array[i] = arrayR[positionR];
                    positionR++;
                }
                else
                {
                    if (arrayL[positionL] > arrayR[positionR])
                    {
                        array[i] = arrayR[positionR];
                        positionR++;
                    }
                    else
                    {
                        array[i] = arrayL[positionL];
                        positionL++;
                    }
                }
            }
        }
    }
}
