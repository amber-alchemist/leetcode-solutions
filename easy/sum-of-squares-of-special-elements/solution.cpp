// https://leetcode.com/problems/sum-of-squares-of-special-elements
// #math
class Solution {
public:
	int sumOfSquares(vector<int>& nums) {
		int n = nums.size();
		int sum_of_squares = 0;
		for (int i = 0; i < n; ++i) {
			if (n % (i + 1) == 0) {
				sum_of_squares += nums[i] * nums[i];
			}
		}
		return sum_of_squares;
	}
};
