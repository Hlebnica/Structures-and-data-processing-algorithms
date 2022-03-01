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
        private static HashSet<char> _vowels = new HashSet<char>("аеиоуыэюя");
        private static HashSet<char> _consonants = new HashSet<char>("бвгджзйклмнпрстфхцчшщ");
        static void Main(string[] args)
        {
            string s = "поэты и сами ещё ни разу не договорились о том, что такое поэзия.";
            int d = s.Aggregate(0, (y, x) => y + (_vowels.Contains(x) ? 1 : _consonants.Contains(x) ? -1 : 0));
            Console.WriteLine(d < 0 ? "согласных больше" : d == 0 ? "одинаково" : "гласных больше");
        }
    }
}