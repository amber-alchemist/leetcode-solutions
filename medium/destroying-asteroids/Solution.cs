// https://leetcode.com/problems/destroying-asteroids
// #greedy_algorithm #sorting
public class Solution
{
	public bool AsteroidsDestroyed(int mass, int[] asteroids)
	{
		long currentMass = mass;
		Array.Sort(asteroids);
		for (int i = 0; i < asteroids.Length; ++i) {
			if (currentMass < asteroids[i]) {
				return false;
			}
			currentMass += asteroids[i];
		}
		return true;
	}
}
