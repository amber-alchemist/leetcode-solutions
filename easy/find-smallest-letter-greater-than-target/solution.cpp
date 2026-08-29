// https://leetcode.com/problems/find-smallest-letter-greater-than-target
// #string
class Solution {
public:
	char nextGreatestLetter(vector<char>& letters, char target) {
		char nextGreatestLetter = '\0';
		for (int i = 0; i < letters.size(); ++i) {
			if (letters[i] > target) {
				if (nextGreatestLetter == '\0') {
					nextGreatestLetter = letters[i];
				}
				else if (letters[i] < nextGreatestLetter) {
					nextGreatestLetter = letters[i];
				}
			}
		}
		return nextGreatestLetter == '\0' ? letters[0] : nextGreatestLetter;
	}
};
