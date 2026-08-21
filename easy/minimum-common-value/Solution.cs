// https://leetcode.com/problems/minimum-common-value
// #array
public class Solution
{
	public int GetCommon(int[] nums1, int[] nums2)
	{
		int n = nums1.Length, m = nums2.Length;
		for (int i = 0, j = 0; i < n && j < m;) {
			if (nums1[i] == nums2[j]) {
				return nums1[i];
			}
			else if (nums1[i] < nums2[j]) {
				++i;
			}
			else {
				++j;
			}
		}
		return -1;
	}
}
