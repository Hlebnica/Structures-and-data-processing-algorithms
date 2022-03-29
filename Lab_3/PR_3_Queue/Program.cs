using System;
using System.Collections.Generic;

/*Удалить первый и последний элементы очереди целых чисел.*/

namespace PR_3_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество чисел:");
            int n = Convert.ToInt32(Console.ReadLine()); // Считываем количество чисел в очереди
            
            Queue<int> numbers = new Queue<int>();
            Queue<int> temp = new Queue<int>();
            
            Random rnd = new Random();
            
            for (int i = 0; i < n; i++) // Добавление случайных чисел в очередь
            {
                numbers.Enqueue(rnd.Next(-10, 10));
            }

            Queue<int> newNumbers = new Queue<int>(numbers); // Копируем содержимое основной очереди, чтобы показать хранящиеся элементы
            var k = n;
            Console.WriteLine("Содержимое очереди:");
            while (k > 0)
            {
                var num = newNumbers.Dequeue();
                Console.WriteLine(num);
                k--;
            }
            
            k = n;
            Console.WriteLine("Содержимое очереди без последнего элемента:");
            while (k > 1)
            {
                var num = numbers.Dequeue();
                Console.WriteLine(num);
                temp.Enqueue(num); // перенос в temp всех элементов очереди кроме последнего
                k--;
            }
            
            numbers.Clear(); // очищаем очередь от оставшегося числа
            temp.Dequeue(); // убираем первый элемент из временного стека
            
            k = n - 2;
            while (k > 0) // перенос из temp в основную очередь
            {
                var num = temp.Dequeue();
                numbers.Enqueue(num);
                k--;
            }
            
            Console.WriteLine("Содержимое очереди без первого и последнего элемента:");
            k = n - 2;
            while (k > 0) // Вывод чисел из основной очереди
            {
                var num = numbers.Dequeue(); 
                Console.WriteLine(num);
                k--;
            }
        }
    }
}