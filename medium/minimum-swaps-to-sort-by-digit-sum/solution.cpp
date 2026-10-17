class dsu {
public:
	dsu(int size) : _independent_sets_count(size), _parents(size) {
		for (int i = 0; i < size; ++i) {
			_parents[i] = i;
		}
	}

	int find(int x) {
		return _parents[x] == x ? x : _parents[x] = find(_parents[x]);
	}

	int get_independent_sets_count() {
		return _independent_sets_count;
	}

	void unite(int u, int v) {
		if (_parents[u] != _parents[v]) {
			--_independent_sets_count;
		}
		_parents[u] = _parents[v];
	}
private:
	int _independent_sets_count;
	vector<int> _parents;
};

// https://leetcode.com/problems/minimum-swaps-to-sort-by-digit-sum
// #sorting #dsu
class Solution {
public:
	int minSwaps(vector<int>& nums) {
		int n = nums.size();
		vector<int> digits_sums(n);
		for (int i = 0; i < n; ++i) {
			int x = nums[i];
			while (x > 0) {
				digits_sums[i] += x % 10;
				x /= 10;
			}
		}

		vector<int> indices(n);
		for (int i = 0; i < n; ++i) {
			indices[i] = i;
		}
		sort(indices.begin(), indices.end(), [&](int a, int b) {
			return digits_sums[a] != digits_sums[b]
				? digits_sums[a] < digits_sums[b]
				: nums[a] < nums[b];
		});

		vector<int> targets(n);
		for (int i = 0; i < n; ++i) {
			targets[indices[i]] = i;
		}

		dsu dsu(n);
		for (int i = 0; i < n; ++i) {
			int current_set = dsu.find(i);
			int target_set = dsu.find(targets[i]);
			if (current_set != target_set) {
				dsu.unite(current_set, target_set);
			}
		}

		int min_swaps_count = n - dsu.get_independent_sets_count();
		return min_swaps_count;
	}
};
