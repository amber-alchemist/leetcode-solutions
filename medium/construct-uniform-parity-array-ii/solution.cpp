// https://leetcode.com/problems/construct-uniform-parity-array-ii
// #math #array
class Solution {
public:
	bool uniformArray(vector<int>& nums1) {
		int min_number = INT_MAX;
		bool isOddNumberExist = false;
		for (int i = 0; i < nums1.size(); ++i) {
			if ((nums1[i] & 1) == 1) {
				isOddNumberExist = true;
			}
			if (nums1[i] < min_number) {
				min_number = nums1[i];
			}
		}
		return !isOddNumberExist || (min_number & 1) == 1;
	}
};
