using System;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}

public class Reverse {
    public ListNode ReverseList(ListNode head) {
        ListNode resultNode = null;
        while(head != null)
        {
            resultNode = new ListNode(head.val, resultNode);
            head = head.next;
        }
        return resultNode;
    }
}

class Program {
    static void Main() {
        // Test case
        TestCase1();
    }

    static void PrintList(ListNode head) {
        while (head != null) {
            Console.Write(head.val + " ");
            head = head.next;
        }
        Console.WriteLine();
    }

    static void TestCase1() {
        ListNode head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        Reverse solution = new Reverse();

        Console.WriteLine("Original List:");
        PrintList(head);

        ListNode reversed = solution.ReverseList(head);

        Console.WriteLine("Reversed List:");
        PrintList(reversed);
        Console.WriteLine();
    }
}
