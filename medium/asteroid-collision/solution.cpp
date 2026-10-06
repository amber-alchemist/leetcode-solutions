// https://leetcode.com/problems/asteroid-collision
// #stack
class Solution {
public:
	vector<int> asteroidCollision(vector<int>& asteroids) {
		vector<int> stack(asteroids.size());
		int stack_end = -1;
		for (int value : asteroids) {
			if (value > 0) {
				stack[++stack_end] = value;
				continue;
			}

			int size = -value;
			while (size > 0 && stack_end >= 0 && stack[stack_end] > 0) {
				if (stack[stack_end] < size) {
					--stack_end;
				}
				else if (stack[stack_end] > size) {
					size = 0;
				}
				else {
					size = 0;
					--stack_end;
				}
			}

			if (size > 0) {
				stack[++stack_end] = value;
			}
		}

		stack.resize(stack_end + 1);
		return stack;
	}
};
