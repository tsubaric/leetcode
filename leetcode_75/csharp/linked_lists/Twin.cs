using System;
using System.Collections.Generic;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Twin {
    public int PairSum(ListNode head) {
        List<int> datas = new List<int>();
        while (head != null) {
            datas.Add(head.val);
            head = head.next;
        }

        int sum = 0;
        for (int i = 0; i < datas.Count / 2; i++) {
            if (datas[i] + datas[datas.Count - i - 1] > sum) {
                sum = datas[i] + datas[datas.Count - i - 1];
            }
        }
        return sum;
    }
}

class Program {
    static void Main() {
        // Test case
        TestCase1();
    }

    static void TestCase1() {
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
        Twin twin = new Twin();

        Console.WriteLine("Linked List:");
        PrintList(head);

        int maxPairSum = twin.PairSum(head);

        Console.WriteLine("Maximum Pair Sum: " + maxPairSum);
    }

    static void PrintList(ListNode head) {
        while (head != null) {
            Console.Write(head.val + " ");
            head = head.next;
        }
        Console.WriteLine();
    }
}
