// https://leetcode.com/problems/valid-sudoku
// #matrix
public class Solution
{
	public bool IsValidSudoku(char[][] board)
	{
		const int SudokuSize = 9;

		var isDigitSeen = new bool[SudokuSize];
		for (int i = 0; i < SudokuSize; ++i) {
			Array.Clear(isDigitSeen);
			for (int j = 0; j < SudokuSize; ++j) {
				if (!IsValidCell(i, j)) {
					return false;
				}
			}
		}

		for (int j = 0; j < SudokuSize; ++j) {
			Array.Clear(isDigitSeen);
			for (int i = 0; i < SudokuSize; ++i) {
				if (!IsValidCell(i, j)) {
					return false;
				}
			}
		}

		const int SquareSize = 3;
		for (int i = 0; i < SudokuSize; i += 3) {
			for (int j = 0; j < SudokuSize; j += 3) {
				Array.Clear(isDigitSeen);
				for (int k = 0; k < SquareSize; ++k) {
					for (int m = 0; m < SquareSize; ++m) {
						if (!IsValidCell(i + k, j + m)) {
							return false;
						}
					}
				}
			}
		}
		return true;

		bool IsValidCell(int x, int y)
		{
			if (board[x][y] == '.') {
				return true;
			}
			int index = board[x][y] - '1';
			if (isDigitSeen[index]) {
				return false;
			}
			isDigitSeen[index] = true;
			return true;
		}
	}
}
