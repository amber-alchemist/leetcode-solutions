// https://leetcode.com/problems/rectangle-overlap
// #geometry
class Solution {
public:
	bool isRectangleOverlap(vector<int>& rec1, vector<int>& rec2) {
		int ax = rec1[0], bx = rec1[2], cx = rec2[0], dx = rec2[2];
		bool is_width_greater_zero = min(bx, dx) > max(ax, cx);
		if (!is_width_greater_zero) {
			return false;
		}

		int ay = rec1[1], by = rec1[3], cy = rec2[1], dy = rec2[3];
		bool is_height_greater_zero = min(by, dy) > max(ay, cy);
		return is_height_greater_zero > 0;
	}
};
