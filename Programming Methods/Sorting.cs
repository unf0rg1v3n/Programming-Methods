using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Methods
{
    public static class Sort
    {
        public static T[] BubbleSort<T>(T[] arr) where T : IComparable<T>
        {
            int size = arr.Length;
            T[] result = new T[size];
            arr.CopyTo(result, 0);

            for (int j = 0; j < size - 1; j++)
            {
                for (int i = 0; i < size - 1 - j; i++)
                {
                    if (result[i].CompareTo(result[i + 1]) >= 0)
                    {
                        T temp = result[i];
                        result[i] = result[i + 1];
                        result[i + 1] = temp;
                    }
                }
            }
            return result;
        }

        public static T[] QuickSort<T>(T[] array) where T : IComparable<T>
        {
            T[] sortedArray = (T[])array.Clone();
            QuickSortArray(sortedArray, 0, sortedArray.Length - 1);
            return sortedArray;
        }

        private static void QuickSortArray<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right);

                QuickSortArray(array, left, pivotIndex - 1);
                QuickSortArray(array, pivotIndex + 1, right);
            }
        }

        private static int Partition<T>(T[] array, int left, int right) where T : IComparable<T>
        {
            T pivot = array[right];
            int wall = left;

            for (int j = left; j < right; j++)
            {
                if (array[j].CompareTo(pivot) <= 0)
                {
                    Swap(array, wall, j);
                    wall++;
                }
            }
            Swap(array, wall, right);

            return wall;
        }

        private static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    

    public static T[] MergeSort<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length <= 1)
                return array;

            int middle = array.Length / 2;
            T[] left = new T[middle];
            T[] right = new T[array.Length - middle];

            Array.Copy(array, 0, left, 0, middle);
            Array.Copy(array, middle, right, 0, array.Length - middle);

            left = MergeSort(left);
            right = MergeSort(right);


            return Merge(left, right);
        }

        // Функция для слияния двух отсортированных массивов
        private static T[] Merge<T>(T[] left, T[] right) where T : IComparable<T>
        {
            T[] result = new T[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            // Слияние до тех пор, пока есть элементы в обоих массивах
            while (i < left.Length && j < right.Length)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    result[k++] = left[i++];
                }
                else
                {
                    result[k++] = right[j++];
                }
            }

            // Копирование оставшихся элементов из левого массива
            while (i < left.Length)
            {
                result[k++] = left[i++];
            }

            // Копирование оставшихся элементов из правого массива
            while (j < right.Length)
            {
                result[k++] = right[j++];
            }

            return result;
        }
    }
}
