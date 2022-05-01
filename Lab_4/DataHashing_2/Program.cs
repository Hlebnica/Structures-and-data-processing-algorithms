using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

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

        private class HashTableString
        {
            private int _lenght;
            private Dictionary<int, LinkedList<string>> _items;

            public HashTableString(int n)
            {
                _lenght = n;
                _items = new Dictionary<int, LinkedList<string>>(n);
            }

            public void Insert(int key, string value)
            {
                var item = new Item<string>(key, value);
                var hash = HashFunction(item.Key);
                

                if (_items.ContainsKey(hash))
                {
                    _items[hash].Add(item);
                }
                else
                {
                    LinkedList<string> hashTableItem = new LinkedList<string> {item};
                    _items.Add(hash, hashTableItem);
                }
            }

            public void Delete(int key)
            {
                int hash = key % _lenght;

                foreach (var word in _items[hash])
                {
                    if (word.Key.ToString().StartsWith(key.ToString())) _items[hash].Remove(word.Value);
                }
            }

            public string[] Search(int key)
            {
                var hash = HashFunction(key);

                if (!_items.ContainsKey(hash))
                {
                    return null;
                }

                var hashTableItems = _items[hash];
                var item = hashTableItems.SingleOrDefault(i => i.Key == key);

                if (item != null)
                {
                    return new[] { hash.ToString(), item.Value };
                }

                return null;
            }

            private int HashFunction(int value)
            {
                return (value / 10000) % _lenght;
            }

            public void Output()
            {
                foreach (var item in _items)
                {
                    if (!item.Value.IsEmpty()) Console.Write("\n[{0,2}]", item.Key);
                    foreach (var word in item.Value)
                    {
                        Console.Write("==>|{0, 14} |", word.Value);
                    }
                }
            }
        }
        
        public static void Main(string[] args)
        {
            Console.Write("Введите размерность: ");
            int n = Convert.ToInt32(Console.ReadLine());

            HashTableString table = new HashTableString(n);

            using (FileStream file = File.OpenRead("text.txt"))
            {
                byte[] buffer = new byte[file.Length];

                file.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);

                string[] words = textFromFile.Split(' ');

                foreach (string word in words)
                {
                    int key = ValueKey(word);
                    table.Insert(key, word);
                }
            }

            table.Output();

            Console.Write("\nВведите нужное слово: ");
            string keyWord = Console.ReadLine();
            int k = ValueKey(keyWord);

            if (table.Search(k) != null) 
                Console.WriteLine($"Слово: \"{table.Search(k)[1]}\" найдено\nХэш-ключ слова: \'{table.Search(k)[0]}\'");

            Console.Write("Введите букву: ");
            int letter = Console.Read();
            Console.WriteLine();
            table.Delete(letter);
            Console.WriteLine();

            table.Output();

            int ValueKey(string word)
            {
                int sum = 0;
                for (int i = 1; i < word.Length; i++)
                {
                    sum += word[i];
                }
                sum += word[0] * 10000;
                return sum;
            }
        }
    }
}