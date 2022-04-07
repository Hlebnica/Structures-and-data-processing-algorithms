using System;
using System.Diagnostics;

/*Отсортировать одномерный массив целых чисел по убыванию.
Сортировки: простым включением и пузырькая*/

namespace Lab_5
{
    internal class Program
    {
        static void BubbleSort(int[] mas) // пузырьковая сортировка
        {
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] < mas[j])
                    {
                        (mas[i], mas[j]) = (mas[j], mas[i]);
                    }                   
                }            
            }
        }

        static void SortInsertMethod(int[] mas) // сортировка включением
        {
            for (int i = 0; i < mas.Length; i++)
            {
                var x = mas[i];
                int j;
                for (j = i - 1; j >= 0 && mas[j] < x; j--)
                    mas[j + 1] = mas[j];
 
                mas[j + 1] = x;
            }
        }

        static void SortCheck(int[] unsortedMas, int[] halfSortedMas, int[] reversedSortedMas, Func<int[]> sort)
        {
            
        }
        
        public static void Main(string[] args)
        {
            int[] unsorted = new int[] {10, 1, 0, 60, 30, 20, 48, 99, 10000, 5, 3, 11, 29, 44, 12}; 
            int[] halfSorted = new int[] {10, 1, 0, 60, 30, 20, 48, 99, 10000, 44, 29, 12, 11, 5, 3};
            int[] reversedSorted = new int[] {0, 3, 5, 10, 11, 12, 29, 30, 44, 48, 60, 99, 10000};
            

            //BubbleSort(mas);
            //SortInsertMethod(mas2);
            
            Console.WriteLine("После сортировки:");
            /*foreach (var t in mas)
            {
                Console.WriteLine(t);
            }
            foreach (var t in halfSorted)
            {
                Console.WriteLine(t);
            }*/
        }
    }
}