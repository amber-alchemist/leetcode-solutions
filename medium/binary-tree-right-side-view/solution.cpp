// https://leetcode.com/problems/binary-tree-right-side-view
// #bfs #binary_tree
class Solution {
public:
	vector<int> rightSideView(TreeNode* root) {
		if (root == nullptr) {
			return {};
		}
		vector<int> right_side_view;
		queue<pair<int, TreeNode*>> traverse_queue;
		traverse_queue.push({ 0, root });
		while (!traverse_queue.empty()) {
			int depth = traverse_queue.front().first;
			TreeNode* node = traverse_queue.front().second;
			traverse_queue.pop();

			if (right_side_view.size() <= depth) {
				right_side_view.push_back(node->val);
			}
			else {
				right_side_view[depth] = node->val;
			}
			if (node->left != nullptr) {
				traverse_queue.push({ depth + 1, node->left });
			}
			if (node->right != nullptr) {
				traverse_queue.push({ depth + 1, node->right });
			}
		}
		return right_side_view;
	}
};
