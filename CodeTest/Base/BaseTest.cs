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
    }
}