// https://leetcode.com/problems/count-days-spent-together
// #string #math
class Solution {
public:
	int countDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob) {
		int alice_arrive_day = _getDayNumber(arriveAlice);
		int alice_leave_day = _getDayNumber(leaveAlice);

		int bob_arrive_day = _getDayNumber(arriveBob);
		int bob_leave_day = _getDayNumber(leaveBob);

		int earliest_arrive_day = max(alice_arrive_day, bob_arrive_day);
		int earliset_leave_day = min(alice_leave_day, bob_leave_day);

		return max(0, earliset_leave_day - earliest_arrive_day + 1);
	}
private:
	vector<int> _days_per_month = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

	int _getDayNumber(string date) {
		int day_number = stoi(date.substr(3, 2));
		int month_number = stoi(date.substr(0, 2)) - 1;
		for (int i = 0; i < month_number; ++i) {
			day_number += _days_per_month[i];
		}
		return day_number;
	}
};
