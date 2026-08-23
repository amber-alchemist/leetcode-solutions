// https://leetcode.com/problems/minimum-operations-to-make-a-uni-value-grid
// #matrix #hash_table #math
public class Solution
{
	public int MinOperations(int[][] grid, int x)
	{
		int rows = grid.Length;
		int columns = grid[0].Length;
		int minValue = int.MaxValue;

		var frequences = new SortedDictionary<int, int>();
		for (int i = 0; i < rows; ++i) {
			for (int j = 0; j < columns; ++j) {
				int value = grid[i][j];
				if (Math.Abs(grid[0][0] - value) % x != 0) {
					return -1;
				}
				minValue = Math.Min(minValue, value);
				if (!frequences.TryGetValue(value, out int count)) {
					count = 0;
				}
				frequences[value] = count + 1;
			}
		}

		int operationsFromStart = 0;
		int rightPoints = 0, rightOperations = 0;
		int prevValue = minValue;
		foreach ((int value, int count) in frequences) {
			if (value == minValue) {
				continue;
			}
			int operationsBetween = (value - prevValue) / x;
			operationsFromStart += operationsBetween;
			rightOperations += operationsFromStart * count;
			rightPoints += count;
			prevValue = value;
		}

		int minOperations = rightOperations;
		int leftPoints = 0, leftOperations = 0;
		prevValue = minValue;
		foreach ((int value, int count) in frequences) {
			if (value == minValue) {
				leftPoints += count;
				continue;
			}
			int operationsBetween = (value - prevValue) / x;
			leftOperations += leftPoints * operationsBetween;
			rightOperations -= rightPoints * operationsBetween;
			minOperations = Math.Min(minOperations, leftOperations + rightOperations);
			leftPoints += count;
			rightPoints -= count;
			prevValue = value;
		}
		return minOperations;
	}
}
