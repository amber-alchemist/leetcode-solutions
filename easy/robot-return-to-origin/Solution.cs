// https://leetcode.com/problems/robot-return-to-origin
// #simulation
public class Solution
{
	public bool JudgeCircle(string moves)
	{
		(int x, int y) pos = (0, 0);
		foreach (var move in moves) {
			switch (move) {
				case 'U':
					++pos.y;
					break;
				case 'R':
					++pos.x;
					break;
				case 'D':
					--pos.y;
					break;
				case 'L':
					--pos.x;
					break;
			}
		}
		return pos.x == 0 && pos.y == 0;
	}
}
