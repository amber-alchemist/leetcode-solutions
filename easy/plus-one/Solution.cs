// https://leetcode.com/problems/plus-one
// #math
public class Solution
{
	public int[] PlusOne(int[] digits)
	{
		for (int i = digits.Length - 1; i >= 0; --i) {
			if (digits[i] != 9) {
				digits[i] += 1;
				return digits;
			}
			digits[i] = 0;
		}

		var result = new int[digits.Length + 1];
		result[0] = 1;
		for (int i = 0; i < digits.Length; ++i) {
			result[i + 1] = digits[i];
		}
		return result;
	}
}
