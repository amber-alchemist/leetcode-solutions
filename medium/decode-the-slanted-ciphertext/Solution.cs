// https://leetcode.com/problems/decode-the-slanted-ciphertext
// #string
public class Solution
{
	public string DecodeCiphertext(string encodedText, int rows)
	{
		var stringBuilder = new StringBuilder();
		int columns = encodedText.Length / rows;
		int offset = columns + 1;
		int savedSpaces = 0;
		for (int i = 0; i < columns; ++i) {
			int index = i - offset;
			for (int j = 0; j < rows; ++j) {
				index += offset;
				if (index < encodedText.Length) {
					if (encodedText[index] == ' ') {
						++savedSpaces;
					} else {
						for (int k = 0; k < savedSpaces; ++k) {
							stringBuilder.Append(' ');
						}
						savedSpaces = 0;
						stringBuilder.Append(encodedText[index]);
					}
				}
			}
		}
		return stringBuilder.ToString();
	}
}
