// https://leetcode.com/problems/string-compression
// #string
class Solution {
public:
	int compress(vector<char>& chars) {
		int source_length = chars.size();
		int compressing_ptr = 0;
		int current_group_length = 1;
		for (int i = 1; i < source_length; ++i) {
			if (chars[i - 1] == chars[i]) {
				++current_group_length;
			}
			else {
				_compressGroup(chars, chars[i - 1], compressing_ptr, current_group_length);
				current_group_length = 1;
			}
		}
		_compressGroup(chars, chars[source_length - 1], compressing_ptr, current_group_length);
		return compressing_ptr;
	}
private:
	void _compressGroup(vector<char>& chars, char current_char, int& compressing_ptr, int current_group_length) {
		chars[compressing_ptr++] = current_char;
		if (current_group_length == 1) {
			return;
		}

		int digits_count = 0;
		while (current_group_length > 0) {
			int digit = current_group_length % 10;
			chars[compressing_ptr + digits_count++] = '0' + digit;
			current_group_length /= 10;
		}

		int swaps_count = digits_count / 2;
		int last_digit_index = compressing_ptr + digits_count - 1;
		for (int i = 0; i < swaps_count; ++i) {
			swap(chars[compressing_ptr + i], chars[last_digit_index - i]);
		}
		compressing_ptr += digits_count;
	}
};
