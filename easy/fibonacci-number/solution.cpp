// https://leetcode.com/problems/fibonacci-number
// #math
class Solution {
public:
	int fib(int n) {
		if (n == 0) {
			return 0;
		}
		int previous = 0;
		int current = 1;
		for (int i = 2; i <= n; ++i) {
			int next = current + previous;
			previous = current;
			current = next;
		}
		return current;
	}
};
