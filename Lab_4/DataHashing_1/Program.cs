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

        public class HashTableChar
        {
            private Dictionary<int, LinkedList<char>> _items;

            public HashTableChar(int n)
            {
                _items = new Dictionary<int, LinkedList<char>>(n);
            }

            public bool ContainsChar(char value)
            {
                foreach (var item in _items)
                {
                    if (item.Value.Contain(value)) return true;
                }
                return false;
            }

            public void Insert(int key, char value)
            {
                var item = new Item<char>(key, value);
                var hash = HashFunction(item.Key);

                if (_items.ContainsKey(hash))
                {
                    _items[hash].Add(item);
                }
                else
                {
                    LinkedList<char> hashTableItem = new LinkedList<char> {item};
                    _items.Add(hash, hashTableItem);
                }
            }

            public void Search(int key)
            {
                var hash = HashFunction(key);

                foreach (var item in _items[hash])

                    Console.Write($"{item.Value} ");
            }

            private int HashFunction(int value)
            {
                return value;
            }

            public void Output()
            {
                foreach (var item in _items)
                {
                    if (!item.Value.IsEmpty()) Console.Write($"\n[{item.Key}]");
                    foreach (var word in item.Value)
                    {
                        Console.Write($"-->|{word.Value}|");
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

            HashTableChar table = new HashTableChar(max);

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
            Console.WriteLine("Найденные буквы:");
            table.Search(number);
        }
    }
}