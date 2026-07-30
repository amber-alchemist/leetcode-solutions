// https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays
// #biwise_operations
public class Solution
{
	public int[] FindThePrefixCommonArray(int[] a, int[] b)
	{
		int length = a.Length;
		var c = new int[length];
		ulong setA = 0UL, setB = 0UL;
		for (int i = 0; i < length; ++i) {
			setA |= 1UL << a[i];
			setB |= 1UL << b[i];
			c[i] = BitOperations.PopCount(setA & setB);
		}
		return c;
	}
}
