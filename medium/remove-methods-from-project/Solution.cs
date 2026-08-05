// https://leetcode.com/problems/remove-methods-from-project
// #graph_theory #bfs
public class Solution
{
	public IList<int> RemainingMethods(int n, int k, int[][] invocations)
	{
		var adjacencyList = new List<int>[n];
		for (int i = 0; i < invocations.Length; ++i) {
			int u = invocations[i][0];
			int v = invocations[i][1];
			(adjacencyList[u] ??= []).Add(v);
		}

		var isMarked = new bool[n];
		isMarked[k] = true;
		int marksCount = 1;

		int queueBackIndex = 0;
		var queue = new int[n];
		queue[queueBackIndex++] = k;
		while (queueBackIndex > 0) {
			int u = queue[--queueBackIndex];
			if (adjacencyList[u] is null) {
				continue;
			}
			for (int i = 0; i < adjacencyList[u].Count; ++i) {
				int v = adjacencyList[u][i];
				if (!isMarked[v]) {
					isMarked[v] = true;
					++marksCount;
					queue[queueBackIndex++] = v;
				}
			}
		}

		if (marksCount == n) {
			return Array.Empty<int>();
		}

		bool isPossibleToRemoveAllMarked = true;
		for (int i = 0; i < invocations.Length; ++i) {
			int u = invocations[i][0];
			int v = invocations[i][1];
			if (!isMarked[u] && isMarked[v]) {
				isPossibleToRemoveAllMarked = false;
				break;
			}
		}

		int[] remainingMethods;
		if (!isPossibleToRemoveAllMarked) {
			remainingMethods = new int[n];
			for (int u = 0; u < n; ++u) {
				remainingMethods[u] = u;
			}
		} else {
			remainingMethods = new int[n - marksCount];
			for (int u = 0, i = 0; u < n; ++u) {
				if (!isMarked[u]) {
					remainingMethods[i++] = u;
				}
			}
		}
		return remainingMethods;
	}
}
