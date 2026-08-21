// https://leetcode.com/problems/furthest-point-from-origin
// #string
public class Solution
{
	public int FurthestDistanceFromOrigin(string moves)
	{
		int stepsOnLeft = 0, stepsOnRight = 0, whitespaces = 0;
		for (int i = 0; i < moves.Length; ++i) {
			if (moves[i] == 'L') {
				++stepsOnLeft;
			} else if (moves[i] == 'R') {
				++stepsOnRight;
			} else {
				++whitespaces;
			}
		}
		return Math.Abs(stepsOnLeft - stepsOnRight) + whitespaces;
	}
}
