// https://leetcode.com/problems/maximum-number-of-balloons
// #string
class Solution {
public:
	int maxNumberOfBalloons(string text) {
		const int ALPHABET_SIZE = 26;
		const char FIRST_ALPHABET_LETTER = 'a';

		int letters_count[ALPHABET_SIZE];
		for (int i = 0; i < ALPHABET_SIZE; ++i) {
			letters_count[i] = 0;
		}
		for (int i = 0; i < text.length(); ++i) {
			++letters_count[text[i] - FIRST_ALPHABET_LETTER];
		}

		int max_numbers_of_balloons = letters_count['b' - FIRST_ALPHABET_LETTER];
		max_numbers_of_balloons = min(max_numbers_of_balloons, letters_count['a' - FIRST_ALPHABET_LETTER]);
		max_numbers_of_balloons = min(max_numbers_of_balloons, letters_count['l' - FIRST_ALPHABET_LETTER] / 2);
		max_numbers_of_balloons = min(max_numbers_of_balloons, letters_count['o' - FIRST_ALPHABET_LETTER] / 2);
		max_numbers_of_balloons = min(max_numbers_of_balloons, letters_count['n' - FIRST_ALPHABET_LETTER]);
		return max_numbers_of_balloons;
	}
};
