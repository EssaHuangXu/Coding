namespace Code.DP
{
	public class DPBag
	{
		public static int ZeroOneBag( int[] weights, int[] values, int capacity )
		{
			if( values.Length == 0 ) return 0;
			if( capacity == 0 ) return 0;

			var dp = new int[values.Length + 1, capacity + 1];

			for( int i = 1; i <= values.Length; i++ )
			{
				var curWeight = weights[i - 1];
				for( int j = 1; j <= capacity; j++ )
				{
					if( curWeight > j )
					{
						dp[i, j] = dp[i - 1, j];
					}
					else
					{
						dp[i, j] = Math.Max( dp[i - 1, j], dp[i - 1, j - curWeight] + values[i - 1] );
					}
				}
			}

			return dp[values.Length, capacity];
		}

		public static int ZeroOneBag2( int[] weights, int[] values, int capacity )
		{
			if( values.Length == 0 ) return 0;
			if( capacity == 0 ) return 0;

			var dp = new int[capacity + 1];

			for( int i = 1; i <= values.Length; i++ )
			{
				var curWeight = weights[i - 1];
				for( int j = capacity; j >= 1; j-- )
				{
					if( curWeight <= j )
					{
						dp[j] = Math.Max( dp[j], dp[j - curWeight] + values[i - 1] );
					}
				}
			}

			return dp[capacity];
		}

		public static int ClimbStairs( int n )
		{
			if ( n == 0 ) return 0;
			if ( n == 1 ) return 1;

			var dp = new int[n + 1];
			dp[0] = 1;
			dp[1] = 1;

			for ( int i = 2; i <= n; i++ )
			{
				dp[i] = dp[i - 1] + dp[i - 2];
			}

			return dp[^1];
		}

		public static int NumSquares( int n )
		{
			var dp = new int[n + 1];
			for ( int i = 1; i <= n; i++ )
			{
				dp[i] = i;
			}

			var j = 2;
			var sqr = j * j;
			while( sqr <= n )
			{
				for( int i = n; i >= 1; i-- )
				{
					var k = i / sqr;
					dp[i] = Math.Min( dp[i], k + dp[i - k * sqr] );
				}
				j++;
				sqr = j * j;
			}
			return dp[^1];
		}
	}
}
