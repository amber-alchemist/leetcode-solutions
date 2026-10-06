// https://leetcode.com/problems/maximum-number-of-vowels-in-a-substring-of-given-length
// #sliding_window
class Solution {
public:
	int maxVowels(string s, int k) {
		int vowels_count = 0;
		for (int i = 0; i < k; ++i) {
			if (s[i] == 'a' || s[i] == 'e' || s[i] == 'i' || s[i] == 'o' || s[i] == 'u') {
				++vowels_count;
			}
		}

		int max_vowels_count = vowels_count;
		int n = s.length();
		for (int l = 0, r = k; r < n; ++l, ++r) {
			if (s[l] == 'a' || s[l] == 'e' || s[l] == 'i' || s[l] == 'o' || s[l] == 'u') {
				--vowels_count;
			}
			if (s[r] == 'a' || s[r] == 'e' || s[r] == 'i' || s[r] == 'o' || s[r] == 'u') {
				++vowels_count;
			}
			if (vowels_count > max_vowels_count) {
				max_vowels_count = vowels_count;
			}
		}
		return max_vowels_count;
	}
};
