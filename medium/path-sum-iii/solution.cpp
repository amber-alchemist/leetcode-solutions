// https://leetcode.com/problems/path-sum-iii
// #binary_tree #dfs #prefix_sum
class Solution {
public:
	int pathSum(TreeNode* root, int targetSum) {
		_target_sum = targetSum;
		_prefix_sums[0LL] = 1;
		return root ? _traverse(root, 0) : 0;
	}
private:
	long long _target_sum = 0LL;
	unordered_map<long long, int> _prefix_sums;

	int _traverse(TreeNode* node, long long current_sum) {
		current_sum += node->val;
		int result = _prefix_sums[current_sum - _target_sum];
		++_prefix_sums[current_sum];
		if (node->left) result += _traverse(node->left, current_sum);
		if (node->right) result += _traverse(node->right, current_sum);
		--_prefix_sums[current_sum];
		return result;
	}
};
