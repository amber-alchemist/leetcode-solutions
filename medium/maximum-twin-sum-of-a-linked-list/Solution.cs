// https://leetcode.com/problems/maximum-twin-sum-of-a-linked-list
// #linked_list
public class Solution
{
	public int PairSum(ListNode headNode)
	{
		var middleNode = headNode;
		var tailNode = headNode;
		while (tailNode != null && tailNode.next != null) {
			middleNode = middleNode.next;
			tailNode = tailNode.next.next;
		}

		var firstHalfNode = headNode;
		var reversedSecondHalfNode = ReverseList(middleNode);

		int maxTwinSum = 0;
		while (reversedSecondHalfNode != null) {
			int twinSum = firstHalfNode.val + reversedSecondHalfNode.val;
			maxTwinSum = Math.Max(maxTwinSum, twinSum);
			firstHalfNode = firstHalfNode.next;
			reversedSecondHalfNode = reversedSecondHalfNode.next;
		}
		return maxTwinSum;
	}

	private static ListNode ReverseList(ListNode headNode)
	{
		ListNode previousNode = null;
		var currentNode = headNode;
		while (currentNode != null) {
			var nextNode = currentNode.next;
			currentNode.next = previousNode;
			previousNode = currentNode;
			currentNode = nextNode;
		}
		return previousNode;
	}
}
