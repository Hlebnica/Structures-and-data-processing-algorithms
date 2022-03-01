#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*   1. Счет в банке представляет собой структуру с полями: номер счета, код счета, 
        фамилия владельца, сумма на счете, дата открытия счета, годовой процент начисления. 
        Реализовать поиск и сортировку по номеру счета, дате его открытия и фамилии владельца.*/

namespace singly_linked_list
{
    class Program
    {
        class Account // Класс для хранения данных
        {
            public int AccountNumber { get;  } // Номер счета
            public int AccountCode { get;  } // Код счета
            public string Surname { get;  } // Фамилия владельца
            public decimal AccountAmount { get;  } // Сумма на счете
            public DateTime OpenDateTime { get;  } // Дата открытия счета
            public decimal AccrualPercentage { get;  } // Годовой процент начисления
            
            public Account(int accountNumber, int accountCode, string surname, 
                decimal accountAmount, DateTime openDateTime, decimal accrualPercentage)
            {
                AccountNumber = accountNumber;
                AccountCode = accountCode;
                Surname = surname;
                AccountAmount = accountAmount;
                OpenDateTime = openDateTime;
                AccrualPercentage = accrualPercentage;
            }
            
            public override string ToString() => $"({AccountNumber}, {AccountCode}, {Surname}, {AccountAmount}, {OpenDateTime}, {AccrualPercentage})";
        }

        class DateOpen
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public int Days { get; set; }
            
            public DateTime DateOfOpen(int year, int month, int days)
            {
                DateTime date1 = new DateTime(year, month, days); // год - месяц - день
            }
        }

        class AccountNumberSort : IComparer<Account>
        {
            public int Compare(Account? account1, Account? account2)
            {
                if(account1 is null || account2 is null) 
                    throw new ArgumentException("Некорректное значение параметра");
                return account1.AccountNumber - account2.AccountNumber;
            }
        } 
        
        public class Node<T>
        {
            public T Data { get; set; }
            public Node<T> Next { get; set; }
            
            public Node(T data)
            {
                Data = data;
            }
        }
        
        public class LinkedList<T> : IEnumerable<T>  // односвязный список
        {
            Node<T> head; // головной/первый элемент
            Node<T> tail; // последний/хвостовой элемент
            int count;  // количество элементов в списке
     
            // добавление элемента
            public void Add(T data)
            {
                Node<T> node = new Node<T>(data);
     
                if (head == null)
                    head = node;
                else
                    tail.Next = node;
                tail = node;
     
                count++;
            }
            // удаление элемента
            public bool Remove(T data)
            {
                Node<T> current = head;
                Node<T> previous = null;
     
                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        // Если узел в середине или в конце
                        if (previous != null)
                        {
                            // убираем узел current, теперь previous ссылается не на current, а на current.Next
                            previous.Next = current.Next;
     
                            // Если current.Next не установлен, значит узел последний,
                            // изменяем переменную tail
                            if (current.Next == null)
                                tail = previous;
                        }
                        else
                        {
                            // если удаляется первый элемент
                            // переустанавливаем значение head
                            head = head.Next;
     
                            // если после удаления список пуст, сбрасываем tail
                            if (head == null)
                                tail = null;
                        }
                        count--;
                        return true;
                    }
     
                    previous = current;
                    current = current.Next;
                }
                return false;
            }
     
            public int Count { get { return count; } }
            public bool IsEmpty { get { return count == 0; } }
           
            // очистка списка
            public void Clear()
            {
                head = null;
                tail = null;
                count = 0;
            }
            
            // содержит ли список элемент
            public bool Contains(T data)
            {
                Node<T> current = head;
                while (current != null)
                {
                    if (current.Data.Equals(data))
                        return true;
                    current = current.Next;
                }
                return false;
            }
            
            // добвление в начало
            public void AppendFirst(T data)
            {
                Node<T> node = new Node<T>(data);
                node.Next = head;
                head = node;
                if (count == 0)
                    tail = head;
                count++;
            }
            
            // реализация интерфейса IEnumerable
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }
     
            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                Node<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }
        
        static void Main(string[] args)
        {
            LinkedList<Account> linkedList = new LinkedList<Account>();
            
            DateTime[] dates = { new DateTime(2014, 6, 14, 6, 32, 0),
                new DateTime(2015, 7, 10, 23, 49, 0),
                new DateTime(2016, 1, 10, 1, 16, 0),
                new DateTime(2016, 12, 20, 21, 45, 0),
                new DateTime(2018, 6, 2, 15, 14, 0) };
            
            
            Account person1 = new Account(1, 123, "Петров", 10000, dates[0], 10);
            Account person2 = new Account(2, 321, "Иванов", 15000, dates[1], 12);
            Account person3 = new Account(3, 456, "Афанасьев", 30000, dates[2], 18);
            Account person4 = new Account(4, 654, "Жуков", 80500, dates[3], 25);
            Account person5 = new Account(5, 789, "Цист", 22000, dates[4], 14);
            Account person6 = new Account(6, 987, "Соловьев", 18555, dates[5], 13);
            
            linkedList.Add(person4);
            linkedList.Add(person5);
            linkedList.Add(person6);
            linkedList.Add(person1);
            linkedList.Add(person2);
            linkedList.Add(person3);
            
            // вывод элементов
            foreach(var item in linkedList)
            {
                Console.WriteLine(item);
            }
            
            
            
            
           
            
        }
    }
}