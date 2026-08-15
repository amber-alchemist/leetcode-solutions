// https://leetcode.com/problems/smallest-palindromic-rearrangement-i
// #string #two_pointers
public class Solution
{
	public string SmallestPalindrome(string s)
	{
		const int AlphabetSize = 26;

		var lettersCounts = new int[AlphabetSize];
		for (int i = 0; i < s.Length; ++i) {
			++lettersCounts[s[i] - 'a'];
		}

		var smallestPalindrome = new char[s.Length];
		int halfLength = Math.DivRem(s.Length, 2, out int offset);
		int left = halfLength - 1, right = halfLength + offset;
		for (int i = AlphabetSize - 1; i >= 0; --i) {
			if (lettersCounts[i] == 0) {
				continue;
			}
			char letter = (char)(i + 'a');
			int pairsCount = Math.DivRem(lettersCounts[i], 2, out int remainder);
			if (offset == 1 && remainder == 1) {
				smallestPalindrome[halfLength] = letter;
			}
			for (int j = 0; j < pairsCount; ++j) {
				smallestPalindrome[left--] = smallestPalindrome[right++] = letter;
			}
		}
		return new string(smallestPalindrome);
	}
}
