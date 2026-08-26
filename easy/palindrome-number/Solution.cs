// https://leetcode.com/problems/palindrome-number
// #math
public class Solution
{
	public bool IsPalindrome(int number)
	{
		const int MaxDigitsCount = 10;

		if (number < 0) {
			return false;
		}
		if (number < 10) {
			return true;
		}

		int digitsCount = 0;
		int[] digits = new int[MaxDigitsCount];
		while (number > 0) {
			digits[digitsCount++] = number % 10;
			number /= 10;
		}

		int pairsCount = digitsCount / 2;
		for (int i = 0; i < pairsCount; ++i) {
			if (digits[i] != digits[digitsCount - 1 - i]) {
				return false;
			}
		}
		return true;
	}
}
