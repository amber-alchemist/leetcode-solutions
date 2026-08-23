// https://leetcode.com/problems/walking-robot-simulation-ii
// #simulation
public class Robot(int width, int height)
{
	private enum Direction
	{
		North,
		East,
		South,
		West,
	}

	private readonly int width = width;
	private readonly int height = height;
	private readonly int cellsCount = (width + height - 2) * 2;
	private readonly int[] posArray = [0, 0];

	private Direction direction = Direction.East;
	private int x, y;
	private int currentCell;

	public void Step(int steps)
	{
		currentCell = (currentCell + (steps % cellsCount)) % cellsCount;
		if (currentCell == 0) {
			direction = Direction.South;
			x = 0;
			y = 0;
		}
		else if (currentCell < width) {
			direction = Direction.East;
			x = currentCell;
			y = 0;
		}
		else if (currentCell < width + height - 1) {
			direction = Direction.North;
			x = width - 1;
			y = currentCell - width + 1;
		}
		else if (currentCell < width + height + width - 2) {
			direction = Direction.West;
			x = cellsCount - height + 1 - currentCell;
			y = height - 1;
		}
		else {
			direction = Direction.South;
			x = 0;
			y = cellsCount - currentCell;
		}
	}

	public int[] GetPos()
	{
		posArray[0] = x;
		posArray[1] = y;
		return posArray;
	}

	public string GetDir() => direction.ToString();
}
