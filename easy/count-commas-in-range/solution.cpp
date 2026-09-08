// https://leetcode.com/problems/count-commas-in-range
// #math
class Solution {
public:
	int countCommas(int n) {
		return n >= 1000 ? n - 1000 + 1 : 0;
	}
};
