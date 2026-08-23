// https://leetcode.com/problems/sum-game
// #game_theory
public class Solution
{
	public bool SumGame(string num)
	{
		int halfLength = num.Length / 2;

		int firstHalfFreeDigits = 0;
		int firstHalfSum = 0;
		for (int i = 0; i < halfLength; ++i) {
			if (num[i] == '?') {
				++firstHalfFreeDigits;
			}
			else {
				firstHalfSum += num[i] - '0';
			}
		}

		int secondHalfFreeDigits = 0;
		int secondHalfSum = 0;
		for (int i = halfLength; i < num.Length; ++i) {
			if (num[i] == '?') {
				++secondHalfFreeDigits;
			}
			else {
				secondHalfSum += num[i] - '0';
			}
		}

		bool isAliceWin = false;
		int totalFreeDigits = firstHalfFreeDigits + secondHalfFreeDigits;
		if (totalFreeDigits % 2 == 1) {
			isAliceWin = true;
		}
		else {
			int sumDiff = firstHalfSum - secondHalfSum;
			int freeDigitsDiff = secondHalfFreeDigits - firstHalfFreeDigits;
			isAliceWin = sumDiff != freeDigitsDiff * 9 / 2;
		}
		return isAliceWin;
	}
}
