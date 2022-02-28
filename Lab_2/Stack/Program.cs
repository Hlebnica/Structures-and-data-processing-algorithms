using System;
using System.Collections.Generic;


/*1.	Заполнить стек N случайными числами из интервала [–10; 20]. 
Просмотреть содержимое стека. Найти сумму положительных чисел, хранящихся в стеке.*/

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел:");
            int n = Convert.ToInt32(Console.ReadLine());
            Stack<int> numbers = new Stack<int>(); // Инициализация стека
            Random rnd = new Random();
            int sum = 0; // Сумма положительных членов стека
            
            for (int i = 0; i < n; i++) // Добавление случайных чисел в стек
            {
                numbers.Push(rnd.Next(-10, 20));
            }
            
            Console.WriteLine("Содержимое стека:");
            foreach (var number in numbers) // Вывод содержимого стека и подсчет суммы положительных элементов
            {
                Console.WriteLine(number);
                if (number > 0)
                {
                    sum += number;
                }
            }
            
            Console.WriteLine($"Сумма положительных элементов стека = {sum}");
        }
    }
}