// https://leetcode.com/problems/remove-linked-list-elements
// #linked_list
public class Solution
{
	public ListNode RemoveElements(ListNode sourceHead, int removedValue)
	{
		ListNode resultHead = null;
		var sourceTail = sourceHead;
		while (sourceTail != null) {
			if (sourceTail.val != removedValue) {
				resultHead = new ListNode(sourceTail.val);
				sourceTail = sourceTail.next;
				break;
			}
			sourceTail = sourceTail.next;
		}

		if (resultHead != null) {
			ListNode resultTail = resultHead;
			while (sourceTail != null) {
				if (sourceTail.val != removedValue) {
					resultTail.next = new ListNode(sourceTail.val);
					resultTail = resultTail.next;
				}
				sourceTail = sourceTail.next;
			}
		}
		return resultHead;
	}
}
