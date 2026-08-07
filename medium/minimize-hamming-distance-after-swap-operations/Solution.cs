// https://leetcode.com/problems/minimize-hamming-distance-after-swap-operations
// #disjoint_set_union
public class Solution
{
	public int MinimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps)
	{
		var length = source.Length;
		var dsu = new Dsu(length);
		foreach (var swapPair in allowedSwaps) {
			dsu.UnionSets(swapPair[0], swapPair[1]);
		}

		var poolPerSet = new Dictionary<int, int>[length];
		for (int i = 0; i < length; ++i) {
			if (dsu.IsRoot(i)) {
				poolPerSet[i] = new();
			}
		}

		for (int i = 0; i < length; ++i) {
			int set = dsu.FindParent(i);
			var pool = poolPerSet[set];
			if (!pool.TryGetValue(source[i], out int count)) {
				count = 0;
			}
			pool[source[i]] = count + 1;
		}

		int hammingDistance = 0;
		for (int i = 0; i < length; ++i) {
			int set = dsu.FindParent(i);
			var pool = poolPerSet[set];
			if (pool.TryGetValue(target[i], out int count) && count > 0) {
				pool[target[i]] = count - 1;
			}
			else {
				++hammingDistance;
			}
		}
		return hammingDistance;
	}
}

public class Dsu
{
	private readonly int[] parents;
	private readonly int[] sizes;

	public int IndependentSetsCount { get; private set; }

	public Dsu(int size)
	{
		parents = new int[size];
		sizes = new int[size];
		for (int i = 0; i < size; ++i) {
			parents[i] = i;
			sizes[i] = 1;
		}
		IndependentSetsCount = size;
	}

	public int FindParent(int set)
	{
		while (parents[set] != set) {
			parents[set] = parents[parents[set]];
			set = parents[set];
		}
		return set;
	}

	public bool IsRoot(int set) => parents[set] == set;

	public void UnionSets(int a, int b)
	{
		int parentA = FindParent(a);
		int parentB = FindParent(b);
		if (parentA != parentB) {
			if (sizes[parentA] < sizes[parentB]) {
				(parentA, parentB) = (parentB, parentA);
			}
			parents[parentB] = parentA;
			sizes[parentA] += sizes[parentB];
			--IndependentSetsCount;
		}
	}
}
