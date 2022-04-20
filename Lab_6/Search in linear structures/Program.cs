using System;

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
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива ");
            int arrSize = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[arrSize];
            Random rnd = new Random();
            
            for (int i = 0; i < arrSize; i++)
            {
                array[i] = rnd.Next(-10, 10);
                Console.Write(array[i] + " ");
            }
            
            Array.Sort(array);
            
            
        }
    }
}