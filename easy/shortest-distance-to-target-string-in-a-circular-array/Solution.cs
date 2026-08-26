// https://leetcode.com/problems/shortest-distance-to-target-string-in-a-circular-array
// #string
public class Solution
{
	public int ClosestTarget(string[] words, string target, int startIndex)
	{
		if (words[startIndex] == target) {
			return 0;
		}

		int n = words.Length;
		int maxSteps = n / 2;
		for (int s = 1; s <= maxSteps; ++s) {
			string prev = words[(startIndex - s + n) % n];
			if (prev == target) {
				return s;
			}
			string next = words[(startIndex + s) % n];
			if (next == target) {
				return s;
			}
		}
		return -1;
	}
}
