// https://leetcode.com/problems/subarrays-distinct-element-sum-of-squares-i
// #sliding_window
class Solution {
public:
	int sumCounts(vector<int>& nums) {
		const int MAX_VALUE = 100;
		vector<int> counts(MAX_VALUE + 1, 0);
		++counts[nums[0]];

		int n = nums.size();
		int square_sum_of_distinct_counts = n;
		int distincts_numbers_in_subarray = 1;
		int head = 0, tail = 0, direction = 1;
		for (int i = 2; i <= n; ++i) {
			head += direction;
			if (++counts[nums[head]] == 1) {
				++distincts_numbers_in_subarray;
			}
			square_sum_of_distinct_counts +=
				distincts_numbers_in_subarray * distincts_numbers_in_subarray;
			for (int j = i; j < n; ++j) {
				head += direction;
				if (++counts[nums[head]] == 1) {
					++distincts_numbers_in_subarray;
				}
				if (--counts[nums[tail]] == 0) {
					--distincts_numbers_in_subarray;
				}
				tail += direction;
				square_sum_of_distinct_counts +=
					distincts_numbers_in_subarray * distincts_numbers_in_subarray;
			}
			direction *= -1;
			swap(head, tail);
		}
		return square_sum_of_distinct_counts;
	}
};
