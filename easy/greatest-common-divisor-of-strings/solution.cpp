// https://leetcode.com/problems/greatest-common-divisor-of-strings
// #string #brute_force #number_theory
class Solution {
public:
	string gcdOfStrings(string str1, string str2) {
		int length1 = str1.length();
		int length2 = str2.length();
		int min_length = min(length1, length2);
		int max_gcd_str_length = gcd(length1, length2);
		int gcd_str_length = 0;
		for (int candidate_length = 1; candidate_length <= max_gcd_str_length; ++candidate_length) {
			if (str1[candidate_length - 1] != str2[candidate_length - 1]) {
				break;
			}
			if (length1 % candidate_length != 0 || length2 % candidate_length != 0) {
				continue;
			}
			if (_isDivide(str1, candidate_length) && _isDivide(str2, candidate_length)) {
				gcd_str_length = candidate_length;
			}
		}
		return str1.substr(0, gcd_str_length);
	}
private:
	bool _isDivide(string& s, int l) {
		int k = s.length() / l;
		int p = l;
		for (int x = 1; x < k; ++x) {
			for (int i = 0; i < l; ++i) {
				if (s[p++] != s[i]) {
					return false;
				}
			}
		}
		return true;
	}
};
