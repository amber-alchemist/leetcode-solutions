// https://leetcode.com/problems/greatest-common-divisor-of-strings
// #string #number_theory
class Solution {
public:
	string gcdOfStrings(string str1, string str2) {
		string str_gcd;
		if (str1 + str2 == str2 + str1) {
			int str_gcd_length = gcd(str1.length(), str2.length());
			str_gcd = str1.substr(0, str_gcd_length);
		}
		return str_gcd;
	}
};
