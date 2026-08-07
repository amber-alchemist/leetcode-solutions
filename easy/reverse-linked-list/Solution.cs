// https://leetcode.com/problems/reverse-linked-list
// #linked_list
public class Solution
{
	public ListNode ReverseList(ListNode sourceHead)
	{
		if (sourceHead == null) {
			return null;
		}
		var reversedHead = new ListNode(sourceHead.val);
		var sourceTail = sourceHead.next;
		while (sourceTail != null) {
			reversedHead = new ListNode(sourceTail.val, reversedHead);
			sourceTail = sourceTail.next;
		}
		return reversedHead;
	}
}
