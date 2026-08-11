// https://leetcode.com/problems/maximum-product-of-two-digits
// #math
public class Solution
{
	public int MaxProduct(int n)
	{
		n = Math.DivRem(n, 10, out int firstDigit);
		n = Math.DivRem(n, 10, out int secondDigit);
		if (firstDigit < secondDigit) {
			(firstDigit, secondDigit) = (secondDigit, firstDigit);
		}
		while (n > 0) {
			n = Math.DivRem(n, 10, out int digit);
			if (digit > firstDigit) {
				secondDigit = firstDigit;
				firstDigit = digit;
			}
			else if (digit == firstDigit || digit > secondDigit) {
				secondDigit = digit;
			}
		}
		return firstDigit * secondDigit;
	}
}
