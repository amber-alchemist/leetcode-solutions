// https://leetcode.com/problems/check-if-there-is-a-valid-path-in-a-grid
// #backtracking
public class Solution
{
	private enum Direction
	{
		Up,
		Right,
		Down,
		Left,
	}

	public bool HasValidPath(int[][] grid)
	{
		int n = grid.Length;
		int m = grid[0].Length;

		if (n == 1 && m == 1) {
			return true;
		}

		bool hasLoop = false;
		switch (grid[0][0]) {
			case 1:
				return Traverse(1, 0, Direction.Right);
			case 2:
				return Traverse(0, 1, Direction.Down);
			case 3:
				return Traverse(0, 1, Direction.Down);
			case 4:
				return Traverse(1, 0, Direction.Right) || (!hasLoop && Traverse(0, 1, Direction.Down));
			case 5:
				return false;
			case 6:
				return Traverse(1, 0, Direction.Right);
		}
		throw new InvalidOperationException();

		bool Traverse(int x, int y, Direction direction)
		{
			if (x < 0 || x >= m || y < 0 || y >= n) {
				return false;
			}
			if (x == m - 1 && y == n - 1) {
				return true;
			}
			if (x == 0 && y == 0) {
				hasLoop = true;
				return false;
			}
			var nextDirection = GetNextDirection(direction, grid[y][x]);
			Move(nextDirection, ref x, ref y);
			if (x < 0 || x >= m || y < 0 || y >= n) {
				return false;
			}
			return CanEnterStreet(nextDirection, grid[y][x]) && Traverse(x, y, nextDirection);
		}
	}

	private static void Move(Direction currentDirection, ref int x, ref int y)
	{
		switch (currentDirection) {
			case Direction.Up:
				--y;
				break;
			case Direction.Right:
				++x;
				break;
			case Direction.Down:
				++y;
				break;
			case Direction.Left:
				--x;
				break;
		}
	}

	private static Direction GetNextDirection(Direction currentDirection, int streetType)
	{
		switch (streetType) {
			case 1:
			case 2:
				return currentDirection;
			case 3:
				return currentDirection == Direction.Up ? Direction.Left : Direction.Down;
			case 4:
				return currentDirection == Direction.Up ? Direction.Right : Direction.Down;
			case 5:
				return currentDirection == Direction.Down ? Direction.Left : Direction.Up;
			case 6:
				return currentDirection == Direction.Down ? Direction.Right : Direction.Up;
		}
		throw new InvalidOperationException();
	}

	private static bool CanEnterStreet(Direction direction, int streetType)
	{
		switch (direction) {
			case Direction.Up:
				return streetType == 2 || streetType == 3 || streetType == 4;
			case Direction.Right:
				return streetType == 1 || streetType == 3 || streetType == 5;
			case Direction.Down:
				return streetType == 2 || streetType == 5 || streetType == 6;
			case Direction.Left:
				return streetType == 1 || streetType == 4 || streetType == 6;
		}
		throw new InvalidOperationException();
	}
}
