// https://leetcode.com/problems/generate-parentheses
// #stack #combinatorics #backtracking
public class Solution
{
	public IList<string> GenerateParenthesis(int n)
	{
		int length = n + n;

		var parentheses = new List<string>();
		var stack = new char[length];
		stack[0] = '(';
		Generate(n - 1, n, 1);
		return parentheses;

		void Generate(int leftOpen, int leftClose, int index)
		{
			if (leftOpen == 0) {
				for (int i = index; i < length; ++i) {
					stack[i] = ')';
				}
				parentheses.Add(new string(stack));
			} else {
				stack[index] = '(';
				Generate(leftOpen - 1, leftClose, index + 1);
				if (leftOpen < leftClose) {
					stack[index] = ')';
					Generate(leftOpen, leftClose - 1, index + 1);
				}
			}
		}
	}
}
