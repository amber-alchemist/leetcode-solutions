// https://leetcode.com/problems/determine-if-two-strings-are-close
// #string #sorting
class Solution {
public:
	bool closeStrings(string word1, string word2) {
		const int ALPHABET_SIZE = 26;

		if (word1.length() != word2.length()) {
			return false;
		}

		vector<int> counters1(ALPHABET_SIZE, 0);
		vector<int> counters2(ALPHABET_SIZE, 0);
		int n = word1.size();
		for (int i = 0; i < n; ++i) {
			++counters1[word1[i] - 'a'];
			++counters2[word2[i] - 'a'];
		}

		for (int i = 0; i < ALPHABET_SIZE; ++i) {
			if (
				counters1[i] > 0 && counters2[i] == 0 ||
				counters1[i] == 0 && counters2[i] > 0
			) {
				return false;
			}
		}

		sort(counters1.begin(), counters1.end());
		sort(counters2.begin(), counters2.end());
		for (int i = 0; i < ALPHABET_SIZE; ++i) {
			if (counters1[i] != counters2[i]) {
				return false;
			}
		}
		return true;
	}
};
