// https://leetcode.com/problems/add-binary
// #biwise_operations
public class Solution
{
	public string AddBinary(string first, string second)
	{
		if (second.Length > first.Length) {
			(first, second) = (second, first);
		}
		var digits = new char[first.Length];
		int offset = first.Length - second.Length;
		bool carry = false;
		for (int i = second.Length - 1; i >= 0; --i) {
			bool a = first[i + offset] == '1';
			bool b = second[i] == '1';
			if (a && b) {
				digits[i + offset] = carry ? '1' : '0';
				carry = true;
			}
			else if (carry) {
				digits[i + offset] = !(a || b) ? '1' : '0';
				carry = a || b;
			}
			else {
				digits[i + offset] = a || b ? '1' : '0';
			}
		}
		for (int i = offset - 1; i >= 0; --i) {
			bool a = first[i] == '1';
			digits[i] = a ^ carry ? '1' : '0';
			carry &= a;
		}
		return carry ? "1" + new string(digits) : new string(digits);
	}
}
