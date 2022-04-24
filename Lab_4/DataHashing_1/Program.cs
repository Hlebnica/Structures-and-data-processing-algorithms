using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            
            Console.Write("Введите слово: ");
            string text = Console.ReadLine();
            if (text != null)
            {
                Dictionary<char, int> dictionary = text.GroupBy(x => x)
                    .ToDictionary(x => x.Key, x => x.Count());
                foreach (KeyValuePair<char, int> keyValuePair in dictionary)
                {
                    Console.WriteLine("{0} : {1}", keyValuePair.Key, keyValuePair.Value);
                }
            }

            
        }
    }
}