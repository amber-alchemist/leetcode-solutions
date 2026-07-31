// https://leetcode.com/problems/rotate-list
// #linked_list
public class Solution
{
	public ListNode RotateRight(ListNode original, int shift)
	{
		if (original == null) {
			return null;
		}

		int length = 0;
		var originalTail = original;
		while (originalTail != null) {
			originalTail = originalTail.next;
			++length;
		}
		shift %= length;

		var newNodes = new List<ListNode>(length) { new() };
		for (int i = 1; i < length; ++i) {
			newNodes.Add(new());
			newNodes[i - 1].next = newNodes[i];
		}

		int index = 0;
		originalTail = original;
		while (originalTail != null) {
			newNodes[(index++ + shift) % length].val = originalTail.val;
			originalTail = originalTail.next;
		}
		return newNodes[0];
	}
}
