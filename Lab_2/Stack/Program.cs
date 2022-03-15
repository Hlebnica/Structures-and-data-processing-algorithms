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

            var k = n;
            Console.WriteLine("Содержимое стека:");
            while (k > 0)
            {
                var num = numbers.Pop(); 
                Console.WriteLine(num);
                sum += num;
                temp.Push(num);
                k--;
            }

            double nToDouble = Convert.ToDouble(n); 
            double average = sum/nToDouble; // Среднее элементов стека
            
            numbers.Push(average); // Добавляем среднее число в основной стек
            
            Console.WriteLine($"Среднее арифметическое стека = {average}");

            k = n;
            while (k > 0)
            {
                var tempNumber = temp.Pop();
                numbers.Push(tempNumber);
                k--;
            }

            Console.WriteLine("Содержимое стека с добавленным средним:");
            k = n;
            while (k >= 0)
            {
                Console.WriteLine(numbers.Pop()); 
                k--;
            }
        }
    }
}