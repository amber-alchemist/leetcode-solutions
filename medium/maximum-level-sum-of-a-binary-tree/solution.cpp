// https://leetcode.com/problems/maximum-level-sum-of-a-binary-tree
// #bfs #binary_tree
class Solution {
public:
	int maxLevelSum(TreeNode* root) {
		int max_level_sum = INT_MIN;
		int smallest_level_with_max_sum = 1;
		int current_level_sum = 0;
		int current_level = 1;
		queue<pair<TreeNode*, int>> traversal_queue;
		traversal_queue.push({ root, 1 });
		while (!traversal_queue.empty()) {
			TreeNode* node = traversal_queue.front().first;
			int level = traversal_queue.front().second;
			traversal_queue.pop();
			if (level > current_level) {
				if (current_level_sum > max_level_sum) {
					max_level_sum = current_level_sum;
					smallest_level_with_max_sum = current_level;
				}
				current_level_sum = 0;
				current_level = level;
			}
			current_level_sum += node->val;
			if (node->left != nullptr) {
				traversal_queue.push({ node->left, level + 1 });
			}
			if (node->right != nullptr) {
				traversal_queue.push({ node->right, level + 1 });
			}
		}
		if (current_level_sum > max_level_sum) {
			max_level_sum = current_level_sum;
			smallest_level_with_max_sum = current_level;
		}
		return smallest_level_with_max_sum;
	}
};
