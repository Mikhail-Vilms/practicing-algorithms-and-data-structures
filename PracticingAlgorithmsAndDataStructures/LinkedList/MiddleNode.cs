namespace PracticingAlgorithmsAndDataStructures.LinkedList
{
    public class MiddleNode
    {
        public static ListNode Find(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            return slow;
        }
    }
}
