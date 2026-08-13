// https://leetcode.com/problems/merge-two-sorted-lists
// #linked_list
public class Solution
{
	public ListNode MergeTwoLists(ListNode first, ListNode second)
	{
		if (first == null && second == null) {
			return null;
		}

		ListNode mergedList, mergedListTail;
		mergedList = mergedListTail = TakeFromAndMove(ref ChooseListToTakeFrom(ref first, ref second));
		while (first != null || second != null) {
			mergedListTail = mergedListTail.next = TakeFromAndMove(ref ChooseListToTakeFrom(ref first, ref second));
		}
		return mergedList;
	}

	private static ref ListNode ChooseListToTakeFrom(ref ListNode first, ref ListNode second)
	{
		if (first == null) {
			return ref second;
		}
		else if (second == null) {
			return ref first;
		}
		else if (first.val < second.val) {
			return ref first;
		}
		else {
			return ref second;
		}
	}

	private static ListNode TakeFromAndMove(ref ListNode list)
	{
		var newNode = new ListNode(list.val);
		list = list.next;
		return newNode;
	}
}
