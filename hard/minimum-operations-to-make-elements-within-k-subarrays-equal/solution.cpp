// https://leetcode.com/problems/minimum-operations-to-make-elements-within-k-subarrays-equal
// #hash_table #dynamic_programming #sliding_window
class Solution {
public:
	long long minOperations(vector<int>& nums, int x, int k) {
		int n = nums.size();
		int m = n - x + 1;

		vector<long long> min_operations(m);
		if (x == 2) {
			int left_value = nums[0], right_value = nums[1];
			if (left_value > right_value) {
				swap(left_value, right_value);
			}

			min_operations[0] = right_value - left_value;
			for (int i = 2; i < n; ++i) {
				if (left_value == nums[i - 2]) {
					left_value = nums[i];
				}
				else {
					right_value = nums[i];
				}
				if (left_value > right_value) {
					swap(left_value, right_value);
				}
				min_operations[i - 1] = right_value - left_value;
			}
		}
		else {
			multiset<int> left_group;
			int left_group_size = x / 2 + x % 2;
			long long left_group_sum = 0LL;
			for (int i = 0; i < left_group_size; ++i) {
				left_group.insert(nums[i]);
				left_group_sum += nums[i];
			}

			multiset<int> right_group;
			int right_group_size = x - left_group_size;
			long long right_group_sum = 0LL;

			auto median_it = prev(left_group.end());
			long long median = *median_it;
			for (int i = left_group_size; i < x; ++i) {
				if (nums[i] >= median) {
					right_group.insert(nums[i]);
					right_group_sum += nums[i];
				}
				else {
					left_group.erase(median_it);
					left_group.insert(nums[i]);
					left_group_sum += nums[i] - median;

					right_group.insert(median);
					right_group_sum += median;

					median_it = prev(left_group.end());
					median = *median_it;
				}
			}

			long long add = left_group_size > right_group_size ? median : 0LL;
			min_operations[0] = right_group_sum - left_group_sum + add;

			for (int i = x; i < n; ++i) {
				bool left_group_changed = false;

				int erased_value = nums[i - x];
				auto left_it = left_group.find(erased_value);
				if (left_it != left_group.end()) {
					left_group.erase(left_it);
					left_group_changed = true;
					left_group_sum -= erased_value;
				}
				else {
					right_group.erase(right_group.find(erased_value));
					right_group_sum -= erased_value;
				}

				if (left_group_changed) {
					median_it = prev(left_group.end());
					median = *median_it;
					left_group_changed = false;
				}

				if (nums[i] >= median) {
					right_group.insert(nums[i]);
					right_group_sum += nums[i];
				}
				else {
					left_group.insert(nums[i]);
					left_group_changed = true;
					left_group_sum += nums[i];
				}

				if (left_group_changed) {
					median_it = prev(left_group.end());
					median = *median_it;
					left_group_changed = false;
				}

				if (left_group.size() > left_group_size) {
					left_group.erase(median_it);
					left_group_changed = true;
					left_group_sum -= median;
					right_group.insert(median);
					right_group_sum += median;
				}
				else if (right_group.size() > right_group_size) {
					auto right_it = right_group.begin();
					int erased_value = *right_it;

					left_group.insert(erased_value);
					left_group_changed = true;
					left_group_sum += erased_value;
					right_group.erase(right_it);
					right_group_sum -= erased_value;
				}

				if (left_group_changed) {
					median_it = prev(left_group.end());
					median = *median_it;
				}

				add = left_group_size > right_group_size ? median : 0LL;
				min_operations[i - x + 1] = right_group_sum - left_group_sum + add;
			}
		}

		vector<long long> dp_previous(m + 1, 0LL);
		vector<long long> dp_current(m + 1, LLONG_MAX);
		for (int i = 0; i < k; ++i) {
			fill(dp_current.begin(), dp_current.end(), LLONG_MAX);
			for (int j = i * x; j < m; ++j) {
				int previous_index = max(0, j - x + 1);
				dp_current[j + 1] = min(dp_current[j], dp_previous[previous_index] + min_operations[j]);
			}
			dp_previous.swap(dp_current);
		}
		return dp_previous[m];
	}
};
