// https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree
// #binary_search_tree #divide_and_conquer_algorithm
class Solution {
public:
	TreeNode* sortedArrayToBST(vector<int>& nums) {
		return _sortSubarrayToBST(nums, 0, nums.size());
	}
private:
	TreeNode* _sortSubarrayToBST(vector<int>& nums, int left, int right) {
		int middle = (right + left) / 2;
		TreeNode* node = new TreeNode(nums[middle]);
		int length = right - left;
		if (length > 1) {
			node->left = _sortSubarrayToBST(nums, left, middle);
		}
		if (length > 2) {
			node->right = _sortSubarrayToBST(nums, middle + 1, right);
		}
		return node;
	}
};
