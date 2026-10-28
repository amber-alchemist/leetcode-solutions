// https://leetcode.com/problems/dota2-senate
// #greedy_algorithm
class Solution {
public:
	string predictPartyVictory(string senate) {
		int n = senate.size();
		int radiant_senators = 0, radiant_free_removes = 0;
		int dire_senators = 0, dire_free_removes = 0;
		while (true) {
			radiant_senators = 0, dire_senators = 0;
			for (int i = 0; i < n; ++i) {
				if (senate[i] == 'R') {
					if (dire_free_removes > 0) {
						--dire_free_removes;
						senate[i] = '0';
					}
					else {
						++radiant_senators;
						++radiant_free_removes;
					}
				}
				else if (senate[i] == 'D') {
					if (radiant_free_removes > 0) {
						--radiant_free_removes;
						senate[i] = '0';
					}
					else {
						++dire_senators;
						++dire_free_removes;
					}
				}
			}
			if (dire_senators - radiant_free_removes <= 0) {
				return "Radiant";
			}
			if (radiant_senators - dire_free_removes <= 0) {
				return "Dire";
			}
		}
	}
};
