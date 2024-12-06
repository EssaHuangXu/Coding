using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Base
{
	public class MergeArray
	{
		/*
			4	5	6	0	0	0	---	1	2	3			3	3
			4	5	0	0	0	6	---	1	2	3			2	3
		*/
		public static int[] Merge( int[] nums1, int m, int[] nums2, int n )
		{
			if( n == 0 ) return nums1;

			for( int i = m + n - 1; i >= 0; i-- )
			{
				if( m > 0 && n > 0 )
				{
					//select insert
					var left = nums1[m - 1];
					var right = nums2[n - 1];

					if( left >= right )
					{
						nums1[i] = left;
						m--;
					}
					else
					{
						nums1[i] = right;
						n--;
					}
				}
				else if( m > 0 && n <= 0 )
				{
					nums1[i] = nums1[m - 1];
					m--;
				}
				else if( m <= 0 && n > 0 )
				{
					nums1[i] = nums2[n - 1];
					n--;
				}
			}

			return nums1;
		}
	}
}
