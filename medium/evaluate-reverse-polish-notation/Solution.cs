// https://leetcode.com/problems/evaluate-reverse-polish-notation
// #string #stack
public class Solution
{
	public int EvalRPN(string[] tokens)
	{
		var stack = new Stack<int>();
		for (int i = 0; i < tokens.Length; ++i) {
			if (int.TryParse(tokens[i], out int number)) {
				stack.Push(number);
			}
			else {
				char @operator = tokens[i][0];
				int b = stack.Pop();
				int a = stack.Pop();
				int r = @operator switch {
					'+' => a + b,
					'-' => a - b,
					'*' => a * b,
					'/' => a / b,
					_ => throw new ArgumentException($"Tokens conatin invalid operator: '{@operator}'"),
				};
				stack.Push(r);
			}
		}
		return stack.Pop();
	}
}
