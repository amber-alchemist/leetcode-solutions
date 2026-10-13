// https://leetcode.com/problems/apply-operations-on-array-to-maximize-sum-of-squares
// #bitwise_operations #greedy_algorithm
class Solution {
public:
	int maxSum(vector<int>& nums, int k) {
		const int MODULO = 1e9 + 7;
		const int MAX_BITS = 30;

		vector<int> bits_count(MAX_BITS + 1);
		for (int item : nums) {
			for (int i = 0; i <= MAX_BITS; ++i) {
				if (item & (1 << i)) {
					++bits_count[i];
				}
			}
		}

		long long max_sum_of_squares = 0ll;
		for (int i = 0; i < k; ++i) {
			long long current_value = 0ll;
			for (int j = MAX_BITS; j >= 0; --j) {
				if (bits_count[j] > 0) {
					current_value |= (1LL << j);
					--bits_count[j];
				}
			}
			if (current_value == 0ll) {
				break;
			}
			max_sum_of_squares = (max_sum_of_squares + current_value * current_value) % MODULO;
		}
		return max_sum_of_squares;
	}
};
