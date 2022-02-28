using System;
using System.Collections.Generic;
using System.Linq;

namespace PR_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово:");
            string inputText = Convert.ToString(Console.ReadLine()); // Ввод слова
            Console.WriteLine("Введите максимальную длину слов:");
            int textLength = Convert.ToInt32(Console.ReadLine()); // Ввод максимальной длины слов
            Console.WriteLine("Введите максимальное количество выводимых слов:");
            int count = Convert.ToInt32(Console.ReadLine()); // Ввод максимального количества выводимых слов
            
            List<string> listWord = new List<string>(); // Список слов
            Random rnd = new Random();
            if (inputText != null)
            {
                string chars = string.Join("", inputText.Distinct()); // Строка из неповторяющихся символов 
            
                for (int i = 0; i < count; i++)
                {
                    string word = "";
                    int len = rnd.Next(0, textLength); // Случайная длина слова
                    for (int j = 0; j < len; j++)
                        word += chars[rnd.Next(chars.Length)]; // Добавление сформированного слова в список
                    listWord.Add(word);
                }
            }

            Console.WriteLine("Полученные слова:");
            foreach (var t in listWord) // Вывод полученных слов
            {
                Console.WriteLine(t);
            }
        }
    }
}