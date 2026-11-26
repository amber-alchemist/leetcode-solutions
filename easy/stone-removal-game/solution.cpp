// https://leetcode.com/problems/stone-removal-game
// #math
class Solution {
public:
	bool canAliceWin(int n) {
		for (int i = 10; i > 0; n -= i--) {
			if (i > n) {
				return i % 2 == 1;
			}
		}
		return true;
	}
};
