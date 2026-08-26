// https://leetcode.com/problems/shortest-and-lexicographically-smallest-beautiful-string
// #string #sliding_window
public class Solution
{
	public string ShortestBeautifulSubstring(string s, int k)
	{
		int start = 0;
		for (; start < s.Length; ++start) {
			if (s[start] == '1') {
				break;
			}
		}
		if (start == s.Length) {
			return string.Empty;
		}
		if (k == 1) {
			return s[start..(start + 1)];
		}

		int onesCount = 1;
		int end = start + 1;
		for (; end < s.Length; ++end) {
			if (s[end] == '1' && ++onesCount == k) {
				break;
			}
		}
		if (onesCount < k) {
			return string.Empty;
		}

		int shortestLength = end - start + 1;
		int left = start;
		for (int right = end + 1; right < s.Length; ++right) {
			if (s[right] == '0') {
				continue;
			}
			++left;
			while (s[left] == '0') {
				++left;
			}

			int currentLength = right - left + 1;
			if (currentLength < shortestLength) {
				start = left;
				end = right;
				shortestLength = currentLength;
			}
			else if (currentLength == shortestLength) {
				for (int i = 1; i < currentLength - 1; ++i) {
					if (s[left + i] != s[start + i]) {
						if (s[left + i] == '0') {
							start = left;
							end = right;
							shortestLength = currentLength;
						}
						break;
					}
				}
			}
		}
		return s[start..(end + 1)];
	}
}
