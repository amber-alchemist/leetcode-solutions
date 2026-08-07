// https://leetcode.com/problems/earliest-finish-time-for-land-and-water-rides-i
// #two_pointers
public class Solution
{
	public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration)
	{
		int n = landStartTime.Length;
		int m = waterStartTime.Length;

		int earliestFinishTime = int.MaxValue;
		int earliestLandEnd = int.MaxValue;
		for (int i = 0; i < n; ++i) {
			earliestLandEnd = Math.Min(earliestLandEnd, landStartTime[i] + landDuration[i]);
		}

		int earliestWaterEnd = int.MaxValue;
		for (int j = 0; j < m; ++j) {
			earliestWaterEnd = Math.Min(earliestWaterEnd, waterStartTime[j] + waterDuration[j]);

			int currentEndTime = Math.Max(earliestLandEnd, waterStartTime[j]) + waterDuration[j];
			earliestFinishTime = Math.Min(earliestFinishTime, currentEndTime);
		}
		for (int i = 0; i < n; ++i) {
			int currentEndTime = Math.Max(earliestWaterEnd, landStartTime[i]) + landDuration[i];
			earliestFinishTime = Math.Min(earliestFinishTime, currentEndTime);
		}
		return earliestFinishTime;
	}
}

