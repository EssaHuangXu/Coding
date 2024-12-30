using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Base
{
	public class MedianFinder
	{
		public PriorityQueue<int, int> minQueue;
		public PriorityQueue<int, int> maxQueue;

		public MedianFinder()
		{
			minQueue = new PriorityQueue<int, int>();
			maxQueue = new PriorityQueue<int, int>();
		}

		public void AddNum( int num )
		{
			//中位数左边的队列始终比中卫数右侧的队列多0 - 1个
			if ( minQueue.Count == 0 || num < minQueue.Peek() )
			{
				minQueue.Enqueue( num, -num );
				if ( minQueue.Count - maxQueue.Count >= 2 )
				{
					var del = minQueue.Dequeue();
					maxQueue.Enqueue( del, del );
				}
			}
			else
			{
				maxQueue.Enqueue( num, num );
				if (maxQueue.Count > minQueue.Count )
				{
					var del = maxQueue.Dequeue();
					minQueue.Enqueue( del, -del );
				}
			}
		}

		public double FindMedian()
		{
			if( minQueue.Count > maxQueue.Count )
			{
				return minQueue.Peek();
			}
			else
			{
				return ( minQueue.Peek() + maxQueue.Peek() ) / 2.0d;
			}
		}
	}
}
