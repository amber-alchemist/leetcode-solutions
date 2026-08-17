// https://leetcode.com/problems/intersection-of-two-arrays-ii
// #array
public class Solution
{
	public int[] Intersect(int[] nums1, int[] nums2)
	{
		const int MaxNumber = 1000;

		var frequenciesOfFirst = new byte[MaxNumber + 1];
		for (int i = 0; i < nums1.Length; ++i) {
			++frequenciesOfFirst[nums1[i]];
		}

		var frequenciesOfSecond = new byte[MaxNumber + 1];
		for (int i = 0; i < nums2.Length; ++i) {
			++frequenciesOfSecond[nums2[i]];
		}

		int intersectionsCount = 0;
		for (int i = 0; i <= MaxNumber; ++i) {
			intersectionsCount += Math.Min(frequenciesOfFirst[i], frequenciesOfSecond[i]);
		}

		var intersections = new int[intersectionsCount];
		for (int i = 0, j = 0; i <= MaxNumber; ++i) {
			int count = Math.Min(frequenciesOfFirst[i], frequenciesOfSecond[i]);
			for (int k = 0; k < count; ++k) {
				intersections[j++] = i;
			}
		}
		return intersections;
	}
}
