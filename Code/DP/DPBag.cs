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

		public static int CoinChange( int[] coins, int amount )
		{
			int max = amount + 1;
			if( coins.Length == 0 ) return -1;
			if( amount == 0 ) return 0;
			var dp = new int[amount + 1];
			dp[0] = 0;

			for (int i = 1; i <= amount; i++ )
			{
				dp[i] = max;
			}

			for( int i = 1; i <= amount; i++ )
			{
				for( var j = 0; j < coins.Length; j++ )
				{
					if ( coins[j] <= i )
					{
						dp[i] = Math.Min( dp[i - coins[j]] + 1, dp[i] );
					}
				}
			}

			return dp[^1] > amount ? -1 : dp[^1];
		}

		public static bool WordBreak( string s, IList<string> wordDict )
		{
			if( s == null ) return false;
			if( wordDict.Count == 0 ) return false;

			var dp = new bool[s.Length + 1];
			dp[0] = true;
			for( int i = 0; i < s.Length + 1; i++ )
			{
				for ( int j = 0; j < wordDict.Count; j++ )
				{
					var word = wordDict[j];
					if ( i < word.Length )
					{
						continue;
					}
					dp[i] = dp[i] || ( dp[i - word.Length] && string.Equals( s[( i - word.Length )..i], word ) );
				}
			}

			return dp[^1];
		}

		//TODO: 还有一种贪心解法
		public static int LengthOfLIS( int[] nums )
		{
			if( nums.Length == 0 ) return 0;
			if( nums.Length == 1 ) return 1;

			var dp = new int[nums.Length + 1];
			dp[0] = 0;
			var result = 0;

			for( int i = 1; i <= nums.Length; i++ )
			{
				dp[i] = 1;
				for( int j = 1; j < i; j ++)
				{
					if ( nums[i - 1] > nums[j - 1] )
					{
						dp[i] = Math.Max( dp[i], dp[j] + 1 );
					}
				}
				result = Math.Max( result, dp[i] );
			}

			return result;
		}

		public static int MaxProduct( int[] nums )
		{
			if( nums.Length == 0 ) return 0;

			var dp = new int[nums.Length + 1];
			dp[0] = 0;
			int max = int.MinValue;
			for( int i = 1; i <= nums.Length; i++ )
			{
				var last = dp[i - 1];
				if( last == 0 )
				{
					dp[i] = nums[i - 1];
				}
				else
				{
					var predect = dp[i - 1] * nums[i - 1];
					dp[i] = predect > last ? predect : 0;
				}
				max = Math.Max( max, dp[i] );
			}
			return max;
		}

		public static int MaxSubArray( int[] nums )
		{
			if( nums.Length == 0 ) return 0;

			int max = int.MinValue;
			var dp = new int[nums.Length];
			dp[0] = nums[0];
			max = Math.Max( max, dp[0] );
			for( int i = 1; i < nums.Length; i++ )
			{
				dp[i] = Math.Max( dp[i - 1] + nums[i], nums[i] );
				max = Math.Max( max, dp[i] );
			}
			return max;
		}
	}
}
