//======================================================================================================================================================================================
// #1
//======================================================================================================================================================================================

using System.Collections;

Console.Write("Введите строку: ");
string line = Console.ReadLine();
Hashtable table0 = new();

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

//======================================================================================================================================================================================
// #2
//======================================================================================================================================================================================

//using System.Text;

//Console.Write("Введите размерность: ");
//int n = Convert.ToInt32(Console.ReadLine());

//HashTableString table = new(n);

//using (FileStream fstream = File.OpenRead("words.txt"))
//{
//    byte[] buffer = new byte[fstream.Length];

//    fstream.Read(buffer, 0, buffer.Length);
//    string textFromFile = Encoding.Default.GetString(buffer);

//    string[] words = textFromFile.Split(' ');

//    foreach (string word in words)
//    {
//        int key = valueKey(word);
//        table.Insert(key, word);
//    }
//}

//table.Output();

//Console.Write("\nВведите нужное слово: ");
//string keyWord = Console.ReadLine();
//int k = valueKey(keyWord);

//if (table.Search(k) != null) Console.WriteLine($"Слово \"{table.Search(k)[1]}\" найдено! Его хэш-ключ \'{table.Search(k)[0]}\'");

//Console.Write("Введите букву: ");
//int letter = Console.Read();
//Console.WriteLine();
//table.Delete(letter);
//Console.WriteLine();

//table.Output();


//int valueKey(string word)
//{
//    int sum = 0;

//    for (int i = 1; i < word.Length; i++)
//    {
//        sum += word[i];
//    }

//    sum += word[0] * 10000;

//    return sum;
//}

//======================================================================================================================================================================================
// #3
//======================================================================================================================================================================================

//using System.Text;


//string textFromFile;

//Console.Write("1 или 2 файл: ");
//string choise = Console.ReadLine();

//if (choise == "1")
//{
//    using (FileStream fstream = File.OpenRead("numbers30.txt"))
//    {
//        byte[] buffer = new byte[fstream.Length];

//        fstream.Read(buffer, 0, buffer.Length);
//        textFromFile = Encoding.Default.GetString(buffer);
//    }

//    string[] numbs = textFromFile.Split(' ');
//    HashTableInt table = new(numbs.Length);

//    foreach (var numb in numbs)
//    {
//        int keyWord = HF(Convert.ToInt32(numb), 15);
//        table.Insert(keyWord, Convert.ToInt32(numb));
//    }

//    table.Output();

//    Console.Write("\n\nВведите число которое хотите найти: ");
//    int key = Convert.ToInt32(Console.ReadLine());
//    int keyHF = HF(key, 15);
//    table.Search(keyHF, key);
//}
//else if (choise == "2")
//{
//    using (FileStream fstream = File.OpenRead("numbers10000.txt"))
//    {
//        byte[] buffer = new byte[fstream.Length];

//        fstream.Read(buffer, 0, buffer.Length);
//        textFromFile = Encoding.Default.GetString(buffer);
//    }

//    string[] numbs = textFromFile.Split(' ');
//    HashTableInt table = new(numbs.Length);

//    foreach (var numb in numbs)
//    {
//        int keyWord = HF(Convert.ToInt32(numb), 1000);
//        table.Insert(keyWord, Convert.ToInt32(numb));
//    }

//    table.Output();

//    Console.Write("\n\nВведите число которое хотите найти: ");
//    int key = Convert.ToInt32(Console.ReadLine());
//    int keyHF = HF(key, 1000);
//    table.Search(keyHF, key);
//}



//int HF(int numb, int length)
//{
//    return numb % length;
//}