// https://leetcode.com/problems/find-two-non-overlapping-sub-arrays-each-with-target-sum
// #sliding_window #dynamic_programming
class Solution {
public:
	int minSumOfLengths(vector<int>& arr, int target) {
		int array_size = arr.size();
		int answer = array_size + 1;
		int current_sum = 0;
		vector<int> dp(array_size + 1, array_size);
		for (int left = 0, right = 0; right < array_size; ++right) {
			current_sum += arr[right];
			while (current_sum > target) {
				current_sum -= arr[left++];
			}
			dp[right + 1] = dp[right];
			if (current_sum == target) {
				int subarray_size = right - left + 1;
				answer = min(answer, subarray_size + dp[left]);
				dp[right + 1] = min(dp[right], subarray_size);
			}
		}
		return answer == array_size + 1 ? -1 : answer;
	}
};
