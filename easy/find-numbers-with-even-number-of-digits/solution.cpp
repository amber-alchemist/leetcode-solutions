// https://leetcode.com/problems/find-numbers-with-even-number-of-digits
// #array
class Solution {
public:
	int findNumbers(vector<int>& nums) {
		int numbers_contains_even_number_digits = 0;
		for (int number : nums) {
			int digits_count = 0;
			while (number > 0) {
				number /= 10;
				++digits_count;
			}
			if (digits_count % 2 == 0) {
				++numbers_contains_even_number_digits;
			}
		}
		return numbers_contains_even_number_digits;
	}
};
