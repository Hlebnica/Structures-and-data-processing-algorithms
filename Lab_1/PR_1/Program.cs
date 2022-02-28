using System;

/* 1. Дан одномерный целочисленный массив порядка N. 
      Найдите сумму положительных элементов массива. 
      Если таких элементов нет, вернуть значение 0. */

namespace PR_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива N");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            int massSum = 0;

            for (int i = 0; i < n; i++) // Ввод чисел в массив
            {
                Console.WriteLine("Введите число для добавления в массив");
                array[i] = Convert.ToInt32(Console.ReadLine());
                if (array[i] > 0)
                {
                    massSum += array[i];
                }
            }

            for (int i = 0; i < n; i++) // Вывод всех членов массива
            {
                Console.WriteLine($"{i + 1} член массива = {array[i]}");
            }
            
            Console.WriteLine($"Сумма положительных элементов массива = {massSum}");
        }
    }
}