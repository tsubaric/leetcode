using System;
using System.Collections.Generic;
using System.Linq;

public class PriorityQueue<TPriority, TValue>
{
    private readonly SortedDictionary<TPriority, Queue<TValue>> _sortedItems = new();

    public int Count
    {
        get
        {
            return _sortedItems.Sum(q => q.Value.Count);
        }
    }

    public void Enqueue(TPriority priority, TValue value)
    {
        if (!_sortedItems.ContainsKey(priority))
        {
            _sortedItems[priority] = new Queue<TValue>();
        }

        _sortedItems[priority].Enqueue(value);
    }

    public TValue Dequeue()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Priority queue is empty");
        }

        var item = _sortedItems.First();
        var value = item.Value.Dequeue();

        if (item.Value.Count == 0)
        {
            _sortedItems.Remove(item.Key);
        }

        return value;
    }

    public TValue Peek()
    {
        if (Count == 0)
        {
            throw new InvalidOperationException("Priority queue is empty");
        }

        return _sortedItems.First().Value.Peek();
    }
}

public class SmallestInfiniteSet
{
    private PriorityQueue<int, int> pq;

    public SmallestInfiniteSet()
    {
        pq = new PriorityQueue<int, int>(Enumerable.Range(1, 1000).Select(x => (x, x)));
    }

    public int PopSmallest()
    {
        int smallest = pq.Dequeue();
        while (pq.Count > 0 && pq.Peek() == smallest)
            pq.Dequeue();

        return smallest;
    }

    public void AddBack(int num)
    {
        pq.Enqueue(num, num);
    }

    public static void Main(string[] args)
    {
        SmallestInfiniteSet smallestInfiniteSet = new SmallestInfiniteSet();
        Console.WriteLine("Adding 2 to the set...");
        smallestInfiniteSet.AddBack(2);

        Console.WriteLine("Popping smallest: " + smallestInfiniteSet.PopSmallest()); // 1
        Console.WriteLine("Popping smallest: " + smallestInfiniteSet.PopSmallest()); // 2
        Console.WriteLine("Popping smallest: " + smallestInfiniteSet.PopSmallest()); // 3

        Console.WriteLine("Adding 1 back to the set...");
        smallestInfiniteSet.AddBack(1);

        Console.WriteLine("Popping smallest: " + smallestInfiniteSet.PopSmallest()); // 1
        Console.WriteLine("Popping smallest: " + smallestInfiniteSet.PopSmallest()); // 4
        Console.WriteLine("Popping smallest: " + smallestInfiniteSet.PopSmallest()); // 5
    }
}
