using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Base
{
	public class RemoveElement
	{
		public static int RemoveValue( int[] nums, int val )
		{
			int count = nums.Length;
			for ( int i = 0; i < count; i++ )
			{
				if( nums[i] == val )
				{
					nums[i] = nums[count - 1];
					count--;
					i--;	//recheck
				}
			}

			return count;
		}

		public static int RemoveDuplicates( int[] nums )
		{
			HashSet<int> cache = [];
			var head = 0;
			for( int i = 0; i <= nums.Length - 1; i++ )
			{
				var cur = nums[i];
				if ( cache.Contains( cur ) == false )
				{
					nums[head] = cur;
					head++;
					cache.Add( cur );
				}
			}

			return cache.Count;
		}
	}
}
