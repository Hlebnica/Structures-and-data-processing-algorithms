using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

/*
Постройте хеш-таблицу из слов произвольного текстового файла, задав ее размерность с экрана.
Выведите построенную таблицу слов на экран. Осуществите поиск введенного слова.
Выполните программу для различных размерностей таблицы и сравните количество сравнений. 
Удалите все слова, начинающиеся на указанную букву, выведите таблицу.
*/

namespace DataHashing_2
{
    class Program
    {
        private static string GetTextFromFile(string name)
        {
            string text;
            using (StreamReader reader = new StreamReader(name))
            {
                text = reader.ReadLine();
            }
            return text;
        }
        
        public static void Main(string[] args)
        {
            string inputText = GetTextFromFile("text.txt");
            Console.WriteLine("Текст в файле: " + inputText);
        }
    }
}