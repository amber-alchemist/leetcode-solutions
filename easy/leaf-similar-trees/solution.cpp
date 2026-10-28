// https://leetcode.com/problems/leaf-similar-trees
// #binary_tree #dfs
class Solution {
public:
	bool leafSimilar(TreeNode* root1, TreeNode* root2) {
		vector<int> leaves1, leaves2;
		_getLeaves(root1, leaves1);
		_getLeaves(root2, leaves2);

		if (leaves1.size() != leaves2.size()) {
			return false;
		}
		for (int i = 0; i < leaves1.size(); ++i) {
			if (leaves1[i] != leaves2[i]) {
				return false;
			}
		}
		return true;
	}
private:
	void _getLeaves(TreeNode* node, vector<int>& leaves) {
		if (node->left == nullptr && node->right == nullptr) {
			leaves.push_back(node->val);
		}
		else {
			if (node->left != nullptr) {
				_getLeaves(node->left, leaves);
			}
			if (node->right != nullptr) {
				_getLeaves(node->right, leaves);
			}
		}
	}
};
