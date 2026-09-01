// https://leetcode.com/problems/jewels-and-stones
// #string #hash_table
class Solution {
public:
	int numJewelsInStones(string jewels, string stones) {
		unordered_set<char> jewels_set;
		for (int i = 0; i < jewels.length(); ++i) {
			jewels_set.insert(jewels[i]);
		}
		int jewels_count = 0;
		for (int i = 0; i < stones.length(); ++i) {
			if (jewels_set.contains(stones[i])) {
				++jewels_count;
			}
		}
		return jewels_count;
	}
};
