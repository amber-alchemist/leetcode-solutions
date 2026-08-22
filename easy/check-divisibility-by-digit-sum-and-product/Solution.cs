// https://leetcode.com/problems/check-divisibility-by-digit-sum-and-product
// #math
public class Solution
{
	public bool CheckDivisibility(int n)
	{
		int digitSum = 0;
		int digitProduct = 1;
		int numberCopy = n;
		while (numberCopy > 0) {
			numberCopy = Math.DivRem(numberCopy, 10, out int digit);
			digitSum += digit;
			digitProduct *= digit;
		}
		return n % (digitSum + digitProduct) == 0;
	}
}
