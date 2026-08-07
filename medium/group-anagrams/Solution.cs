// https://leetcode.com/problems/group-anagrams
// #hash_table
public class Solution
{
	public IList<IList<string>> GroupAnagrams(string[] strs)
	{
		const int EnglishAlphabetSize = 26;
		var lettersFrequenciesCode = new char[EnglishAlphabetSize];

		var anagramGroups = new Dictionary<string, List<string>>();
		foreach (string str in strs) {
			Array.Clear(lettersFrequenciesCode);
			foreach (char letter in str) {
				++lettersFrequenciesCode[letter - 'a'];
			}

			// Max frequence by problems condition is 5000, so we can transform frequence to char (Max char value is 65535).
			// Every key is 26 chars string, where every char code is ['a' + lettersFrequenciesCode[i]].
			// So it's just cheaper replacement of key like '{freq_a}#{freq_b}#{freq_c}#...'.
			var key = new string(lettersFrequenciesCode);
			if (!anagramGroups.TryGetValue(key, out var group)) {
				anagramGroups[key] = group = new();
			}
			group.Add(str);
		}

		List<IList<string>> result = new(anagramGroups.Keys.Count);
		foreach (var group in anagramGroups.Values) {
			result.Add(group);
		}
		return result;
	}
}
