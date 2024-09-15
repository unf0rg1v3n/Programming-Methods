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

        public static T[] QuickSort<T>(in T[] arr) where T : IComparable
        {
            if (arr.Length <= 1) return arr;

            T pivot = arr[arr.Length / 2];
            T[] less = arr.Where(x => x.CompareTo(pivot) < 0).ToArray();
            T[] greater = arr.Where(x => x.CompareTo(pivot) > 0).ToArray();

            return QuickSort(less).Concat(new[] { pivot }).Concat(QuickSort(greater)).ToArray();
        }

        public static T[] MergeSort<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length <= 1)
                return array;

            // Разбиение массива на две части
            int middle = array.Length / 2;
            T[] left = new T[middle];
            T[] right = new T[array.Length - middle];

            Array.Copy(array, 0, left, 0, middle);
            Array.Copy(array, middle, right, 0, array.Length - middle);

            // Рекурсивная сортировка каждой части
            left = MergeSort(left);
            right = MergeSort(right);

            // Слияние отсортированных частей
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
