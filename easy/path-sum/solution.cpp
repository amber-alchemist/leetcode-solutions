// https://leetcode.com/problems/path-sum
// #binary_tree #dfs
class Solution {
public:
	bool hasPathSum(TreeNode* root, int target_sum) {
		if (root == nullptr) {
			return false;
		}
		if (root->left == nullptr && root->right == nullptr) {
			return root->val == target_sum;
		}
		return
			hasPathSum(root->left, target_sum - root->val) ||
			hasPathSum(root->right, target_sum - root->val);
	}
};
