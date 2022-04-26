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
                    letters.Add(keyValuePair.Value, keyValuePair.Key); 
                }
            }

           
        }
    }
}