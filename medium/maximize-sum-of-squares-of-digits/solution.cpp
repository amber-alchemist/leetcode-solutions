// https://leetcode.com/problems/maximize-sum-of-squares-of-digits
// #greedy_algorithm #math
class Solution {
public:
	string maxSumOfSquares(int num, int sum) {
		int max_possible_number = 9 * num;
		if (max_possible_number < sum) {
			return "";
		}
		string max_sum_of_squares_str(num, '0');
		int nines_count = sum / 9;
		for (int i = 0; i < nines_count; ++i) {
			max_sum_of_squares_str[i] = '9';
		}
		int remainder = sum % 9;
		max_sum_of_squares_str[nines_count] = '0' + remainder;
		return max_sum_of_squares_str;
	}
};
