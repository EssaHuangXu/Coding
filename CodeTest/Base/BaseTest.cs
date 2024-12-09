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
	}
}