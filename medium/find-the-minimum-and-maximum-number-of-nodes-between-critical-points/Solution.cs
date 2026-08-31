// https://leetcode.com/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points
// #linked_list
public class Solution
{
	public int[] NodesBetweenCriticalPoints(ListNode head)
	{
		int criticalPointsCount = 0;
		int firstCriticalPoint = -1;
		int lastCriticalPoint = -1;
		int minDistance = int.MaxValue;

		var previousNode = head;
		var currentNode = head.next;
		for (int currentPoint = 0; currentNode.next != null; ++currentPoint) {
			var nextNode = currentNode.next;
			bool isLocalMaxima = previousNode.val < currentNode.val && currentNode.val > nextNode.val;
			bool isLocalMinima = previousNode.val > currentNode.val && currentNode.val < nextNode.val;
			if (isLocalMaxima || isLocalMinima) {
				if (firstCriticalPoint == -1) {
					firstCriticalPoint = currentPoint;
				}
				if (lastCriticalPoint != -1) {
					minDistance = Math.Min(minDistance, currentPoint - lastCriticalPoint);
				}
				lastCriticalPoint = currentPoint;
				++criticalPointsCount;
			}
			previousNode = currentNode;
			currentNode = nextNode;
		}

		int maxDistance = lastCriticalPoint - firstCriticalPoint;
		return criticalPointsCount > 1 ? [minDistance, maxDistance] : [-1, -1];
	}
}
