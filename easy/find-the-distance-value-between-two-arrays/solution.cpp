// https://leetcode.com/problems/find-the-distance-value-between-two-arrays
// #array
class Solution {
public:
	int findTheDistanceValue(vector<int>& arr1, vector<int>& arr2, int d) {
		int distance_value = arr1.size();
		for (int x : arr1) {
			for (int y : arr2) {
				if (abs(x - y) <= d) {
					--distance_value;
					break;
				}
			}
		}
		return distance_value;
	}
};
