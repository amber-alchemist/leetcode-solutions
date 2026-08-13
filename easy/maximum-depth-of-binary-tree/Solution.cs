// https://leetcode.com/problems/maximum-depth-of-binary-tree
// #graph_theory #binary_tree #dfs
public class Solution
{
	private int maxDepth;

	public int MaxDepth(TreeNode root)
	{
		maxDepth = 0;
		if (root != null) {
			Dfs(root, 1);
		}
		return maxDepth;
	}

	private void Dfs(TreeNode currentNode, int depth)
	{
		maxDepth = Math.Max(depth, maxDepth);
		if (currentNode.left != null) {
			Dfs(currentNode.left, depth + 1);
		}
		if (currentNode.right != null) {
			Dfs(currentNode.right, depth + 1);
		}
	}
}
