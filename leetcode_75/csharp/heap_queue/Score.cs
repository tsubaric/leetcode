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
}

public class Score
{
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        List<(int, int)> lst = new();
        for (int i = 0; i < nums1.Length; i++)
            lst.Add((nums1[i], nums2[i]));

        PriorityQueue<int, int> pq = new();
        lst = lst.OrderByDescending(x => x.Item2).ToList();

        long sum = 0;
        int min = 0;
        for (int i = 0; i < k; i++)
        {
            pq.Enqueue(lst[i].Item1, lst[i].Item1);
            sum += lst[i].Item1;
            min = lst[i].Item2;
        }

        long res = sum * min;
        for (int i = k; i < lst.Count; i++)
        {
            sum += lst[i].Item1 - pq.Dequeue();
            pq.Enqueue(lst[i].Item1, lst[i].Item1);
            min = lst[i].Item2;
            res = Math.Max(res, sum * min);
        }

        return res;
    }

    public static void Main(string[] args)
    {
        // Example 1
        int[] nums1 = { 1, 3, 3, 2 };
        int[] nums2 = { 2, 1, 3, 4 };
        int k1 = 3;
        Score score1 = new Score();
        long result1 = score1.MaxScore(nums1, nums2, k1);
        Console.WriteLine("Example 1 - Max Score: " + result1);

        // Example 2
        int[] nums3 = { 4, 2, 3, 1, 1 };
        int[] nums4 = { 7, 5, 10, 9, 6 };
        int k2 = 1;
        Score score2 = new Score();
        long result2 = score2.MaxScore(nums3, nums4, k2);
        Console.WriteLine("Example 2 - Max Score: " + result2);
    }
}
