public class HashTableInt
{
    private int lenght;
    private Dictionary<int, LinkedList<int>> items;

    public HashTableInt(int n)
    {
        lenght = n;
        items = new Dictionary<int, LinkedList<int>>(n);
    }

    public void Insert(int key, int value)
    {
        var item = new Item<int>(key, value);
        var hash = HF(item.key);

        if (items.ContainsKey(hash))
        {
            items[hash].Add(item);
        }
        else
        {
            LinkedList<int> hashTableItem = new() { item };
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
                Console.Write("==>|{0}|", word.value);
            }
        }
    }
}
