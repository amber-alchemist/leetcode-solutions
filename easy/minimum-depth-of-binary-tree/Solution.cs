// https://leetcode.com/problems/minimum-depth-of-binary-tree
// #graph_theory #binary_tree #bfs
public class Solution
{
	public int MinDepth(TreeNode root)
	{
		if (root == null) {
			return 0;
		}

		var queue = new Queue<(TreeNode node, int depth)>();
		queue.Enqueue((root, 1));
		while (queue.TryDequeue(out var item)) {
			var (node, depth) = item;
			if (node.left == null && node.right == null) {
				return depth;
			}
			if (node.left != null) {
				queue.Enqueue((node.left, depth + 1));
			}
			if (node.right != null) {
				queue.Enqueue((node.right, depth + 1));
			}
		}
		throw new InvalidOperationException();
	}
}
