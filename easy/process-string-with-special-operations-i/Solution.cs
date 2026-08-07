// https://leetcode.com/problems/climbing-stairs
// #dynamic_programming
public class Solution
{
	public int ClimbStairs(int steps)
	{
		int prev = 0, current = 1;
		for (int i = 0; i < steps; ++i) {
			int next = current + prev;
			prev = current;
			current = next;
		}
		return current;
	}
}
