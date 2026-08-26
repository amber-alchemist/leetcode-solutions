// https://leetcode.com/problems/mirror-distance-of-an-integer
// #math
public class Solution
{
	public int MirrorDistance(int number)
	{
		int copy = number;
		int reverse = 0;
		while (copy > 0) {
			copy = Math.DivRem(copy, 10, out int lastDigit);
			reverse = reverse * 10 + lastDigit;
		}
		int mirrorDistance = Math.Abs(number - reverse);
		return mirrorDistance;
	}
}
