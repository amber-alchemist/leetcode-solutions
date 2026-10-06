// https://leetcode.com/problems/max-consecutive-ones-iii
// #sliding_window
class Solution {
public:
	int longestOnes(vector<int>& nums, int k) {
		int n = nums.size();
		int consequtive_ones = 0;
		int max_consequtive_ones = 0;
		if (k > 0) {
			int operations = k;
			for (int left = 0, right = 0; right < n; ++right) {
				if (nums[right] == 1) {
					++consequtive_ones;
				}
				else {
					if (operations == 0) {
						while (left < right) {
							--consequtive_ones;
							if (nums[left++] == 0) {
								++operations;
								break;
							}
						}
					}
					if (operations > 0) {
						++consequtive_ones;
						--operations;
					}
				}
				if (consequtive_ones > max_consequtive_ones) {
					max_consequtive_ones = consequtive_ones;
				}
			}
		}
		else {
			for (int right = 0; right < n; ++right) {
				if (nums[right] == 1) {
					if (++consequtive_ones > max_consequtive_ones) {
						max_consequtive_ones = consequtive_ones;
					}
				}
				else {
					consequtive_ones = 0;
				}
			}
		}
		return max_consequtive_ones;
	}
};
