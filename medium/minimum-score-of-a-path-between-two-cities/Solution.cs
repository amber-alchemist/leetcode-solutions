// https://leetcode.com/problems/minimum-score-of-a-path-between-two-cities
// #grapth_theory #disjoint_set_union
public class Solution
{
	public int MinScore(int n, int[][] roads)
	{
		var dsu = new Dsu(n);
		for (int i = 0; i < roads.Length; ++i) {
			dsu.Union(roads[i][0] - 1, roads[i][1] - 1);
		}

		int minScore = int.MaxValue;
		int root = dsu.FindParent(0);
		for (int i = 0; i < roads.Length; ++i) {
			if (dsu.FindParent(roads[i][0]) == root) {
				minScore = Math.Min(minScore, roads[i][2]);
			}
		}
		return minScore;
	}
}

public class Dsu
{
	private readonly int[] sizes;
	private readonly int[] parents;

	public Dsu(int size)
	{
		sizes = new int[size];
		parents = new int[size];
		for (int i = 0; i < size; ++i) {
			sizes[i] = 1;
			parents[i] = i;
		}
	}

	public int FindParent(int set)
	{
		if (set == parents[set]) {
			return set;
		}
		return parents[set] = FindParent(parents[set]);
	}

	public void Union(int first, int second)
	{
		int firstParent = FindParent(first);
		int secondParent = FindParent(second);
		if (sizes[firstParent] < sizes[secondParent]) {
			(firstParent, secondParent) = (secondParent, firstParent);
		}
		parents[secondParent] = firstParent;
		sizes[firstParent] += sizes[secondParent];
	}
}
