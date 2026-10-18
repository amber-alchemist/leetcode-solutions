// https://leetcode.com/problems/guess-number-higher-or-lower
// #binary_search
class Solution {
public:
	int guessNumber(int n) {
		long left = 1, right = n;
		while (left < right) {
			long middle = (left + right) / 2;
			int answer = guess(middle);
			if (answer == 0) {
				return middle;
			}
			else if (answer == 1) {
				left = middle + 1;
			}
			else if (answer == -1) {
				right = middle - 1;
			}
		}
		return left;
	}
};
