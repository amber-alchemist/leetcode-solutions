// https://leetcode.com/problems/symmetric-tree
// #graph_theory #binary_tree #dfs
public class Solution
{
	public bool IsSymmetric(TreeNode root)
	{
		return Traverse(root.left, root.right);
	
		static bool Traverse(TreeNode leftPartNode, TreeNode rightPartNode)
		{
			if (leftPartNode == null && rightPartNode == null) {
				return true;
			}
			if (leftPartNode == null || rightPartNode == null) {
				return false;
			}
			if (leftPartNode.val != rightPartNode.val) {
				return false;
			}
			return
				Traverse(leftPartNode.left, rightPartNode.right) &&
				Traverse(leftPartNode.right, rightPartNode.left);
		}
	}
}
