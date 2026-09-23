// https://leetcode.com/problems/minimum-operations-to-reduce-x-to-zero
// #prefix_sum #suffix_sum #two_pointers
class Solution {
public:
	const int INF_OPERATIONS_COUNT = 1e9 + 7;

	int minOperations(vector<int>& nums, int x) {
		int n = nums.size();
		int total_sum = nums[0];
		int prefix_excluded_end = 1;
		while (prefix_excluded_end < n && total_sum < x) {
			total_sum += nums[prefix_excluded_end++];
		}
		if (prefix_excluded_end == n && total_sum < x) {
			return -1;
		}

		int min_operations_count = INF_OPERATIONS_COUNT;
		if (total_sum == x) {
			min_operations_count = prefix_excluded_end;
		}

		int suffix_start = n;
		while (prefix_excluded_end > 0) {
			total_sum -= nums[--prefix_excluded_end];
			while (prefix_excluded_end < suffix_start && total_sum < x) {
				total_sum += nums[--suffix_start];
			}
			if (total_sum == x) {
				int operations_count = prefix_excluded_end + n - suffix_start;
				if (operations_count < min_operations_count) {
					min_operations_count = operations_count;
				}
			}
		}
		return min_operations_count == INF_OPERATIONS_COUNT ? -1 : min_operations_count;
	}
};
