public class Item<T>
{
    public int key;
    public T value;


    public Item(int key, T value)
    {
        this.key = key;
        this.value = value;
    }

    public Item<T> Next { get; set; }
}