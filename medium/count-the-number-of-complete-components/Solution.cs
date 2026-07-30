// https://leetcode.com/problems/count-the-number-of-complete-components
// #graph_theory #disjoint_set_union
public class Solution
{
	public int CountCompleteComponents(int n, int[][] edges)
	{
		var dsu = new Dsu(n);
		for (int i = 0; i < edges.Length; ++i) {
			dsu.Union(edges[i][0], edges[i][1]);
		}

		int completeComponentsNumber = 0;
		for (int i = 0; i < n; ++i) {
			if (!dsu.IsRoot(i)) {
				continue;
			}
			int componentSize = dsu.GetSizeOfSet(i);
			int completeComponentEdgesCount = componentSize * (componentSize - 1) / 2;
			if (dsu.GetConnectionsCountOfSet(i) == completeComponentEdgesCount) {
				++completeComponentsNumber;
			}
		}
		return completeComponentsNumber;
	}
}

public class Dsu
{
	private readonly int[] connectionsCount;
	private readonly int[] sizes;
	private readonly int[] parents;

	public Dsu(int size)
	{
		connectionsCount = new int[size];
		sizes = new int[size];
		parents = new int[size];
		for (int i = 0; i < size; ++i) {
			sizes[i] = 1;
			parents[i] = i;
		}
	}

	public int FindParent(int set) => IsRoot(set) ? set : parents[set] = FindParent(parents[set]);

	public int GetConnectionsCountOfSet(int set) => connectionsCount[set];

	public int GetSizeOfSet(int set) => sizes[set];

	public bool IsRoot(int set) => parents[set] == set;

	public void Union(int first, int second)
	{
		int firstParent = FindParent(first);
		int secondParent = FindParent(second);
		if (firstParent != secondParent) {
			if (sizes[firstParent] < sizes[secondParent]) {
				(firstParent, secondParent) = (secondParent, firstParent);
			}
			parents[secondParent] = firstParent;
			sizes[firstParent] += sizes[secondParent];
			connectionsCount[firstParent] += connectionsCount[secondParent];
		}
		++connectionsCount[firstParent];
	}
}
