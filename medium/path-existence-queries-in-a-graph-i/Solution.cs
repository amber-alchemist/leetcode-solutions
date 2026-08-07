// https://leetcode.com/problems/path-existence-queries-in-a-graph-i
// #graph_theory #two_pointers
public class Solution
{
	public bool[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
	{
		var component = new int[n];
		for (int i = 0; i < n; ++i) {
			component[i] = i;
		}

		int left = 0;
		int right = 1;
		while (right < n) {
			int diff = nums[right] - nums[left];
			if (diff <= maxDiff) {
				component[right] = component[left];
				++right;
			} else {
				++left;
			}
			if (left == right) {
				++right;
			}
		}

		int q = queries.Length;
		var answers = new bool[q];
		for (int i = 0; i < q; ++i) {
			int u = queries[i][0];
			int v = queries[i][1];
			answers[i] = component[u] == component[v];
		}
		return answers;
	}
}
