namespace Code.DP
{
	public class LeetcodeMinPathSum
	{
		public static int MinPathSum( int[][] grid )
		{
			if (grid.Length == 0) { return 0; }
			if (grid[0].Length == 0) { return 0; }

			//dp[i, j] = Min(dp[i - 1, j], dp[i, j -1]) + grid[i, j]
			int[] dp = new int[grid[0].Length];
			int col = grid[0].Length;

			//init
			for (int i = 0; i < col; i++ )
			{
				dp[i] = ( i - 1 < 0 ? 0 : dp[i - 1] ) + grid[0][i];
			}


			for( int i = 1; i < grid.Length; i++ )
			{
				for( int j = 0; j < grid[i].Length; j++ )
				{
					dp[j] = j == 0 ? ( dp[j] + grid[i][j] ) : ( Math.Min( dp[j - 1], dp[j] ) + grid[i][j] ); 
				}
			}

			return dp[^1];
		}
	}
}
