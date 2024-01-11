using System;
using System.Collections.Generic;

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
}

public class Worker
{
    public long TotalCost(int[] costs, int k, int c)
    {
        var left = 0;
        var right = costs.Length - 1;
        var candidatePq = new PriorityQueue<Tuple<int, int>, Tuple<int, int>>(new TupleComparer());

        while (left < c)
        {
            var tuple = new Tuple<int, int>(costs[left], left);
            candidatePq.Enqueue(tuple, tuple);
            left++;
        }
        while (right >= left && right >= costs.Length - c)
        {
            var tuple = new Tuple<int, int>(costs[right], right);
            candidatePq.Enqueue(tuple, tuple);
            right--;
        }

        var selectedcandidate = 0;
        long cost = 0;
        while (selectedcandidate < k)
        {
            var candidate = candidatePq.Dequeue();
            cost += candidate.Item1;

            var index = candidate.Item2;
            if (index < left && right >= left)
            {
                var tuple = new Tuple<int, int>(costs[left], left);
                candidatePq.Enqueue(tuple, tuple);
                left++;
            }
            else if (index > right && right >= left)
            {
                var tuple = new Tuple<int, int>(costs[right], right);
                candidatePq.Enqueue(tuple, tuple);
                right--;
            }
            selectedcandidate++;
        }
        return cost;
    }

    public static void Main(string[] args)
    {
        // Example 1
        int[] costs1 = { 17, 12, 10, 2, 7, 2, 11, 20, 8 };
        int k1 = 3;
        int candidates1 = 4;
        Worker worker1 = new Worker();
        long result1 = worker1.TotalCost(costs1, k1, candidates1);
        Console.WriteLine("Example 1 - Total Cost: " + result1);

        // Example 2
        int[] costs2 = { 1, 2, 4, 1 };
        int k2 = 3;
        int candidates2 = 3;
        Worker worker2 = new Worker();
        long result2 = worker2.TotalCost(costs2, k2, candidates2);
        Console.WriteLine("Example 2 - Total Cost: " + result2);
    }
}

public class TupleComparer : IComparer<Tuple<int, int>>
{
    // Compares by Height, Length, and Width.
    public int Compare(Tuple<int, int> x, Tuple<int, int> y)
    {
        if (x.Item1.CompareTo(y.Item1) != 0)
        {
            return x.Item1.CompareTo(y.Item1);
        }
        else if (x.Item2.CompareTo(y.Item2) != 0)
        {
            return x.Item2.CompareTo(y.Item2);
        }
        else
        {
            return 0;
        }
    }
}
