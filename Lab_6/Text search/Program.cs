using System;
using System.IO;

/*3. Поиск в тексте
В текстовом файле хранится текст. Осуществить прямой поиск введенного 
пользователем слова с использованием алгоритма Боуера-Мура*/

namespace Text_search
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
            string text = GetTextFromFile("text.txt");
            Console.WriteLine(text);
        }
    }
}