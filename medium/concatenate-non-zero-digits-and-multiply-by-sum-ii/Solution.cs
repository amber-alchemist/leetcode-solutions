// https://leetcode.com/problems/concatenate-non-zero-digits-and-multiply-by-sum-ii
// #string #number_theory #prefix_sum 
public class Solution
{
	public int[] SumAndMultiply(string str, int[][] queries)
	{
		const long Modulo = 1000000007L;

		int m = str.Length;
		var prefixValue = new long[m + 1];
		var prefixSum = new int[m + 1];
		var prefixNonZeroDigitsCount = new int[m + 1];
		long[] powersOfTen = new long[m + 1];
		powersOfTen[0] = 1L;
		for (int i = 1; i <= m; ++i) {
			prefixSum[i] = prefixSum[i - 1];
			prefixNonZeroDigitsCount[i] = prefixNonZeroDigitsCount[i - 1];

			int digit = str[i - 1] - '0';
			if (digit == 0) {
				prefixValue[i] = prefixValue[i - 1];
			}
			else {
				prefixValue[i] = (prefixValue[i - 1] * 10L + digit) % Modulo;
				prefixSum[i] += digit;
				++prefixNonZeroDigitsCount[i];
			}
			powersOfTen[i] = powersOfTen[i - 1] * 10L % Modulo;
		}

		int q = queries.Length;
		var answers = new int[q];
		for (int i = 0; i < q; ++i) {
			int l = queries[i][0];
			int r = queries[i][1];

			int exponent = prefixNonZeroDigitsCount[r + 1] - prefixNonZeroDigitsCount[l];
			long x = prefixValue[r + 1] - prefixValue[l] * powersOfTen[exponent] % Modulo;
			if (x < 0L) {
				x += Modulo;
			}

			long s = prefixSum[r + 1] - prefixSum[l];
			answers[i] = (int)(x * s % Modulo);
		}
		return answers;
	}
}
