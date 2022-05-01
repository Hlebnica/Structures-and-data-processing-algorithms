using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
В текстовом файле содержатся целые числа. Постройте хеш-таблицу из чисел файла. 
Осуществите поиск введенного целого числа в хеш-таблице. 
Сравните результаты количества сравнений при различном наборе данных в файле.
*/

namespace DataHashing_3
{
    class Program
    {
        public class Item<T>
        {
            public int Key;
            public T Value;


            public Item(int key, T value)
            {
                Key = key;
                Value = value;
            }

            public Item<T> Next { get; set; }
        }

        private class LinkedList<T> : IEnumerable<Item<T>>
        {
            Item<T> _head = null;
            Item<T> _tail = null;
            private int _count = 0;

            public void Add(Item<T> item)
            {
                if (_head == null) _head = item;
                else _tail.Next = item;

                _tail = item;
                _count++;
            }

            public bool Contain(T value)
            {
                Item<T> current = _head;

                while (current != null)
                {
                    if (current.Value.Equals(value)) return true;
                    current = current.Next;
                }
                return false;
            }

            public int Pop()
            {
                return _head.Key;
            }

            public bool IsEmpty()
            {
                if (_count == 0) return true;
                return false;
            }

            public void Remove(T value)
            {
                Item<T> current = _head;
                Item<T> previous = null;

                while (current != null)
                {
                    if (current.Value.Equals(value))
                    {
                        T word = current.Value;
                        if (previous != null)
                        {
                            previous.Next = current.Next;

                            if (current.Next == null) _tail = previous;
                        }
                        else
                        {
                            _head = _head.Next;

                            if (_head == null) _tail = null;
                        }
                        _count--;
                        Console.WriteLine($"Удалено слово {word}"); 
                    }

                    previous = current;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<Item<T>> IEnumerable<Item<T>>.GetEnumerator()
            {
                Item<T> current = _head;
                while (current != null)
                {
                    yield return current;
                    current = current.Next;
                }
            }
        }

        private class HashTableInt
        {
            private Dictionary<int, LinkedList<int>> items;

            public HashTableInt(int n)
            {
                items = new Dictionary<int, LinkedList<int>>(n);
            }

            public void Insert(int key, int value)
            {
                var item = new Item<int>(key, value);
                var hash = HF(item.Key);

                if (items.ContainsKey(hash))
                {
                    items[hash].Add(item);
                }
                else
                {
                    LinkedList<int> hashTableItem = new LinkedList<int> { item };
                    items.Add(hash, hashTableItem);
                }
            }

            public void Search(int key, int numb)
            {
                var hash = HF(key);

                if (!items.ContainsKey(hash))
                {
                    Console.WriteLine($"Число {numb} не найдено!");
                }
                else Console.WriteLine($"Число {numb} найдено! Его хешкод - {hash}");       
            }

            private int HF(int value)
            {
                return value;
            }

            public void Output()
            {
                foreach (var item in items)
                {
                    if (!item.Value.IsEmpty()) Console.Write("\n[{0,3}]", item.Key);
                    foreach (var word in item.Value)
                    {
                        Console.Write("==>|{0}|", word.Value);
                    }
                }
            }
        }

        
        public static void Main(string[] args)
        {
            string textFromFile;

            Console.Write("1 или 2 файл: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                using (FileStream fstream = File.OpenRead("numbers30.txt"))
                {
                    byte[] buffer = new byte[fstream.Length];

                    fstream.Read(buffer, 0, buffer.Length);
                    textFromFile = Encoding.Default.GetString(buffer);
                }

                string[] numbs = textFromFile.Split(' ');
                HashTableInt table = new HashTableInt(numbs.Length);

                foreach (var numb in numbs)
                {
                    int keyWord = HF(Convert.ToInt32(numb), 15);
                    table.Insert(keyWord, Convert.ToInt32(numb));
                }

                table.Output();

                Console.Write("\n\nВведите число которое хотите найти: ");
                int key = Convert.ToInt32(Console.ReadLine());
                int keyHF = HF(key, 15);
                table.Search(keyHF, key);
            }
            else if (choice == "2")
            {
                using (FileStream fstream = File.OpenRead("numbers10000.txt"))
                {
                    byte[] buffer = new byte[fstream.Length];

                    fstream.Read(buffer, 0, buffer.Length);
                    textFromFile = Encoding.Default.GetString(buffer);
                }

                string[] numbs = textFromFile.Split(' ');
                HashTableInt table = new HashTableInt(numbs.Length);

                foreach (var numb in numbs)
                {
                    int keyWord = HF(Convert.ToInt32(numb), 1000);
                    table.Insert(keyWord, Convert.ToInt32(numb));
                }

                table.Output();

                Console.Write("\n\nВведите число которое хотите найти: ");
                int key = Convert.ToInt32(Console.ReadLine());
                int keyHF = HF(key, 1000);
                table.Search(keyHF, key);
            }

            int HF(int numb, int length)
            {
                return numb % length;
            }
        }
    }
}