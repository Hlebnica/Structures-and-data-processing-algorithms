using System;
using System.Collections;
using System.IO;

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
            
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            
            var chars = str?.ToCharArray();
            foreach (var c in chars)
            {
                Console.Write(c + " ");
            }
            
        }
    }
}