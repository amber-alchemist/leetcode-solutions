// https://leetcode.com/problems/can-place-flowers
// #array #greedy_algorithm
class Solution {
public:
	bool canPlaceFlowers(vector<int>& flowerbed, int n) {
		if (n == 0) {
			return true;
		}
		int flowerbed_size = flowerbed.size();
		if (flowerbed_size == 1) {
			return flowerbed[0] == 0;
		}
		if (flowerbed[0] == 0 && flowerbed[1] == 0) {
			--n;
			flowerbed[0] = 1;
		}
		for (int i = 1; i < flowerbed_size - 1; ++i) {
			int status = flowerbed[i - 1] + flowerbed[i] + flowerbed[i + 1];
			if (status == 0) {
				--n;
				flowerbed[i++] = 1;
			}
		}
		if (flowerbed[flowerbed_size - 2] == 0 && flowerbed[flowerbed_size - 1] == 0) {
			--n;
			flowerbed[flowerbed_size - 1] = 1;
		}
		return n <= 0;
	}
};
