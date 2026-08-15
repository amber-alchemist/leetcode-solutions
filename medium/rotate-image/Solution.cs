// https://leetcode.com/problems/rotate-image
// #array
public class Solution
{
	public void Rotate(int[][] matrix)
	{
		int size = matrix.Length;
		int halfSize = size / 2;
		for (int i = 0; i < halfSize; ++i) {
			int frameSize = size - i - i;
			int minIndex = i;
			int maxIndex = size - 1 - i;
			for (int step = 0; step < frameSize - 1; ++step) {
				int topRight = matrix[minIndex + step][maxIndex];
				matrix[minIndex + step][maxIndex] = matrix[minIndex][minIndex + step];

				int bottomRight = matrix[maxIndex][maxIndex - step];
				matrix[maxIndex][maxIndex - step] = topRight;

				int bottomLeft = matrix[maxIndex - step][minIndex];
				matrix[maxIndex - step][minIndex] = bottomRight;

				matrix[minIndex][minIndex + step] = bottomLeft;
			}
		}
	}
}
