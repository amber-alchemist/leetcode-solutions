// https://leetcode.com/problems/valid-parentheses
// #stack
public class Solution
{
	public bool IsValid(string str)
	{
		if (str.Length % 2 == 1) {
			return false;
		}
		var stack = new Stack<char>();
		for (int i = 0; i < str.Length; ++i) {
			if (IsOpenBracket(str[i])) {
				stack.Push(str[i]);
			}
			else if (!stack.TryPop(out char pop) || !IsValidBracketPair(pop, str[i])) {
				return false;
			}
		}
		return stack.Count == 0;
	}

	private static bool IsOpenBracket(char c) => c == '(' || c == '{' || c == '[';

	private static bool IsValidBracketPair(char c1, char c2) =>
		c1 == '(' && c2 == ')' || c1 == '{' && c2 == '}' || c1 == '[' && c2 == ']';
}
