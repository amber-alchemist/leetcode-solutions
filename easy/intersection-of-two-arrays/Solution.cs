// https://leetcode.com/problems/intersection-of-two-arrays
// #array
public class Solution
{
	public int[] Intersection(int[] nums1, int[] nums2)
	{
		const int MaxNumber = 1000;

		var isNumberPresent = new byte[MaxNumber + 1];
		for (int i = 0; i < nums1.Length; ++i) {
			isNumberPresent[nums1[i]] = 1;
		}

		int intersectionsCount = 0;
		for (int i = 0; i < nums2.Length; ++i) {
			if (isNumberPresent[nums2[i]] == 1) {
				++intersectionsCount;
				isNumberPresent[nums2[i]] = 2;
			}
		}

		var intersection = new int[intersectionsCount];
		for (int i = 0, j = 0; i < nums2.Length; ++i) {
			if (isNumberPresent[nums2[i]] == 2) {
				intersection[j++] = nums2[i];
				isNumberPresent[nums2[i]] = 3;
			}
		}
		return intersection;
	}
}
