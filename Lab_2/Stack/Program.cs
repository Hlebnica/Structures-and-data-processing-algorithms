using System;
using System.Collections.Generic;


/*  34.	Сформировать стек из N чисел. Найти среднее
        арифметическое элементов стека и поместить его в начало стека*/

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел:");
            int n = Convert.ToInt32(Console.ReadLine()); // Считываем количество чисел в стеке
            
            Stack<double> numbers = new Stack<double>(); // Инициализация стека
            Stack<double> temp = new Stack<double>(); // Инициализация временного стека
            Random rnd = new Random();
            double sum = 0; // Сумма чисел в стеке

            for (int i = 0; i < n; i++) // Добавление случайных чисел в стек
            {
                numbers.Push(rnd.Next(-10, 10));
            }
            
            Console.WriteLine("Содержимое стека:");
            foreach (var number in numbers) // Вывод содержимого стека и подсчет суммы положительных элементов
            {
                Console.WriteLine(number);
                sum += number; // Считаем сумму чисел в стеке
                temp.Push(number); // Добавляем числа из основого стека во временный
            }

            double nToDouble = Convert.ToDouble(n); 
            double average = sum/nToDouble; // Среднее элементов стека
            
            numbers.Clear(); // Очищаем основной стек
            numbers.Push(average); // Добавляем среднее число в основной стек
            
            Console.WriteLine($"Среднее арифметическое стека = {average}");

            foreach (var number in temp) // Возврат чисел из временного стека в основной
            {
                numbers.Push(number); 
            }
            
            Console.WriteLine("Содержимое стека с добавленным средним:");
            foreach (var number in numbers) // Вывод содержимого стека
            {
                Console.WriteLine(number);
            }
        }
    }
}