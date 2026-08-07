// https://leetcode.com/problems/find-the-highest-altitude
// #math
class Solution {
public:
	int largestAltitude(vector<int>& gain) {
		int largest_altitude = 0;
		int altitude = 0;
		for (int i = 0; i < gain.size(); ++i) {
			altitude += gain[i];
			largest_altitude = max(largest_altitude, altitude);
		}
		return largest_altitude;
	}
};
