// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree
// #bfs #binary_tree
class Solution {
public:
	int maxLevelSum(TreeNode* root) {
		int max_level_sum = INT_MIN;
		int smallest_level_with_max_sum = 1;

		queue<TreeNode*> traversal_queue;
		traversal_queue.emplace(root);
		for (int current_level = 1; !traversal_queue.empty(); ++current_level) {
			int current_level_sum = 0;
			for (int i = traversal_queue.size(); i > 0; --i) {
				TreeNode* node = traversal_queue.front();
				traversal_queue.pop();
				current_level_sum += node->val;
				if (node->left != nullptr) {
					traversal_queue.emplace(node->left);
				}
				if (node->right != nullptr) {
					traversal_queue.emplace(node->right);
				}
			}

			if (current_level_sum > max_level_sum) {
				max_level_sum = current_level_sum;
				smallest_level_with_max_sum = current_level;
			}
		}
		return smallest_level_with_max_sum;
	}
};
