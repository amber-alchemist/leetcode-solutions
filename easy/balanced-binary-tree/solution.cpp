// https://leetcode.com/problems/balanced-binary-tree
// #binary_tree #dfs
class Solution {
public:
	bool isBalanced(TreeNode* root) {
		return !root || dfs(root, 0) != -1;
	}
private:
	int dfs(TreeNode* node, int depth) {
		int left_subtree_depth = node->left ? dfs(node->left, depth + 1) : depth;
		if (left_subtree_depth == -1) {
			return -1;
		}
		int right_subtree_depth = node->right ? dfs(node->right, depth + 1) : depth;
		if (right_subtree_depth == -1) {
			return -1;
		}
		int difference = left_subtree_depth - right_subtree_depth;
		if (difference < -1 || difference > 1) {
			return -1;
		}
		return max(left_subtree_depth, right_subtree_depth);
	}
};
