// https://leetcode.com/problems/find-the-difference-of-two-arrays
// #hash_set
class Solution {
public:
	vector<vector<int>> findDifference(vector<int>& nums1, vector<int>& nums2) {
		unordered_set<int> set1(nums1.size());
		for (int item : nums1) {
			set1.insert(item);
		}
		unordered_set<int> set2(nums2.size());
		for (int item : nums2) {
			set2.insert(item);
		}

		vector<int> difference1;
		difference1.reserve(nums1.size());
		for (int item : set1) {
			if (!set2.contains(item)) {
				difference1.push_back(item);
			}
		}

		vector<int> difference2;
		difference2.reserve(nums2.size());
		for (int item : set2) {
			if (!set1.contains(item)) {
				difference2.push_back(item);
			}
		}
		return { difference1, difference2 };
	}
};
