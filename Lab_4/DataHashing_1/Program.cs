using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


/*
Составьте хеш-таблицу, содержащую буквы и количество 
их вхождений во введенной строке. Вывести таблицу на экран.
Осуществить поиск введенной буквы в хеш-таблице.
*/

namespace DataHashing_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Hashtable letters = new Hashtable();
            
            Console.Write("Введите строку: ");
            string text = Console.ReadLine();
            if (text == null) return;
            Dictionary<char, int> dictionary = text.GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count()); // Группировка и подсчет уникальных символов с помщением в словарь
            foreach (var keyValuePair in dictionary)
            {
                if (char.IsWhiteSpace(keyValuePair.Key) == false)
                {
                    letters.Add(keyValuePair.Key, keyValuePair.Value); // Перемещение 
                }
            }

            ICollection keys = letters.Keys;

            Console.WriteLine("Хеш-таблица: ");
            foreach (var letter in keys)
            {
                Console.WriteLine($"{letter} : {letters[letter]}");
            }
            
            Console.WriteLine("Введите действие, которое хотите сделать\n" +
                              "1. Поиск по букве\n" +
                              "2. Поиск по числу");

            string action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    Console.WriteLine("Введите букву для поиска");
                    char valueForSearch = Convert.ToChar(Console.ReadLine() ?? string.Empty);
                    foreach (char letter in keys)
                    {
                        if (letter == valueForSearch)
                        {
                            Console.WriteLine($"{letter} : {letters[letter]}");
                        }
                    }
                    break;
                case "2":
                    
                    break;
            }
        }
    }
}