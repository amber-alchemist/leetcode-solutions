// https://leetcode.com/problems/removing-minimum-and-maximum-from-array
// #array #math
class Solution {
public:
	int minimumDeletions(vector<int>& nums) {
		int n = nums.size();
		int index_of_min = 0;
		int index_of_max = 0;
		for (int i = 1; i < n; ++i) {
			if (nums[i] < nums[index_of_min]) {
				index_of_min = i;
			}
			else if (nums[i] > nums[index_of_max]) {
				index_of_max = i;
			}
		}

		int a = index_of_min;
		int b = index_of_max;
		if (a > b) {
			swap(a, b);
		}

		int minimumDeletions = min(a + 1 + n - b, min(b + 1, n - a));
		return minimumDeletions;
	}
};
