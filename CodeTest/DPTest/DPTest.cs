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
	}
}