namespace Code.Base
{
	public class Sort
	{
		public static int[] SortColors( int[] nums )
		{
			int first = 0;
			int last = nums.Length - 1;
			int index = 0;
			while ( index <= last )
			{
				if( nums[index] == 0 )
				{
					var temp = nums[index];
					nums[index] = nums[first];
					nums[first] = temp;
					first++;
				}
				else if( nums[index] == 2 )
				{
					var temp = nums[index];
					nums[index] = nums[last];
					nums[last] = temp;
					last--;
					index--;
				}

				index++;
			}

			return nums;
		}
	}
}
