// https://leetcode.com/problems/maximum-nesting-depth-of-two-valid-parentheses-strings
// #stack
class Solution {
public:
	vector<int> maxDepthAfterSplit(string seq) {
		int sequence_length = seq.length();
		vector<int> splitting_encoding(sequence_length);
		int depth = 0;
		for (int i = 0; i < sequence_length; ++i) {
			if (seq[i] == '(') {
				++depth;
				splitting_encoding[i] = depth % 2;
			}
			else {
				splitting_encoding[i] = depth % 2;
				--depth;
			}
		}
		return splitting_encoding;
	}
};
