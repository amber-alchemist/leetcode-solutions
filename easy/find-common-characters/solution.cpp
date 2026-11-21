// https://leetcode.com/problems/find-common-characters
// #array #string
class Solution {
public:
	vector<string> commonChars(vector<string>& words) {
		const int ALPHABET_SIZE = 26;
		
		vector<int> total_frequence(ALPHABET_SIZE, INT_MAX);
		vector<int> current_frequence(ALPHABET_SIZE, 0);

		int words_count = words.size();
		for (int i = 0; i < words_count; ++i) {
			fill(current_frequence.begin(), current_frequence.end(), 0);
			int length = words[i].length();
			for (int j = 0; j < length; ++j) {
				++current_frequence[words[i][j] - 'a'];
			}
			for (int j = 0; j < ALPHABET_SIZE; ++j) {
				total_frequence[j] = min(total_frequence[j], current_frequence[j]);
			}
		}

		vector<string> common_chars;
		for (int i = 0; i < ALPHABET_SIZE; ++i) {
			string letter(1, 'a' + i);
			for (int j = 0; j < total_frequence[i]; ++j) {
				common_chars.push_back(letter);
			}
		}
		return common_chars;
	}
};
