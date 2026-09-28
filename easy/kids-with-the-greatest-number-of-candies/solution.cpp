// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies
// #array
class Solution {
public:
	vector<bool> kidsWithCandies(vector<int>& candies, int extra_candies) {
		int n = candies.size();
		int max_candies = candies[0];
		for (int i = 1; i < n; ++i) {
			if (candies[i] > max_candies) {
				max_candies = candies[i];
			}
		}

		vector<bool> could_be_greatest_candies(n);
		for (int i = 0; i < n; ++i) {
			could_be_greatest_candies[i] = candies[i] + extra_candies >= max_candies;
		}
		return could_be_greatest_candies;
	}
};
