// https://leetcode.com/problems/maximum-distance-between-a-pair-of-values
// #two_pointers
public class Solution
{
	public int MaxDistance(int[] nums1, int[] nums2)
	{
		int maxDistance = 0;
		for (int index1 = 0, index2 = 0; index1 < nums1.Length && index2 < nums2.Length; ) {
			if (index1 <= index2) {
				if (nums1[index1] <= nums2[index2]) {
					maxDistance = Math.Max(maxDistance, index2 - index1);
					++index2;
				}
				else {
					++index1;
				}
			} else {
				++index2;
			}
		}
		return maxDistance;
	}
}
