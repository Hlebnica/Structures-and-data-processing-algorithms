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
            if (item.Value.Contain(value)) return true;
        }
        return false;
    }

    public void Insert(int key, char value)
    {
        var item = new Item<char>(key, value);
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


