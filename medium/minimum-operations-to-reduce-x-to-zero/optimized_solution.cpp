// https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero
// #two_pointers
class Solution {
public:
	const int INF_OPERATIONS_COUNT = 1e9 + 7;

	int minOperations(vector<int>& nums, int x) {
		int n = nums.size();
		int total_sum = 0;
		for (int i = 0; i < n; ++i) {
			total_sum += nums[i];
		}

		int min_operations_count = INF_OPERATIONS_COUNT;
		if (total_sum == x) {
			min_operations_count = n;
		}
		else if (total_sum > x) {
			int target_sum = total_sum - x;
			int current_sum = 0;
			for (int left = 0, right = 0; right < n; ++right) {
				current_sum += nums[right];
				while (current_sum > target_sum) {
					current_sum -= nums[left++];
				}
				if (current_sum == target_sum) {
					int operations_count = n - (right - left + 1);
					if (operations_count < min_operations_count) {
						min_operations_count = operations_count;
					}
				}
			}
		}
		return min_operations_count == INF_OPERATIONS_COUNT ? -1 : min_operations_count;
	}
};
