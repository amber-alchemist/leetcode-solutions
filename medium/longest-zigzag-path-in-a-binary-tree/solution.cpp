// https://leetcode.com/problems/longest-zigzag-path-in-a-binary-tree
// #binary_tree #dfs
class Solution {
public:
	int longestZigZag(TreeNode* root) {
		return max(_traverse(root->left, 0, true), _traverse(root->right, 0, false));
	}
private:
	int _traverse(TreeNode* node, int length, bool come_from_left) {
		if (node == nullptr) {
			return length;
		}
		return come_from_left
			? max(_traverse(node->left, 0, true), _traverse(node->right, length + 1, false))
			: max(_traverse(node->left, length + 1, true), _traverse(node->right, 0, false));
	}
};
