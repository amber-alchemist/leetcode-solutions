// https://leetcode.com/problems/maximum-69-number
// math
class Solution {
public:
	int maximum69Number(int num) {
		int maximum_69_number = 0;
		for (int factor = 1000; factor > 0; factor /= 10) {
			int digit = num / factor;
			num %= factor;
			if (digit == 6) {
				maximum_69_number += 9 * factor + num;
				break;
			}
			maximum_69_number += digit * factor;
		}
		return maximum_69_number;
	}
};
