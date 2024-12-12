﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DP
{
	public class DPRob
	{
		public static int Rob( int[] nums )
		{
			if (nums.Length == 0) return 0;
			if (nums.Length == 1) return nums[0];

			var dp = new int[nums.Length];
			dp[0] = nums[0];
			dp[1] = Math.Max( nums[0], nums[1] );
			for( int i = 2; i < nums.Length; i++ )
			{
				dp[i] = Math.Max( dp[i - 1], dp[i - 2] + nums[i] ); 
			}

			return dp[^1];
		}
	}
}
