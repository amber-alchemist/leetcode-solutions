// https://leetcode.com/problems/roman-to-integer
// #string #math
public class Solution
{
	public int RomanToInt(string s)
	{
		int result = 0;
		int previous = result = GetIntFromRomanChar(s[^1]);
		for (int i = s.Length - 2; i >= 0; --i) {
			int current = GetIntFromRomanChar(s[i]);
			result += current >= previous ? current : -current;
			previous = current;
		}
		return result;
	}

	private static int GetIntFromRomanChar(char c)
	{
		return c switch {
			'I' => 1,
			'V' => 5,
			'X' => 10,
			'L' => 50,
			'C' => 100,
			'D' => 500,
			'M' => 1000,
			_ => throw new ArgumentException(),
		};
	}
}
