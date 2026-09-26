// https://leetcode.com/problems/evaluate-the-bracket-pairs-of-a-string
// #string #hash_table
class Solution {
public:
	string evaluate(string src_str, vector<vector<string>>& knowledge) {
		size_t records_count = knowledge.size();
		unordered_map<string, string> dictionary;
		dictionary.reserve(records_count);
		for (auto& record : knowledge) {
			dictionary.emplace(record[0], record[1]);
		}

		string str_interpolated;
		size_t find_pos = 0, opening_bracket_pos = string::npos;
		size_t src_str_length = src_str.length();
		for (size_t i = 0; i < src_str_length; ++i) {
			if (src_str[i] == '(') {
				opening_bracket_pos = i;
				size_t prefix_length = opening_bracket_pos - find_pos;
				str_interpolated.append(src_str, find_pos, prefix_length);
			}
			else if (src_str[i] == ')') {
				size_t closing_bracket_index = i;
				size_t key_length = closing_bracket_index - opening_bracket_pos - 1;
				string key = src_str.substr(opening_bracket_pos + 1, key_length);

				auto it = dictionary.find(key);
				if (it != dictionary.end()) {
					str_interpolated += it->second;
				}
				else {
					str_interpolated += '?';
				}
				find_pos = closing_bracket_index + 1;
			}
		}
		str_interpolated.append(src_str, find_pos, string::npos);
		return str_interpolated;
	}
};
