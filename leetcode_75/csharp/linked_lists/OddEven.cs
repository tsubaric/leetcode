using System;

public class ListNode {
    public int val;
    public ListNode next;
    
    public ListNode(int val = 0, ListNode next = null) {
        this.val = val;
        this.next = next;
    }
}

public class OddEven {
    public ListNode OddEvenList(ListNode head) {
        if (head == null) return head;

        // Creating new nodes for odd and even
        ListNode odd = new ListNode(head.val);
        ListNode even = null;
        if (head.next != null) { even = new ListNode(head.next.val); }

        // Keeping track of their original values
        ListNode oddHead = odd;
        ListNode evenHead = even;

        // Keeping track of the corresponding values in the original list
        ListNode oddPointer = head;
        ListNode evenPointer = head.next;

        // Creating odd list
        while (oddPointer != null && oddPointer.next != null && oddPointer.next.next != null) {
            oddPointer = oddPointer.next.next;
            odd.next = new ListNode(oddPointer.val);
            odd = odd.next;
        }

        // Creating even List
        while (evenPointer != null && evenPointer.next != null && evenPointer.next.next != null) {
            evenPointer = evenPointer.next.next;
            even.next = new ListNode(evenPointer.val);
            even = even.next;
        }

        odd = oddHead; // Attaching end of odd list to start of even list
        while (odd.next != null) {
            odd = odd.next;
        }
        odd.next = evenHead;

        return oddHead; // Returning newly created lists' head.
    }

    // Utility method to print the linked list
    public static void PrintList(ListNode head) {
        ListNode current = head;
        while (current != null) {
            Console.Write(current.val + " ");
            current = current.next;
        }
        Console.WriteLine();
    }

    public static void Main() {
        // Test Case 1
        ListNode head1 = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
        Console.WriteLine("Input 1: ");
        PrintList(head1);
        OddEven oddEvenObj1 = new OddEven();
        ListNode result1 = oddEvenObj1.OddEvenList(head1);
        Console.WriteLine("Output 1: ");
        PrintList(result1);

        // Test Case 2
        ListNode head2 = new ListNode(2, new ListNode(1, new ListNode(3, new ListNode(5, new ListNode(6, new ListNode(4, new ListNode(7)))))));
        Console.WriteLine("Input 2: ");
        PrintList(head2);
        OddEven oddEvenObj2 = new OddEven();
        ListNode result2 = oddEvenObj2.OddEvenList(head2);
        Console.WriteLine("Output 2: ");
        PrintList(result2);
    }
}
