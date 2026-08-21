// https://leetcode.com/problems/course-schedule
// #directed_graph #cycle_detection #dfs
public class Solution
{
	public enum VertexState
	{
		NotVisited,
		Processing,
		Processed,
	}

	public bool CanFinish(int numCourses, int[][] prerequisites)
	{
		if (prerequisites.Length <= 1) {
			return true;
		}

		var adjacencyLists = new List<int>[numCourses];
		for (int i = 0; i < prerequisites.Length; ++i) {
			int from = prerequisites[i][0], to = prerequisites[i][1];
			(adjacencyLists[from] ??= new List<int>()).Add(to);
		}

		var statesOfVertices = new VertexState[numCourses];
		for (int i = 0; i < numCourses; ++i) {
			if (statesOfVertices[i] == VertexState.NotVisited) {
				if (adjacencyLists[i] == null) {
					statesOfVertices[i] = VertexState.Processed;
				} else if (!IsAcyclicSubtree(i)) {
					return false;
				}
			}
		}
		return true;

		bool IsAcyclicSubtree(int vertex)
		{
			if (adjacencyLists[vertex] != null) {
				statesOfVertices[vertex] = VertexState.Processing;
				for (int i = 0; i < adjacencyLists[vertex].Count; ++i) {
					int neighbor = adjacencyLists[vertex][i];
					if (
						statesOfVertices[neighbor] == VertexState.Processing ||
						statesOfVertices[neighbor] == VertexState.NotVisited && !IsAcyclicSubtree(neighbor)
					) {
						return false;
					}
				}
			}
			statesOfVertices[vertex] = VertexState.Processed;
			return true;
		}
	}
}
