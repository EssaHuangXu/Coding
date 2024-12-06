namespace Code.DP
{
	public class LeetcodeUniquePaths
	{
		public static int UniquePaths( int m, int n )
		{
			//dp[i, j] = dp[i - 1, j] + dp[i, j -1]
			//dp[i, j] default 1

			/* m = 3 n = 7, result = 28
			1	1	1	1	1	1	1
			1	2	3	4	5	6	7
            1	3	6	10	15	21	28
			*/
			//var dp = Enumerable.Repeat(1, m).ToArray();
			var dp = new int[m];
			for( int i  = 0; i < m; i ++ )
			{
				dp[i] = 1;
			}

			for( int i = 1; i < n; i++ )
			{
				for( int j = 1; j < dp.Length; j ++)
				{
					dp[j] += dp[j - 1];
				}
			}

			return dp[m - 1];
		}
	}
}
