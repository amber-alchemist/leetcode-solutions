// https://leetcode.com/problems/valid-anagram
// #string #hash_set
public class Solution
{
	public bool IsAnagram(string s, string t)
	{
		var frequencies = new Dictionary<int, int>();
		for (int i = 0; i < s.Length; ++i) {
			if (!frequencies.TryGetValue(s[i], out int count)) {
				count = 0;
			}
			frequencies[s[i]] = count + 1;
		}

		for (int i = 0; i < t.Length; ++i) {
			if (!frequencies.TryGetValue(t[i], out int count) || count == 0) {
				return false;
			}
			frequencies[t[i]] = count - 1;
		}

		foreach (int count in frequencies.Values) {
			if (count != 0) {
				return false;
			}
		}
		return true;
	}
}
