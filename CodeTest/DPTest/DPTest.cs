using Code.DP;

namespace CodeTest.DPTest
{
	public class DPTest
	{
		[Theory]
		[InlineData( 2, 3, 3 )]
		[InlineData( 3, 7, 28 )]
		public void Test_UniquePaths( int m, int n, int result )
		{
			Assert.Equal( LeetcodeUniquePaths.UniquePaths( m, n ), result );
		}

		[Fact]
		public void Test_MainPathSum()
		{
			Assert.Equal( 7, LeetcodeMinPathSum.MinPathSum(
			[
				[1, 3, 1],
				[1, 5, 1],
				[4, 2, 1],
			] ) );

			Assert.Equal( 0, LeetcodeMinPathSum.MinPathSum( [[0]] ) );
		}


		[Fact]
		public void Test_DP_ZeroOneBag()
		{
			Assert.Equal( 55, DPBag.ZeroOneBag( [2, 3, 5], [15, 30, 40], 7 ) );
			Assert.Equal( 55, DPBag.ZeroOneBag2( [2, 3, 5], [15, 30, 40], 7 ) );
			Assert.Equal( 3, DPBag.NumSquares( 12 ) );
		}

		[Fact]
		public void Test_DP_Rob1()
		{
			Assert.Equal( 4, DPRob.Rob( [1, 2, 3, 1] ) );
		}

		[Fact]
		public void Test_DP_CoinChange()
		{
			Assert.Equal( 3, DPBag.CoinChange( [1, 2, 5], 11 ) );
			Assert.Equal( -1, DPBag.CoinChange( [2], 3 ) );
			Assert.Equal( 0, DPBag.CoinChange( [1], 0 ) );
			Assert.Equal( 20, DPBag.CoinChange( [186, 419, 83, 408], 6249 ) );
		}

		[Fact]
		public void Test_DP_WordBreak()
		{
			Assert.True( DPBag.WordBreak( "Word", new List<string> { "Wo", "rd" } ) );
		}

		[Fact]
		public void Test_DP_LengthOfLIS()
		{
			Assert.Equal( 4, DPBag.LengthOfLIS( [10, 9, 2, 5, 3, 7, 101, 18] ) );
			Assert.Equal( 4, DPBag.LengthOfLIS( [0, 1, 0, 3, 2, 3] ) );
		}

		[Fact]
		public void Test_Dp_MaxProduct()
		{
			Assert.Equal( 6, DPBag.MaxProduct( [2, 3, -2, 4] ) );
		}

		[Fact]
		public void Test_Dp_MaxSubArray()
		{
			Assert.Equal( 5, DPBag.MaxSubArray( [-2, 1, -3, 4, -1, 2, 1, -5, 4] ) );
		}
	}
}