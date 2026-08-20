// https://leetcode.com/problems/distribute-elements-into-two-arrays-i
// #array #two_pointers
public class Solution
{
	public int[] ResultArray(int[] nums)
	{
		int n = nums.Length;
		var resultArray = new int[n];
		int a = 0, b = n - 1;
		resultArray[a] = nums[0];
		resultArray[b] = nums[1];
		for (int i = 2; i < n; ++i) {
			if (resultArray[a] > resultArray[b]) {
				resultArray[++a] = nums[i];
			}
			else {
				resultArray[--b] = nums[i];
			}
		}
		int bArrayHalfSize = (n - b) / 2;
		for (int i = 0; i < bArrayHalfSize; ++i) {
			(resultArray[b + i], resultArray[n - 1 - i]) = (resultArray[n - 1 - i], resultArray[b + i]);
		}
		return resultArray;
	}
}
