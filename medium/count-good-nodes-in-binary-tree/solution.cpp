// https://leetcode.com/problems/count-good-nodes-in-binary-tree
// #binary_tree #dfs
class Solution {
public:
	int goodNodes(TreeNode* root) {
		return _findGoodNodes(root, INT_MIN);
	}
private:
	int _findGoodNodes(TreeNode* node, int max_ancestor) {
		if (node == nullptr) {
			return 0;
		}

		int good_nodes_count = 0;
		if (node->val >= max_ancestor) {
			++good_nodes_count;
			max_ancestor = node->val;
		}
		good_nodes_count += _findGoodNodes(node->left, max_ancestor);
		good_nodes_count += _findGoodNodes(node->right, max_ancestor);
		return good_nodes_count;
	}
};
