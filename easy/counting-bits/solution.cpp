// https://leetcode.com/problems/counting-bits
// #bitwise_operations #dynamic_programming
class Solution {
public:
	vector<int> countBits(int n) {
		vector<int> bits_counters(n + 1, 0);
		int offset = 1;
		for (int i = 1; i <= n; ++i) {
			if (i == offset << 1) {
				offset <<= 1;
			}
			bits_counters[i] = bits_counters[i - offset] + 1;
		}
		return bits_counters;
	}
};
