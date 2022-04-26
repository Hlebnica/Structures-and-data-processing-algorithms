using System;
using System.IO;

/*3. Поиск в тексте В текстовом файле хранится текст.
 Осуществить прямой поиск введенного пользователем слова 
 с использованием алгоритма Боуера-Мура*/

namespace TextSearch
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
        
        private static int BmSearch(string pattern, string txt)
        {
            byte[] shiftArray = new byte[0x10000]; // сдвиг массива

            for (int i = 0; i < shiftArray.Length; i++)
            {
                shiftArray[i] = (byte)pattern.Length;
            }
            for (int i = 0; i < pattern.Length - 1; i++)
            {
                shiftArray[pattern[i]] = (byte)(pattern.Length - i - 1);
            }

            int startIndex = 0;
            int k = startIndex;
            
            while (k <= txt.Length - pattern.Length) // цикл, пока есть место для элемента поиска
            {
                int j = pattern.Length - 1; // проверка, есть ли совпадение в текущей позиции
                while (j >= 0 && pattern[j] == txt[k + j])
                {
                    j--;
                }
                if (j < 0)
                {
                    return k; // совпадение найдено
                }
                k += Math.Max(shiftArray[txt[k + j]] - pattern.Length + 1 + j, 1); // переход к следующему сравнению
            }
            return -1; // элемент поиска не найден
        }
        
        
        public static void Main(string[] args)
        {
            string inputText = GetTextFromFile("text.txt");
            Console.WriteLine("Текст в файле: " + inputText);
            
            Console.Write("Введите строку для поиска: ");
            string key = Console.ReadLine();

            Console.WriteLine("Индекс найденного слова " + BmSearch(key, inputText));
        }
    }
}