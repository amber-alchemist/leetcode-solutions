// https://leetcode.com/problems/maximum-ice-cream-bars
// #greedy_algorithm
class Solution {
public:
	int maxIceCream(vector<int>& costs, int coins) {
		int max_cost = 0;
		for (int i = 0; i < costs.size(); ++i) {
			max_cost = max(max_cost, costs[i]);
		}

		vector<int> counts(max_cost + 1, 0);
		for (int i = 0; i < costs.size(); ++i) {
			++counts[costs[i]];
		}

		int boughtIceCreamNumber = 0;
		for (int cost = 1; cost <= max_cost; ++cost) {
			if (counts[cost] == 0) {
				continue;
			}
			int can_buy = coins / cost;
			if (can_buy == 0) {
				break;
			}
			int will_buy = min(can_buy, counts[cost]);
			boughtIceCreamNumber += will_buy;
			int coins_spent = will_buy * cost;
			coins -= coins_spent;
			if (coins == 0) {
				break;
			}
		}
		return boughtIceCreamNumber;
	}
};
