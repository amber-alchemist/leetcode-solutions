// https://leetcode.com/problems/remove-duplicates-from-sorted-list
// #linked_list
public class Solution
{
	public ListNode DeleteDuplicates(ListNode sourceList)
	{
		if (sourceList == null) {
			return null;
		}
		var resultHead = new ListNode(sourceList.val);
		var resultTail = resultHead;
		var sourceTail = sourceList.next;
		while (sourceTail != null) {
			if (resultTail.val != sourceTail.val) {
				resultTail = resultTail.next = new ListNode(sourceTail.val);
			}
			sourceTail = sourceTail.next;
		}
		return resultHead;
	}
}
