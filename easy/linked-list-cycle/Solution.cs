// https://leetcode.com/problems/linked-list-cycle
// #linked_list #fast_and_slow_pointers
public class Solution
{
	public bool HasCycle(ListNode head)
	{
		var slowPointer = head;
		var fastPointer = head;
		while (fastPointer != null && fastPointer.next != null) {
			slowPointer = slowPointer.next;
			fastPointer = fastPointer.next.next;
			if (slowPointer == fastPointer) {
				return true;
			}
		}
		return false;
	}
}
