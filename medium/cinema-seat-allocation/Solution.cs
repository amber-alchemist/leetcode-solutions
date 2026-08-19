// https://leetcode.com/problems/cinema-seat-allocation
// #biwise_operations #hash_table
public class Solution
{
	public int MaxNumberOfFamilies(int n, int[][] reservedSeats)
	{
		const int FreeRow = 1023;
		const int LeftBlock = 480;
		const int CentreBlock = 120;
		const int RightBlock = 30;

		var map = new Dictionary<int, int>();
		for (int i = 0; i < reservedSeats.Length; ++i) {
			int rowNumber = reservedSeats[i][0];
			int seatNumber = reservedSeats[i][1] - 1;
			if (!map.TryGetValue(rowNumber, out int rowValue)) {
				rowValue = FreeRow;
			}
			map[rowNumber] = rowValue & ~(1 << seatNumber);
		}

		int maxNumberOfFamilies = n << 1;
		foreach (int rowValue in map.Values) {
			bool isLeftBlockFree = (rowValue & LeftBlock) == LeftBlock;
			bool isRightBlockFree = (rowValue & RightBlock) == RightBlock;
			if (isLeftBlockFree && isRightBlockFree) {
				continue;
			}
			if (isLeftBlockFree || isRightBlockFree) {
				maxNumberOfFamilies -= 1;
			}
			else {
				bool isCentreBlockFree = (rowValue & CentreBlock) == CentreBlock;
				if (isCentreBlockFree) {
					maxNumberOfFamilies -= 1;
				}
				else {
					maxNumberOfFamilies -= 2;
				}
			}
		}
		return maxNumberOfFamilies;
	}
}
