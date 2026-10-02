// https://leetcode.com/problems/generate-parentheses
// #combinatorics #backtracking
class Solution {
public:
	vector<string> generateParenthesis(int n) {
		_length = n + n;
		_currrent_combination.resize(_length);
		_currrent_combination[0] = '(';
		_generate(n - 1, n, 1);
		return _all_combinations;
	}
private:
	int _length = 0;
	string _currrent_combination;
	vector<string> _all_combinations;

	void _generate(int left_open_brackets, int left_close_brackets, int index) {
		if (left_open_brackets == 0) {
			for (int i = index; i < _length; ++i) {
				_currrent_combination[i] = ')';
			}
			_all_combinations.push_back(string(_currrent_combination));
		}
		else {
			_currrent_combination[index] = '(';
			_generate(left_open_brackets - 1, left_close_brackets, index + 1);
			if (left_open_brackets < left_close_brackets) {
				_currrent_combination[index] = ')';
				_generate(left_open_brackets, left_close_brackets - 1, index + 1);
			}
		}
	}
};
