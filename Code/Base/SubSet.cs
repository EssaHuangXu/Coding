using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Base
{
	public class SubSet
	{
		public static IList<IList<int>> Subsets( int[] nums )
		{
			var result = new List<IList<int>>();
			var count = nums.Length;
			for ( int i = 0; i < (int)( 1 << count ); i ++ )
			{
				List<int> list = new List<int>();
				for( int j = 0; j < count; j++ )
				{
					if( ( i >> j & 1 ) == 1 )
					{
						list.Add( nums[j] );
					}
				}
				result.Add( list );
			}
			return result;
		}
	}
}
