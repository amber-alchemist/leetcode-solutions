// https://leetcode.com/problems/angle-between-hands-of-a-clock
// #math
class Solution {
public:
	double angleClock(int hour, int minutes) {
		double minutes_angle = minutes * 6.0;
		double hour_angle = (hour % 12) * 30.0 + (minutes / 2.0);
		double diff = abs(minutes_angle - hour_angle);
		return min(diff, 360.0 - diff);
	}
};
