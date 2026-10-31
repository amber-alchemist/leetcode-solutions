// https://leetcode.com/problems/single-number
// #array #bitwise_operations
class Solution {
public:
	int singleNumber(vector<int>& nums) {
		int array_xor = 0;
		for (int x : nums) {
			array_xor ^= x;
		}
		return array_xor;
	}
};
