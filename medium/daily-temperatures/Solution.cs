// https://leetcode.com/problems/daily-temperatures
// #stack
public class Solution
{
	public int[] DailyTemperatures(int[] temperatures)
	{
		int daysCount = temperatures.Length;
		var awaitingDays = new int[daysCount];
		var stack = new Stack<int>();
		for (int i = daysCount - 1; i >= 0; --i) {
			while (stack.TryPeek(out int j)) {
				if (temperatures[i] < temperatures[j]) {
					awaitingDays[i] += 1;
					break;
				}
				stack.Pop();
				awaitingDays[i] += awaitingDays[j];
			}
			if (stack.Count == 0) {
				awaitingDays[i] = 0;
			}
			stack.Push(i);
		}
		return awaitingDays;
	}
}
