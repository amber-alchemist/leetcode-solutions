// https://leetcode.com/problems/merge-strings-alternately
// #string
class Solution {
public:
	string mergeAlternately(string word1, string word2) {
		int w1_length = word1.length();
		int w2_length = word2.length();

		string merged_string;
		merged_string.resize(w1_length + w2_length);
		
		int less_length = w1_length <= w2_length ? w1_length : w2_length;

		int w1_ptr = 0, w2_ptr = 0, m_ptr = 0;
		for (int i = 0; i < less_length; ++i) {
			merged_string[m_ptr++] = word1[w1_ptr++];
			merged_string[m_ptr++] = word2[w2_ptr++];
		}
		while (w1_ptr < w1_length) {
			merged_string[m_ptr++] = word1[w1_ptr++];
		}
		while (w2_ptr < w2_length) {
			merged_string[m_ptr++] = word2[w2_ptr++];
		}
		return merged_string;
	}
};
