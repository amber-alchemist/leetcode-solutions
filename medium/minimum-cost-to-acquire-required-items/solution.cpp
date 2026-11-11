// https://leetcode.com/problems/minimum-cost-to-acquire-required-items
// #math
class Solution {
public:
	long long minimumCost(int cost1, int cost2, int costBoth, int need1, int need2) {
		return _minimumCost(cost1, cost2, costBoth, need1, need2);
	}
private:
	long long _minimumCost(int cost1, int cost2, int costBoth, long long need1, long long need2) {
		if (need1 == 0LL && need2 == 0LL) {
			return 0LL;
		}
		if (need1 == 0LL) {
			return need2 * min(cost2, costBoth);
		}
		if (need2 == 0LL) {
			return need1 * min(cost1, costBoth);
		}
		if (need1 < need2) {
			swap(need1, need2);
			swap(cost1, cost2);
		}
		long long buy_separately = cost1 * need1 + cost2 * need2;
		long long buy_both_all = costBoth * need1;
		long long buy_both_mixed = costBoth * need2 + cost1 * (need1 - need2);
		return min(buy_separately, min(buy_both_all, buy_both_mixed));
	}
};
