// https://leetcode.com/problems/unique-morse-code-words
// #hash_map #hash_set
class Solution {
public:
	int uniqueMorseRepresentations(vector<string>& words) {
		unordered_set<string> different_transformations;
		for (auto& word : words) {
			string transformation;
			for (char letter : word) {
				transformation += _getMorseCode(letter);
			}
			different_transformations.insert(transformation);
		}
		return different_transformations.size();
	}
private:
	string _getMorseCode(char ch) {
		switch (ch) {
			case 'a': return ".-";
			case 'b': return "-...";
			case 'c': return "-.-.";
			case 'd': return "-..";
			case 'e': return ".";
			case 'f': return "..-.";
			case 'g': return "--.";
			case 'h': return "....";
			case 'i': return "..";
			case 'j': return ".---";
			case 'k': return "-.-";
			case 'l': return ".-..";
			case 'm': return "--";
			case 'n': return "-.";
			case 'o': return "---";
			case 'p': return ".--.";
			case 'q': return "--.-";
			case 'r': return ".-.";
			case 's': return "...";
			case 't': return "-";
			case 'u': return "..-";
			case 'v': return "...-";
			case 'w': return ".--";
			case 'x': return "-..-";
			case 'y': return "-.--";
			case 'z': return "--..";
		}
		throw invalid_argument("Word contains invalid char: '" + ch);
	}
};
