// https://leetcode.com/problems/separate-the-digits-in-an-array
// #stack
public class Solution
{
	public int[] SeparateDigits(int[] nums)
	{
		var separatedDigits = new List<int>();
		var stack = new Stack<int>();
		for (int i = 0; i < nums.Length; ++i) {
			int number = nums[i];
			do {
				number = Math.DivRem(number, 10, out int digit);
				stack.Push(digit);
			}
			while (number > 0);
			while (stack.TryPop(out int digit)) {
				separatedDigits.Add(digit);
			}
		}
		return separatedDigits.ToArray();
	}
}
