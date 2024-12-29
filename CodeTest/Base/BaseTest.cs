using Code.Base;

namespace CodeTest.Base
{
    public class BaseTest
    {
        [Fact]
        public void Test_MergeArray()
        {
            Assert.Equal( [1, 2, 2, 3, 5, 6], MergeArray.Merge( [1, 2, 3, 0, 0, 0], 3, [2, 5, 6], 3 ) );
        }

        [Fact]
        public void Test_RemoveElementReturnCount()
        {
            Assert.Equal( 5, RemoveElement.RemoveValue( [0, 1, 2, 2, 3, 0, 4, 2], 2 ) );
			Assert.Equal( 0, RemoveElement.RemoveValue( [1], 1 ) );
		}


		[Fact]
		public void Test_RemoveDuplicates()
		{
            Assert.Equal( 2, RemoveElement.RemoveDuplicates( [1, 1, 2] ) );
		}

        [Fact]
        public void Test_MaxSlidingWindow()
        {
            Assert.Equal( [3, 3, 5, 5, 6, 7], SlideWindow.MaxSlidingWindow( [1, 3, -1, -3, 5, 3, 6, 7], 3 ) );
			Assert.Equal( [1, -1], SlideWindow.MaxSlidingWindow( [1, -1], 1 ) );
		}

        [Fact]
        public void Test_SortColors()
        {
            Assert.Equal( [0, 0, 1, 1, 1, 2], Sort.SortColors( [2, 1, 0, 1, 0, 1] ) );
			Assert.Equal( [0, 1, 2], Sort.SortColors( [1, 2, 0] ) );
            Assert.Equal( [0, 0, 1, 1, 2, 2], Sort.SortColors( [2, 0, 2, 1, 1, 0] ) );
        }
	}
}