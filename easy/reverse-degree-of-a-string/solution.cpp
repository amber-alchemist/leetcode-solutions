// https://leetcode.com/problems/reverse-degree-of-a-string
// #array
class Solution {
public:
	int reverseDegree(string s) {
		int reverse_degree = 0;
		int string_length = s.length();
		for (int i = 0; i < string_length; ++i) {
			int index_in_reversed_alphabet = 26 - (s[i] - 'a');
			reverse_degree += (i + 1) * index_in_reversed_alphabet;
		}
		return reverse_degree;
	}
};
