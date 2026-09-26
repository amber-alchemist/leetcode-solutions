// https://leetcode.com/problems/evaluate-the-bracket-pairs-of-a-string
// #string #hash_table
class Solution {
public:
	string evaluate(string src_str, vector<vector<string>>& knowledge) {
		unordered_map<string, string> dictionary;
		dictionary.reserve(knowledge.size());
		for (auto& record : knowledge) {
			dictionary.emplace(record[0], record[1]);
		}

		string str_interpolated;
		size_t find_pos = 0, opening_bracket_pos;
		while ((opening_bracket_pos = src_str.find('(', find_pos)) != string::npos) {
			size_t prefix_length = opening_bracket_pos - find_pos;
			str_interpolated.append(src_str, find_pos, prefix_length);

			size_t closing_bracket_index = src_str.find(')', opening_bracket_pos);
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
		str_interpolated.append(src_str, find_pos, string::npos);
		return str_interpolated;
	}
};
