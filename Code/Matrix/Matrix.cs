using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Matrix
{
	public class Matrix
	{
		public static void SetZeros( ref int[][] matrix )
		{
			if (matrix.Length == 0) return;
			if( matrix[0].Length == 0 ) return;

			var rowLength = matrix.Length;
			var colLength = matrix[0].Length;

			bool[] rowHasZero = new bool[matrix.Length];
			for ( int i = 0; i < rowLength; i++ )
			{
				for ( int j = 0; j < colLength; j++ )
				{
					if ( matrix[i][j] == 0 )
					{
						rowHasZero[i] = true;
						break;
					}
				}
			}

			bool[] colHasZero = new bool[colLength];
			for( int j = 0; j < colLength; j++ )
			{
				for( int i = 0; i < rowLength; i++ )
				{
					if ( matrix[i][j] == 0 )
					{
						colHasZero[j] = true;
						break;
					}
				}
			}

			for( int i = 0; i < rowLength; i++ )
			{
				for( int j = 0; j < colLength; j++ )
				{
					if( rowHasZero[i] || colHasZero[j] )
					{
						matrix[i][j] = 0;
					}
				}
			}
		}
		public static IList<int> SpiralOrder( int[][] matrix )
		{
			var result = new List<int>();
			if ( matrix.Length == 0 ) return result;
			if ( matrix[0].Length == 0 ) return result;
			var count = matrix.Length * matrix[0].Length;

			var state = 0;
			while(result.Count < count )
			{
				switch( state )
				{
					//left to right
					case 0:
						break;
					//up to down
					case 1:
						break;
					//right to left
					case 2:
						break;
					//down to up
					case 3:
						break;
				}
			}

			return result;
		}

		public static void Rotate( ref int[][] matrix )
		{
			// origin | flip | -1
			// 1 2 | 2 1 | 2 1 
			// 3 4 | 4 3 | 4 3

			var length = matrix.Length;
			for ( int i = 0; i < matrix.Length / 2; i++ )
			{
				for( int j = 0 ; j < length ; j++ )
				{
					////swap left right
					//matrix[i][j] = matrix[i][j] + matrix[i][length - j - 1];
					//matrix[i][length - j - 1] = matrix[i][j] - matrix[i][length - j - 1];
					//matrix[i][j] = matrix[i][j] - matrix[i][length - j - 1];

					//swap up down
					matrix[i][j] = matrix[i][j] + matrix[length - i - 1][j];
					matrix[length - i - 1][j] = matrix[i][j] - matrix[length - i - 1][j];
					matrix[i][j] = matrix[i][j] - matrix[length - i - 1][j];
				}
			}

			for( int i = 0; i < matrix.Length; i++ )
			{
				for( int j = 0; j < i; j++ )
				{
					matrix[i][j] = matrix[i][j] + matrix[j][i];
					matrix[j][i] = matrix[i][j] - matrix[j][i];
					matrix[i][j] = matrix[i][j] - matrix[j][i];
				}
			}
		}


		// m x m matrix
		public static bool SearchMatrix( int[][] matrix, int target )
		{
			var length = matrix.Length;
			var searchIndex = 0;

			for( ; searchIndex < length; searchIndex++ )
			{
				var center = matrix[searchIndex][searchIndex];
				if( center == target )
				{
					return true;
				}
				else if( center > target )
				{
					break;
				}
			}

			if (searchIndex == length)
			{
				return false;
			}

			for ( int i = 0; i < searchIndex; i++)
			{
				if( matrix[i][searchIndex] == target || matrix[searchIndex][i] == target )
				{
					return true;
				}
			}

			return false;
		}

		public static bool SearchMatrix2( int[][] matrix, int target )
		{
			var row = matrix.Length;
			if( row == 0 ) return false;
			var col = matrix[0].Length;

			var searchRow = row - 1;
			var searchCol = col - 1;

			for( int i = row - 1; i >= 0; i-- )
			{
				for( int j = col - 1; j >= 0; j-- )
				{
					if( matrix[i][j] == target ) return true;

					if( matrix[i][j] > target )
					{
						continue;
					}

					if ( matrix[i][j] < target )
					{
						searchCol = j;
						searchRow = i;
					}
				}
			}

			for( int i = 0; i < searchRow; i++ )
			{
				if( matrix[i][searchRow] == target ) return true;
			}

			for( int i = 0; i < searchCol; i++ )
			{
				if( matrix[searchRow][i] == target ) return true;
			}
			return false;
		}
	}
}
