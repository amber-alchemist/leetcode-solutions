// https://leetcode.com/problems/clone-graph
// #graph_theory #dfs
public class Solution
{
	public Node CloneGraph(Node root)
	{
		const int MaxNodesCount = 100;

		if (root == null) {
			return null;
		}
		var clonedNodes = new Node[MaxNodesCount];
		return DeepClone(root);

		Node DeepClone(Node node)
		{
			var clone = clonedNodes[node.val - 1] = new Node(node.val);
			foreach (var neighbor in node.neighbors) {
				var neighborClone = clonedNodes[neighbor.val - 1] ??= DeepClone(neighbor);
				clone.neighbors.Add(neighborClone);
			}
			return clone;
		}
	}
}
