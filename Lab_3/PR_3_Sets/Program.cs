using System;
using System.Linq;
using System.Collections.Generic;

/*
Пусть дан текст, состоящий из 
строчных латинских букв и цифр. Определить, 
каких букв – гласных или согласных – больше в этом тексте.
*/

namespace PR_3_Sets
{
    class Program
    {
        private static readonly HashSet<char> Vowels = new("aeiouy"); // Множество гласных букв
        private static readonly HashSet<char> Consonants = new("bcdfghjklmnpqrstvwxz"); // Множество согласных букв
        static void Main(string[] args)
        {
            Console.WriteLine("Введите слово");
            string text = Console.ReadLine()?.ToLower(); // Считывание строки и перевод в нижний регистр
            
            int vowelsCount = text.Count(x => Vowels.Contains(x)); // Подсчет гласных букв
            int consonantsCount = text.Count(x => Consonants.Contains(x)); // Подсчет согласных букв

            if (vowelsCount > consonantsCount)
                Console.WriteLine("Гласных больше");
            if (vowelsCount < consonantsCount)
                Console.WriteLine("Согласных больше");
            if (vowelsCount == consonantsCount)
                Console.WriteLine("Количество гласных и согласных равны");
        }
    }
}