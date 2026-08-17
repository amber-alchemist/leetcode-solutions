// https://leetcode.com/problems/binary-tree-inorder-traversal
// #binary_tree #dfs
public class Solution
{
	public IList<int> InorderTraversal(TreeNode root)
	{
		var inorderTraversalList = new List<int>();
		if (root != null) {
			Traverse(root);
		}
		return inorderTraversalList;

		void Traverse(TreeNode currentNode)
		{
			if (currentNode.left != null) {
				Traverse(currentNode.left);
			}
			inorderTraversalList.Add(currentNode.val);
			if (currentNode.right != null) {
				Traverse(currentNode.right);
			}
		}
	}
}
