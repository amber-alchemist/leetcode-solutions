// https://leetcode.com/problems/minimum-sum-of-squared-difference
// #sorting #greedy_algorithm #math
class Solution {
public:
	long long minSumSquareDiff(vector<int>& nums1, vector<int>& nums2, int k1, int k2) {
		int n = nums1.size();
		vector<int> differnces(n);
		for (int i = 0; i < n; ++i) {
			differnces[i] = abs(nums1[i] - nums2[i]);
		}
		sort(differnces.begin(), differnces.end());

		long long operations_count = k1 + k2;
		long long processed_segment_length = 1ll;
		long long additional_decreased_segment_length = 0ll;
		long long processed_value = differnces[n - 1];
		for (int i = n - 2; i >= 0 && operations_count > 0ll; --i) {
			long long diff = processed_value - differnces[i];
			if (diff == 0ll) {
				++processed_segment_length;
				continue;
			}
			long long operations_to_use = diff * processed_segment_length;
			if (operations_to_use <= operations_count) {
				operations_count -= operations_to_use;
				++processed_segment_length;
				processed_value = differnces[i];
			}
			else {
				processed_value -= operations_count / processed_segment_length;
				additional_decreased_segment_length = operations_count % processed_segment_length;
				operations_count = 0ll;
			}
		}

		long long min_sum_square_diff = 0ll;
		if (operations_count > 0ll) {
			processed_value -= operations_count / n;
			long long r = operations_count % n;
			if (processed_value > 0) {
				min_sum_square_diff += pow(processed_value, 2) * (long long)(n - r);
				min_sum_square_diff += pow(processed_value - 1ll, 2) * r;
			}
		}
		else {
			long long unprocessed_length = n - processed_segment_length;
			for (int i = 0; i < unprocessed_length; ++i) {
				min_sum_square_diff += pow(differnces[i], 2);
			}
			processed_segment_length -= additional_decreased_segment_length;
			min_sum_square_diff += pow(processed_value, 2) * processed_segment_length;
			min_sum_square_diff += pow(processed_value - 1ll, 2) * additional_decreased_segment_length;
		}
		return min_sum_square_diff;
	}
};
