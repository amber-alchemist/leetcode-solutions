// https://leetcode.com/problems/how-many-numbers-are-smaller-than-the-current-number
// #sorting
class Solution {
public:
	vector<int> smallerNumbersThanCurrent(vector<int>& nums) {
		int nums_count = nums.size();
		vector<pair<int, int>> sorted_nums(nums_count);
		for (int i = 0; i < nums_count; ++i) {
			sorted_nums[i] = { nums[i], i };
		}
		sort(sorted_nums.begin(), sorted_nums.end());

		vector<int> smaller_numbers_counts(nums_count);
		int smaller_numbers_count = 0;
		int equal_previous_numbers_count = 0;
		smaller_numbers_counts[sorted_nums[0].second] = 0;
		for (int i = 1; i < nums_count; ++i) {
			if (sorted_nums[i].first == sorted_nums[i - 1].first) {
				++equal_previous_numbers_count;
			}
			else if (sorted_nums[i].first > sorted_nums[i - 1].first) {
				smaller_numbers_count += 1 + equal_previous_numbers_count;
				equal_previous_numbers_count = 0;
			}
			smaller_numbers_counts[sorted_nums[i].second] = smaller_numbers_count;
		}
		return smaller_numbers_counts;
	}
};
