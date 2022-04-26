using System;
using System.Collections.Generic;

/*
1. Поиск в линейных структурах (бинарный поиск)
Написать программу, которая:
 - запрашивает у пользователя размер массива и ключ поиска;
 - формирует массив случайных чисел;
 - возвращает количество совпадений и их номера.
*/

namespace Search_in_linear_structures
{
    class Program
    {
        private static int BinarySearch(int key, int[] arr) // Бинарный поиск 
        {
            int low = 0; // Нижняя граница массива 
            int high = arr.Length - 1; // Верхняя граница массива

            while (low <= high)
            {
                int midpoint = low + (high - low) / 2; // Середина массива
                
                if (key < arr[midpoint]) // Сдвиг верхней границы
                {
                    high = midpoint;
                }
                else if (key > arr[midpoint]) // Сдвиг нижней границы
                {
                    low = midpoint + 1;
                }
                else
                {
                    return midpoint;
                }
            }
            return -1;
        }

        private static Dictionary<int, List<int>> OccurrenceCount(int key, int[] arr) // Поиск совпадений
        {
            int elements = BinarySearch(key, arr);

            if (elements == -1)
                Console.WriteLine("Элемент не был найден");

            List<int> indexes = new List<int> {elements};

            int count = 1;
            int left = elements - 1;
            while (left >= 0 && arr[left] == key) // Поиск в нижней границе
            {
                indexes.Add(left);
                count++;
                left--;
            }

            int right = elements + 1;
            while (right < arr.Length && arr[right] == key) // Поиск в верхней границе
            {
                indexes.Add(right);
                count++;
                right++;
            }

            Dictionary<int, List<int>> result = new Dictionary<int, List<int>> // Добавление совпадений в словарь
            {
                [count] = indexes
            };

            return result;
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива ");
            int arrSize = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[arrSize];
            Random rnd = new Random();
            
            for (int i = 0; i < arrSize; i++) // Заполнение массива
            {
                array[i] = rnd.Next(-100, 100);
            }
            
            Array.Sort(array); // Сортировка массива

            Console.WriteLine("Отсортированный массив:");
            foreach (var elements in array)
            {
                Console.Write(elements + " ");
            }
            
            Console.WriteLine("\nВведите ключ поиска ");  
            int searchKey = Convert.ToInt32(Console.ReadLine());
            
            var occurrences = OccurrenceCount(searchKey, array);
            foreach (var keyValuePair in occurrences)
            {
                Console.WriteLine($"Количество совпадений элементов = {keyValuePair.Key} \nНомера элементов:");
                foreach (var elements in keyValuePair.Value)
                {
                    Console.Write($"{elements} ");
                }
            }

        }
    }
}