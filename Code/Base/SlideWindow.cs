using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Base
{
	public class SlideWindow
	{
		public static int[] MaxSlidingWindow( int[] nums, int k )
		{
			var length = nums.Length;
			if( length < k ) return [];
			var result = new int[length];

			LinkedList<(int, int)> cache = new LinkedList<(int, int)>();
			for( int i = 0; i < length; i++)
			{
				while( cache.Count > 0 && i - k >= cache.First.Value.Item1 )
				{
					cache.RemoveFirst();
				}

				var num = nums[i];
				if ( cache.Count == 0 )
				{
					cache.AddLast( (i, num) );
				}
				else
				{
					while(cache.Count > 0 && cache.Last.Value.Item2 <= num)
					{
						cache.RemoveLast();
					}
					cache.AddLast( (i, num) );
				}
				result[i] = cache.Count > 0 ? cache.First.Value.Item2 : 0;
			}

			return result[( k - 1 )..length];
		}
	}
}
