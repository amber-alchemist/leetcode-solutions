// https://leetcode.com/problems/boats-to-save-people
// #two_pointers #sorting
class Solution {
public:
	int numRescueBoats(vector<int>& people, int limit) {
		sort(people.begin(), people.end());
		int people_count = people.size();
		int min_rescue_boats_count = people_count;
		for (int left = 0, right = people_count - 1; left < right; --right) {
			int weight = people[left] + people[right];
			if (weight <= limit) {
				++left;
				--min_rescue_boats_count;
			}
		}
		return min_rescue_boats_count;
	}
};
