// https://leetcode.com/problems/hamming-distance
// #biwise_operations
public class Solution
{
	public int HammingDistance(int x, int y)
	{
		int hammingDistance = 0;
		int xor = x ^ y;
		while (xor != 0) {
			hammingDistance += xor & 1;
			xor >>= 1;
		}
		return hammingDistance;
	}
}
