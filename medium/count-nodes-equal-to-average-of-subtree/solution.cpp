// https://leetcode.com/problems/count-nodes-equal-to-average-of-subtree
// #graph_theory #binary_tree #dfs
class Solution {
public:
	int averageOfSubtree(TreeNode* root) {
		_nodes_with_val_equal_subtree_average = 0;
		dfs(root);
		return _nodes_with_val_equal_subtree_average;
	}

private:
	int _nodes_with_val_equal_subtree_average = 0;

	pair<int, int> dfs(TreeNode* node)
	{
		pair<int, int> left_subtree_sum_and_size = node->left != nullptr ? dfs(node->left) : pair<int, int>(0, 0);
		pair<int, int> right_subtree_sum_and_size = node->right != nullptr ? dfs(node->right) : pair<int, int>(0, 0);
		pair<int, int> subtree_sum_and_size = {
			left_subtree_sum_and_size.first + right_subtree_sum_and_size.first + node->val,
			left_subtree_sum_and_size.second + right_subtree_sum_and_size.second + 1
		};
		int average_value_of_subtrees = subtree_sum_and_size.first / subtree_sum_and_size.second;
		if (node->val == average_value_of_subtrees) {
			++_nodes_with_val_equal_subtree_average;
		}
		return subtree_sum_and_size;
	}
};
