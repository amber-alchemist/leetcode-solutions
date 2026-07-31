// https://leetcode.com/problems/longest-substring-without-repeating-characters
// #sliding_window
public class Solution
{
    public int LengthOfLongestSubstring(string str)
    {
        int longestSubstringWithUniqueCharsLength = 0;

        var indicesOfUniqueChars = new Dictionary<char, int>();

        int left = 0, right = 0;
        for (; right < str.Length; ++right) {
            if (indicesOfUniqueChars.TryGetValue(str[right], out int lastIndex)) {
                left = Math.Max(left, lastIndex + 1);
            }
            indicesOfUniqueChars[str[right]] = right;

            int currentLength = right - left + 1;
            longestSubstringWithUniqueCharsLength = Math.Max(longestSubstringWithUniqueCharsLength, currentLength);
        }

        return longestSubstringWithUniqueCharsLength;
    }
}
