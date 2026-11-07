// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree
// #binary_tree #dfs
class Solution {
public:
	TreeNode* lowestCommonAncestor(TreeNode* root, TreeNode* p, TreeNode* q) {
		_p = p, _q = q;
		_traverse(root);
		return _lca;
	}
private:
	TreeNode* _p = nullptr;
	TreeNode* _q = nullptr;
	TreeNode* _lca = nullptr;

	bool _is_p_found = false;
	bool _is_q_found = false;

	void _traverse(TreeNode* node) {
		bool is_candidate = !_is_p_found && !_is_q_found;
		if (node == _p) {
			_is_p_found = true;
		}
		if (node == _q) {
			_is_q_found = true;
		}

		if (is_candidate && _is_p_found && _is_q_found && _lca == nullptr) {
			_lca = node;
			return;
		}

		if (node->left != nullptr) {
			_traverse(node->left);

			if (_lca != nullptr) {
				return;
			}
			if (is_candidate && _is_p_found && _is_q_found && _lca == nullptr) {
				_lca = node;
				return;
			}
		}

		if (node->right != nullptr) {
			_traverse(node->right);

			if (_lca != nullptr) {
				return;
			}
			if (is_candidate && _is_p_found && _is_q_found && _lca == nullptr) {
				_lca = node;
				return;
			}
		}
	}
};
