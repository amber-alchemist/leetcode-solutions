// https://leetcode.com/problems/reorder-list/
// #linked_list #fast_and_slow_pointers
public class Solution
{
	public void ReorderList(ListNode head)
	{
		var first = head;
		var second = SplitLinkedListInHalf(head);
		second = ReverseList(second);
		while (second is not null) {
			var nextFirst = first.next;
			var nextSecond = second.next;
			first.next = second;
			second.next = nextFirst;
			first = nextFirst;
			second = nextSecond;
		}
	}

	private static ListNode SplitLinkedListInHalf(ListNode head)
	{
		var slowPointer = head;
		var fastPointer = head.next;
		while (fastPointer is not null && fastPointer.next is not null) {
			slowPointer = slowPointer.next;
			fastPointer = fastPointer.next.next;
		}
		var secondHaflHead = slowPointer.next;
		slowPointer.next = null;
		return secondHaflHead;
	}

	private static ListNode ReverseList(ListNode head)
	{
		ListNode previous = null;
		while (head is not null) {
			var next = head.next;
			head.next = previous;
			previous = head;
			head = next;
		}
		head = previous;
		return head;
	}
}
