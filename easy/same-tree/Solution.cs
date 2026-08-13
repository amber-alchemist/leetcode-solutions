// https://leetcode.com/problems/same-tree
// #graph_theory #binary_tree #bfs
public class Solution
{
	private class TreeTraversalStack
	{
		private readonly Stack<TreeNode> stack = new();

		public bool IsEmpty => stack.Count == 0;

		public TreeTraversalStack(TreeNode root)
		{
			stack.Push(root);
		}

		public bool TryGetNext(out TreeNode nextNode)
		{
			nextNode = null;
			if (!stack.TryPop(out nextNode)) {
				return false;
			}
			if (nextNode != null) {
				stack.Push(nextNode.right);
				stack.Push(nextNode.left);
			}
			return true;
		}
	}

	public bool IsSameTree(TreeNode p, TreeNode q)
	{
		var traversalStackP = new TreeTraversalStack(p);
		var traversalStackQ = new TreeTraversalStack(q);

		while (!traversalStackP.IsEmpty && !traversalStackQ.IsEmpty) {
			bool pHasNext = traversalStackP.TryGetNext(out var pNextNode);
			bool qHasNext = traversalStackQ.TryGetNext(out var qNextNode);
			if (pHasNext && qHasNext) {
				if (!IsEqualNodes(pNextNode, qNextNode)) {
					return false;
				}
			} else if (pHasNext || qHasNext) {
				return false;
			}
		}
		return true;
	}

	private static bool IsEqualNodes(TreeNode p, TreeNode q)
	{
		if (p != null && q != null) {
			return p.val == q.val;
		}
		return p == null && q == null;
	}
}
