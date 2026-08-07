// https://leetcode.com/problems/valid-palindrome
// #two_pointers
public class Solution
{
	public bool IsPalindrome(string s)
	{
		int left = 0;
		int right = s.Length - 1;
		while (left < right) {
			if (!char.IsLetter(s[left]) && !char.IsDigit(s[left])) {
				++left;
			}
			else if (!char.IsLetter(s[right]) && !char.IsDigit(s[right])) {
				--right;
			}
			else if (char.ToLower(s[left]) != char.ToLower(s[right])) {
				return false;
			}
			else {
				++left;
				--right;
			}
		}
		return true;
	}
}
