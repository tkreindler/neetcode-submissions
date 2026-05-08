/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Solution {
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        ListNode prev = null;
        ListNode current = head;

        while (current != null)
        {
            (bool doReverse, ListNode newSegmentHead, ListNode nextAfterSegment) = this.ReverseHelper(current, k);

            if (!doReverse)
            {
                // hit the end of the list, return without doing anything
                break;
            }

            // adjust the previous node to point to the new segment head
            if (prev is not null)
            {
                // non-null because we're doing a reverse, adjust the previous
                prev.next = newSegmentHead;
            }
            else
            {
                // special case for the first segment when prev is null
                head = newSegmentHead;
            }
            
            // current is now the last node in the previous segment, set as prev
            prev = current;

            // and point it to the next segment
            current.next = nextAfterSegment;

            // move on to the next segment
            current = nextAfterSegment;
        }
        
        return head;
    }

    private (bool doReverse, ListNode newSegmentHead, ListNode nextAfterSegment) ReverseHelper(ListNode current, int k)
    {
        // end of the line, no reverse
        if (current is null)
        {
            return (doReverse: false, null, null);
        };

        ListNode next = current.next;

        // end of the segment, reverse
        if (k == 1)
        {
            return (doReverse: true, current, current.next);
        }

        (bool doReverse, ListNode newSegmentHead, ListNode nextAfterSegment) = this.ReverseHelper(next, k - 1);

        if (doReverse)
        {
            next.next = current;
        }

        return (doReverse, newSegmentHead, nextAfterSegment);
    }
}
