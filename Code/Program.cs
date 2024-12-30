using Code.Base;

namespace Code
{
	internal class Program
	{
		static void Main( string[] args )
		{
			//LinkList.LinkList.ListNode node1 = new LinkList.LinkList.ListNode( 1 );
			//LinkList.LinkList.ListNode node2 = new LinkList.LinkList.ListNode( 2 );
			//LinkList.LinkList.ListNode node3 = new LinkList.LinkList.ListNode( 2 );
			//LinkList.LinkList.ListNode node4 = new LinkList.LinkList.ListNode( 1 );
			//node1.next = node2;
			//node2.next = node3;
			//node3.next = node4;
			//LinkList.LinkList.IsPalindrome( node1 );

			var finder = new MedianFinder();
			finder.AddNum( 1 );
			finder.AddNum( 2 );
			var result = finder.FindMedian();
			Console.WriteLine( result );
			finder.AddNum( 3 );
			result = finder.FindMedian();
			Console.WriteLine( result );
		}
	}
}
