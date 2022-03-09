#nullable enable
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*   34.	Одна запись о постояльцам гостиницы содержит следующие поля:
            номер паспорта, ФИО, город прибытия, дата заселения в гостиницу, 
            тип гостиничного номера (одноместный, двухместный или трехместный). 
            Поиск и сортировка — по городу прибытия, типу гостиничного номера, дате заселения.*/

namespace singly_linked_list
{
    class Program
    {
        class Hotel
        {
            readonly string[] _typesOfHotelRooms = { "одноместный", "двухместный", "трехместный" }; // типы комнат
            
            public int PassportId; // номер паспорта
            public string FIO; // ФИО
            public string ArrivalCity; // город прибытия
            public DateTime Date; // дата заселения
            public string RoomType; // тип комнаты

            public Hotel(int passportId, string fio, string arrivalCity, DateTime date, string roomType)
            {
                PassportId = passportId;
                FIO = fio;
                ArrivalCity = arrivalCity;
                Date = date;
                RoomType = _typesOfHotelRooms.Any(str => str == roomType.ToLower()) ? roomType : "трехместный";
            }
            
            // Ссылка на следующий Hotel
            public Hotel Next { get; set; }

            // Вывод экземпляра в консоль
            public override string ToString()
            {
                return $"Номер паспорта - {PassportId}; ФИО - {FIO}; Город прибытия - {ArrivalCity}; " +
                       $"Дата заселения - {Date.Day}.{Date.Month}.{Date.Year}; Тип номера - {RoomType}";
            }
        }
        
        class LinkedList : IEnumerable<Hotel>
        {
            // Начало списка
            Hotel head = null;
            // Конец списка
            Hotel tail = null;
            // Размер списка
            int count = 0;

            // Добавление нового элемента в конец списка
            public void Add(Hotel hotel)
            {
                if (head == null) head = hotel;
                else tail.Next = hotel;

                tail = hotel;
                count++;
            }

            public bool IsEmpty()
            {
                if (count == 0) return true;
                else return false;
            }

            // Сортировка по городу прибытия
            public void SortByArrivalCity()
            {
                Hotel test;
                Hotel last;
                Hotel prev;
                Hotel curr;
                Hotel end = null;

                while (end != head)
                {
                    last = prev = head;

                    while (prev.Next != end)
                    {
                        curr = prev.Next;

                        if (String.Compare(prev.ArrivalCity,curr.ArrivalCity) > 0)
                        {
                            prev.Next = curr.Next;
                            curr.Next = prev;

                            if (prev != head) last.Next = curr;
                            else head = curr;

                            test = curr;
                            curr = prev;
                            prev = test;
                        }

                        last = prev;
                        prev = prev.Next;
                    }

                    end = prev;
                }
            }

            // Сортировка по типу гостинчного номера
            public void SortByRoomType()
            {
                Hotel test;
                Hotel last;
                Hotel prev;
                Hotel curr;
                Hotel end = null;

                while (end != head)
                {
                    last = prev = head;

                    while (prev.Next != end)
                    {
                        curr = prev.Next;

                        if (String.Compare(prev.RoomType,curr.RoomType) > 0)
                        {
                            prev.Next = curr.Next;
                            curr.Next = prev;

                            if (prev != head) last.Next = curr;
                            else head = curr;

                            test = curr;
                            curr = prev;
                            prev = test;
                        }

                        last = prev;
                        prev = prev.Next;
                    }

                    end = prev;
                }
            }

            // Сортировка по дате прибытия
            public void SortByDate()
            {
                Hotel test;
                Hotel last;
                Hotel prev;
                Hotel curr;
                Hotel end = null;

                while (end != head)
                {
                    last = prev = head;

                    while (prev.Next != end)
                    {
                        curr = prev.Next;

                        if (DateTime.Compare(prev.Date, curr.Date) > 0)
                        {
                            prev.Next = curr.Next;
                            curr.Next = prev;

                            if (prev != head) last.Next = curr;
                            else head = curr;

                            test = curr;
                            curr = prev;
                            prev = test;
                        }

                        last = prev;
                        prev = prev.Next;
                    }

                    end = prev;
                }
            }

            // Поиск по городу прибытия
            public List<string> SearchByArrivalCity(string request)
            {
                List<string> result = new List<string>();
                Hotel current = head;
                while (current != null)
                {
                    if (current.ArrivalCity == request) result.Add(current.FIO);
                    current = current.Next;
                }

                return result;
            }

            // Поиск по типу гостинчного номера
            public List<int> SearchByRoomType(string request)
            {
                List<int> result = new List<int>();
                Hotel current = head;
                while (current != null)
                {
                    if (current.RoomType == request) result.Add(current.PassportId);
                    current = current.Next;
                }

                return result;
            }

            // Поиск по дате прибытия
            public List<string> SearchByDate(DateTime request)
            {
                List<string> result = new List<string>();
                Hotel current = head;
                while (current != null)
                {
                    if (current.Date == request) result.Add(current.ArrivalCity);
                    current = current.Next;
                }

                return result;
            }

            // реализация интерфейса IEnumerable
            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<Hotel> IEnumerable<Hotel>.GetEnumerator()
            {
                Hotel current = head;
                while (current != null)
                {
                    yield return current;
                    current = current.Next;
                }
            }
        }
        
        static void Main(string[] args)
        {
            LinkedList list = new();
            
            bool end = true; // Условие выхода из цикла

            while (end) // Меню для выбора действия
            {
                Console.WriteLine("\nВыберите действие: \n" +
                    "   1 - Добавить новый элемент \n" +
                    "   2 - Отсортировать по городу прибытия \n" +
                    "   3 - Отсортировать по типу гостинчного номера \n" +
                    "   4 - Сортировка по дате прибытия \n" +
                    "   5 - Поиск по городу прибытия \n" +
                    "   6 - Поиск по типу гостинчного номера \n" +
                    "   7 - Поиск по дате прибытия \n" +
                    "   8 - Закончить программу");


                Console.Write(" Ваш выбор - ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    // Добавление нового элемента
                    case "1":
                        bool check = true;

                        while (check)
                        {
                            Console.Write("Введите номер паспорта: ");
                            int passportId = Convert.ToInt32(Console.ReadLine());
                            
                            Console.Write("Введите ФИО: ");
                            string fio = Console.ReadLine();

                            Console.Write("Введите город прибытия: ");
                            string arrivalCity = Console.ReadLine();

                            Console.Write("Введите дату заселения: ");
                            string dateNumbs = Console.ReadLine();
                            string[] numbs = dateNumbs.Split(".");
                            DateTime date = new(Convert.ToInt32(numbs[2]), Convert.ToInt32(numbs[1]), Convert.ToInt32(numbs[0]));
                            
                            Console.Write("Введите тип комнаты (одноместный, двухместный, трехместный):");
                            string roomType = Console.ReadLine();

                            list.Add(new(passportId, fio, arrivalCity , date, roomType));

                            Console.Write("Хотите продолжить?(y/n) ");
                            if (Console.ReadLine() == "n") check = false;
                        }

                        foreach (var item in list) Console.Write($"\n{item}");

                        break;
                    // Сортировка по городу прибытия
                    case "2":
                        if (!list.IsEmpty())
                        {
                            list.SortByArrivalCity();
                            foreach (var item in list) Console.Write($"\n{item}");
                        }
                        else Console.WriteLine("Список пуст");
                        break;
                    // Сортировка по типу комнат
                    case "3":
                        if (!list.IsEmpty())
                        {
                            list.SortByRoomType();
                            foreach (var item in list) Console.Write($"\n{item}");
                        }
                        else Console.WriteLine("Список пуст");
                        break;
                    // Сортировка по дате
                    case "4":
                        if (!list.IsEmpty())
                        { 
                            list.SortByDate();
                            foreach (var item in list) Console.Write($"\n{item}");
                        }
                        else Console.WriteLine("Список пуст");
                        break;
                    // Поиск по городу прибытия
                    case "5":
                        if (!list.IsEmpty())
                        {
                            Console.Write("Введите город, который нужно найти: ");
                            string search = Console.ReadLine();
                            if (list.SearchByArrivalCity(search).Count != 0) foreach (var item in list.SearchByArrivalCity(search))
                                    Console.WriteLine($"В этот город прилетаю люди с ФИО: {item}");
                            else Console.WriteLine("Город отсутсвует в списке");
                        }
                        else Console.WriteLine("Список пуст");
                        break;
                    // Поиск по типу комнат
                    case "6":
                        if (!list.IsEmpty())
                        {
                            Console.Write("Введите тип комнаты, который нужно найти: ");
                            string search = Console.ReadLine();
                            if (list.SearchByRoomType(search).Count != 0) foreach (var item in list.SearchByRoomType(search))
                                    Console.WriteLine($"Номера паспортов зарегестрированные на эти команаты: {item}");
                            else Console.WriteLine("Тип комнат отсутсвует в списке");
                        }
                        else Console.WriteLine("Список пуст");
                        break;
                    // Поиск по дате
                    case "7":
                        if (!list.IsEmpty())
                        {
                            Console.Write("Введите дату заселения, которую нужно найти: ");
                            string search = Console.ReadLine();
                            string[] numbsSearch = search.Split(".");
                            DateTime dateSearch = new(Convert.ToInt32(numbsSearch[2]), Convert.ToInt32(numbsSearch[1]), Convert.ToInt32(numbsSearch[0]));

                            if (list.SearchByDate(dateSearch).Count != 0) foreach (var item in list.SearchByDate(dateSearch))
                                    Console.WriteLine($"Города, в которые происходит прибытие в эту дату: {item}");
                            else Console.WriteLine("На эту дату нет нет прибытий в города");
                        }
                        else Console.WriteLine("Список пуст");
                        break;
                    // Окончание цикла
                    case "8":
                        end = false;
                        break;
                    // Непредусмотренный ввод
                    default:
                        Console.WriteLine("Ошибка ввода");
                        break;
                }
            }
            
        }
    }
}
