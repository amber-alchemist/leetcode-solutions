// https://leetcode.com/problems/maximum-amount-of-money-robot-can-earn
// #dynamic_programming
public class Solution
{
    public int MaximumAmount(int[][] coins)
    {
        int rowsCount = coins.Length;
        int columnsCount = coins[0].Length;

        int[,,] dp = new int[rowsCount, columnsCount, 3];

        dp[0, 0, 0] = coins[0][0];
        dp[0, 0, 1] = Math.Max(0, coins[0][0]);
        dp[0, 0, 2] = Math.Max(0, coins[0][0]);

        for (int i = 1; i < rowsCount; ++i) {
            dp[i, 0, 0] = dp[i - 1, 0, 0] + coins[i][0];
            dp[i, 0, 1] = Math.Max(dp[i - 1, 0, 0], dp[i - 1, 0, 1] + coins[i][0]);
            dp[i, 0, 2] = Math.Max(dp[i - 1, 0, 1], dp[i - 1, 0, 2] + coins[i][0]);
        }

        for (int j = 1; j < columnsCount; ++j) {
            dp[0, j, 0] = dp[0, j - 1, 0] + coins[0][j];
            dp[0, j, 1] = Math.Max(dp[0, j - 1, 0], dp[0, j - 1, 1] + coins[0][j]);
            dp[0, j, 2] = Math.Max(dp[0, j - 1, 1], dp[0, j - 1, 2] + coins[0][j]);
        }

        for (int i = 1; i < rowsCount; ++i) {
            for (int j = 1; j < columnsCount; ++j) {
                int mx = Math.Max(dp[i - 1, j, 1], dp[i, j - 1, 1]);

                dp[i, j, 0] = Math.Max(dp[i - 1, j, 0], dp[i, j - 1, 0]) + coins[i][j];
                dp[i, j, 1] = Math.Max(Math.Max(dp[i - 1, j, 0], dp[i, j - 1, 0]), mx + coins[i][j]);
                dp[i, j, 2] = Math.Max(mx, Math.Max(dp[i - 1, j, 2], dp[i, j - 1, 2]) + coins[i][j]);
            }
        }

        return dp[rowsCount - 1, columnsCount - 1, 2];
    }
}
