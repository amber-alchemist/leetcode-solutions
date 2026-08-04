// https://leetcode.com/problems/find-missing-elements
// #hash_table
public class Solution
{
	public IList<int> FindMissingElements(int[] nums)
	{
		var existingElements = new HashSet<int>();
		int minElement = int.MaxValue;
		int maxElement = int.MinValue;
		for (int i = 0; i < nums.Length; ++i) {
			existingElements.Add(nums[i]);
			minElement = Math.Min(minElement, nums[i]);
			maxElement = Math.Max(maxElement, nums[i]);
		}

		int rangeLength = maxElement - minElement + 1;
		int missingElementsCount = rangeLength - nums.Length;
		var missingElements = new List<int>(missingElementsCount);
		for (int number = minElement + 1; number < maxElement; ++number) {
			if (!existingElements.Contains(number)) {
				missingElements.Add(number);
			}
		}
		return missingElements;
	}
}
