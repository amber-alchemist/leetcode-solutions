// https://leetcode.com/problems/unique-3-digit-even-numbers
// #combinatorics
class Solution {
public:
	int totalNumbers(vector<int>& digits) {
		vector<int> counters(10, 0);
		for (int i = 0; i < digits.size(); ++i) {
			++counters[digits[i]];
		}

		int unique_3digit_even_numbers_count = 0;
		for (int i = 0; i < 10; i += 2) {
			if (counters[i] == 0) {
				continue;
			}
			--counters[i];
			for (int j = 0; j < 10; ++j) {
				if (counters[j] == 0) {
					continue;
				}
				--counters[j];
				for (int k = 1; k < 10; ++k) {
					if (counters[k] > 0) {
						++unique_3digit_even_numbers_count;
					}
				}
				++counters[j];
			}
			++counters[i];
		}
		return unique_3digit_even_numbers_count;
	}
};
