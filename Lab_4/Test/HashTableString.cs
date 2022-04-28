public class HashTableString
{
    private int lenght;
    private Dictionary<int, LinkedList<string>> items;

    public HashTableString(int n)
    {
        lenght = n;
        items = new Dictionary<int, LinkedList<string>>(n);
    }

    public void Insert(int key, string value)
    {
        var item = new Item<string>(key, value);
        var hash = HF(item.key);

        if (items.ContainsKey(hash))
        {
            items[hash].Add(item);
        }
        else
        {
            LinkedList<string> hashTableItem = new() { item };
            items.Add(hash, hashTableItem);
        }
    }

    public void Delete(int key)
    {
        int hash = key % lenght;

        foreach (var word in items[hash])
        {
            if (word.key.ToString().StartsWith(key.ToString())) items[hash].Remove(word.value);
        }
    }

    public string[] Search(int key)
    {
        var hash = HF(key);

        if (!items.ContainsKey(hash))
        {
            return null;
        }

        var hashTableItems = items[hash];
        var item = hashTableItems.SingleOrDefault(i => i.key == key);

        if (item != null)
        {
            return new string[] { hash.ToString(), item.value };
        }

        return null;
    }

    private int HF(int value)
    {
        return (value / 10000) % lenght;
    }

    public void Output()
    {
        foreach (var item in items)
        {
            if (!item.Value.IsEmpty()) Console.Write("\n[{0,2}]", item.Key);
            foreach (var word in item.Value)
            {
                Console.Write("==>|{0, 14} |", word.value);
            }
        }
    }
}

