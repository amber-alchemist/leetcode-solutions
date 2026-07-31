// https://leetcode.com/problems/min-stack
// #stack
public class MinStack
{
	private readonly Stack<(int top, int min)> stack = new();

	public void Push(int value)
	{
		int min = stack.TryPeek(out var item) ? Math.Min(value, item.min) : value;
		stack.Push((value, min));
	}

	public void Pop() => stack.Pop();

	public int Top() => stack.Peek().top;

	public int GetMin() => stack.Peek().min;
}
