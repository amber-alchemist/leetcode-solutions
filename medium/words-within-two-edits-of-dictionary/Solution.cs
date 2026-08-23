// https://leetcode.com/problems/words-within-two-edits-of-dictionary
// #trie #string
public class Solution
{
	public IList<string> TwoEditWords(string[] queries, string[] dictionary)
	{
		var trie = new Trie(dictionary);
		List<string> result = [];
		foreach (var queryWord in queries) {
			if (trie.ContainsSimilarWord(queryWord)) {
				result.Add(queryWord);
			}
		}
		return result;
	}
}

public class Trie
{
	private readonly Node root = new();

	public Trie(string[] words)
	{
		foreach (var word in words) {
			Add(word);
		}
	}

	public void Add(string word)
	{
		var currentNode = root;
		for (int i = 0; i < word.Length; ++i) {
			if (!currentNode.Childrens.TryGetValue(word[i], out var nextNode)) {
				nextNode = new Node();
				currentNode.Childrens.Add(word[i], nextNode);
			}
			currentNode = nextNode;
		}
	}

	public bool ContainsSimilarWord(string word)
	{
		return Traverse(root, 0, 0);

		bool Traverse(Node node, int index, int edits)
		{
			if (index == word.Length) {
				return true;
			}
			if (node.Childrens.TryGetValue(word[index], out var nextNode) && Traverse(nextNode, index + 1, edits)) {
				return true;
			}
			if (edits < 2) {
				foreach ((char letter, var childNode) in node.Childrens) {
					if (letter == word[index]) {
						continue;
					}
					if (Traverse(childNode, index + 1, edits + 1)) {
						return true;
					}
				}
			}
			return false;
		}
	}

	public class Node
	{
		public Dictionary<char, Node> Childrens { get; private set; } = [];
	}
}
