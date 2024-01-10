using System;

public class ListNode {
    public int val;
    public ListNode next;
    
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}

public class MiddleNode {
    public ListNode DeleteMiddle(ListNode head) {
        if (head.next == null) {
            return null;
        }
        
        ListNode prevSlow = null;
        var slow = head;
        var fast = head;
        
        while(fast != null && fast.next != null) {
            fast = fast.next.next;
            prevSlow = slow;
            slow = slow.next;
        }

        prevSlow.next = slow.next;
        
        return head;
    }

    public static void Main() {
        // Example usage:
        ListNode head = new ListNode(1, new ListNode(3, new ListNode(4, new ListNode(7, new ListNode(1, new ListNode(2, new ListNode(6)))))));
        
        Console.WriteLine("Original List:");
        PrintList(head);

        MiddleNode middleNode = new MiddleNode();
        middleNode.DeleteMiddle(head);

        Console.WriteLine("List after deleting middle element:");
        PrintList(head);
    }

    static void PrintList(ListNode node) {
        while (node != null) {
            Console.Write(node.val + " ");
            node = node.next;
        }
        Console.WriteLine();
    }
}
