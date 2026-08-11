// https://leetcode.com/problems/rotate-string
// #string
public class Solution
{
	public bool RotateString(string sourceStr, string goalStr)
	{
		return
			sourceStr.Length == goalStr.Length &&
			(sourceStr + sourceStr).Contains(goalStr);
	}
}
