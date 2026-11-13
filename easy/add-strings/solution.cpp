// https://leetcode.com/problems/add-strings
// #string
class Solution {
public:
	string addStrings(string num1, string num2) {
		if (num1.length() < num2.length()) {
			swap(num1, num2);
		}
		if (num2 == "0") {
			return num1;
		}

		string result;
		result.reserve(num1.length() + 1);
		int remainder = 0;
		for (int i = num1.length() - 1, j = num2.length() - 1; i >= 0; --i, --j) {
			int digit = (num1[i] - '0') + (j >= 0 ? num2[j] - '0' : 0) + remainder;
			remainder = 0;
			if (digit >= 10) {
				digit %= 10;
				remainder = 1;
			}
			result += (char)(digit + '0');
		}
		if (remainder == 1) {
			result += '1';
		}

		reverse(result.begin(), result.end());
		return result;
	}
};
