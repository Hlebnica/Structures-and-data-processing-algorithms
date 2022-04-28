using System;
using System.Collections;
using System.Collections.Generic;

/*
Составьте хеш-таблицу, содержащую буквы и количество 
их вхождений во введенной строке. Вывести таблицу на экран.
Осуществить поиск введенной буквы в хеш-таблице.
*/

namespace DataHashing_1
{
    internal class Program
    {
        public class HashTableChar
        {
            private Dictionary<int, LinkedList<char>> items;

            public HashTableChar(int n)
            {
                items = new Dictionary<int, LinkedList<char>>(n);
            }

            public bool ContainsChar(char value)
            {
                foreach (var item in items)
                {
                    if (item.Value.Contains(value)) return true;
                }
                return false;
            }

            public void Insert(int key, char value)
            {
                //var item = new Item<char>(key, value);
                var item = new Item
                var hash = HF(item.key);

                if (items.ContainsKey(hash))
                {
                    items[hash].Add(item);
                }
                else
                {
                    LinkedList<char> hashTableItem = new() { item };
                    items.Add(hash, hashTableItem);
                }
            }

            public void Search(int key)
            {
                var hash = HF(key);

                foreach (var item in items[hash])

                    Console.Write($"{item.value} ");
            }

            private int HF(int value)
            {
                return value;
            }

            public void Output()
            {
                foreach (var item in items)
                {
                    if (!item.Value.IsEmpty()) Console.Write("\n[{0}]", item.Key);
                    foreach (var word in item.Value)
                    {
                        Console.Write("==>|{0, 2} |", word.value);
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string line = Console.ReadLine();
            Hashtable table0 = new Hashtable();

            int max = 0;
            foreach (char ch in line)
            {
                if (Char.IsLetter(ch))
                {
                    if (!table0.ContainsKey(ch))
                    {
                        table0.Add(ch, 1);
                    }
                    else
                    {
                        int count = (int)table0[ch];
                        count++;
                        table0[ch] = count;
                        if (count > max) max = count;
                    }
                }
            }

            HashTableChar table = new(max);

            foreach (char ch in line)
            {
                if (Char.IsLetter(ch))
                {
                    if (!table.ContainsChar(ch)) table.Insert((int)table0[ch], ch);
                }
            }

            table.Output();

            Console.Write("\n\nВведите количество: ");
            int number = Convert.ToInt32(Console.ReadLine());
            table.Search(number);
            
        }
    }
}