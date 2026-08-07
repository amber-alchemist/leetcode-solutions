// https://leetcode.com/problems/remove-covered-intervals
// #sorting
public class Solution
{
	public int RemoveCoveredIntervals(int[][] intervals)
	{
		Array.Sort(intervals, (a, b) => {
			int comparationValue = a[0].CompareTo(b[0]);
			return comparationValue != 0 ? comparationValue : a[1].CompareTo(b[1]);
		});
		int remainingIntervalsNumber = intervals.Length;
		int left = intervals[0][0];
		int right = intervals[0][1];
		for (int i = 1; i < intervals.Length; ++i) {
			if (right <= intervals[i][0]) {
				left = intervals[i][0];
				right = intervals[i][1];
			} else if (left == intervals[i][0]) {
				--remainingIntervalsNumber;
				right = intervals[i][1];
			} else if (left < intervals[i][0]) {
				if (right >= intervals[i][1]) {
					--remainingIntervalsNumber;
				} else {
					left = intervals[i][0];
					right = intervals[i][1];
				}
			}
		}
		return remainingIntervalsNumber;
	}
}
