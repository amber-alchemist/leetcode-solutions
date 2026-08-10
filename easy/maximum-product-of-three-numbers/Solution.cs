// https://leetcode.com/problems/maximum-product-of-three-numbers
// #math
public class Solution
{
	public int MaximumProduct(int[] nums)
	{
		int a = nums[0], b = nums[1], c = nums[2];
		if (a < b) {
			(a, b) = (b, a);
		}
		if (b < c) {
			(b, c) = (c, b);
			if (a < b) {
				(a, b) = (b, a);
			}
		}
		int y = b, z = c;
		for (int i = 3; i < nums.Length; ++i) {
			if (nums[i] > c) {
				c = nums[i];
				if (b < c) {
					(b, c) = (c, b);
					if (a < b) {
						(a, b) = (b, a);
					}
				}
			}
			else if (y > nums[i]) {
				y = nums[i];
				if (z > y) {
					(z, y) = (y, z);
				}
			}
		}
		return Math.Max(a * b * c, a * y * z);
	}
}
