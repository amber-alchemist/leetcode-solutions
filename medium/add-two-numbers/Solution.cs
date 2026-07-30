// https://leetcode.com/problems/add-two-numbers
// #linked_list
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var result = new ListNode();
        var currentNode = result;
        SumNodes(l1, l2, 0);
        return result;

        void SumNodes(ListNode a, ListNode b, int previousCarry)
        {
            int firstValue = a == null ? 0 : a.val;
            int secondValue = b == null ? 0 : b.val;

            int value = firstValue + secondValue + previousCarry;
            int carry = Math.DivRem(value, 10, out value);
            
            currentNode.val = value;
            a = a?.next;
            b = b?.next;

            if (a != null || b != null || carry != 0) {
                var newNode = new ListNode();
                currentNode.next = newNode;
                currentNode = newNode;
                SumNodes(a, b, carry);
            }
        }
    }
}
