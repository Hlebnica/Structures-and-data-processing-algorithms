using System.Collections;

internal class LinkedList<T> : IEnumerable<Item<T>>
{
    Item<T> head = null;
    Item<T> tail = null;
    public int count = 0;

    public void Add(Item<T> item)
    {
        if (head == null) head = item;
        else tail.Next = item;

        tail = item;
        count++;
    }

    public bool Contain(T value)
    {
        Item<T> current = head;

        while (current != null)
        {
            if (current.value.Equals(value)) return true;
            current = current.Next;
        }
        return false;
    }

    public int Pop()
    {
        return head.key;
    }

    public bool IsEmpty()
    {
        if (count == 0) return true;
        else return false;
    }

    public void Remove(T value)
    {
        Item<T> current = head;
        Item<T> previous = null;

        while (current != null)
        {
            if (current.value.Equals(value))
            {
                T word = current.value;
                if (previous != null)
                {
                    previous.Next = current.Next;

                    if (current.Next == null) tail = previous;
                }
                else
                {
                    head = head.Next;

                    if (head == null) tail = null;
                }
                count--;
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
        Item<T> current = head;
        while (current != null)
        {
            yield return current;
            current = current.Next;
        }
    }
}
