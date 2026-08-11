// https://leetcode.com/problems/fizz-buzz
// #math #string
public class Solution
{
	public IList<string> FizzBuzz(int n)
	{
		const string Fizz = "Fizz";
		const string Buzz = "Buzz";
		const string FizzBuzz = "FizzBuzz";

		var answers = new string[n];
		for (int i = 3; i <= n; i += 3) {
			answers[i - 1] = Fizz;
		}
		for (int i = 5; i <= n; i += 5) {
			answers[i - 1] = Buzz;
		}
		for (int i = 15; i <= n; i += 15) {
			answers[i - 1] = FizzBuzz;
		}
		for (int i = 1; i <= n; ++i) {
			answers[i - 1] ??= i.ToString();
		}
		return answers;
	}
}
