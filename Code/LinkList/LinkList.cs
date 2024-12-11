namespace Code.LinkList
{
	public class LinkList
	{
		public class ListNode( int x )
		{
			public int val = x;
			public ListNode next = null;
		}


		public static ListNode GetIntersectionNode( ListNode headA, ListNode headB )
		{
			if( headA == null ) return null;
			if( headB == null ) return null;

			var p1 = headA;
			var p2 = headB;
			while( p1 != p2 ) 
			{
				p1 = p1 == null ? headB : p1.next;
				p2 = p2 == null ? headA : p2.next;
			}
			return p1;
		}

		public static ListNode ReverseList( ListNode head )
		{
			if ( head == null ) return null;
			var ptr = head;
			var cur = head.next;
			head.next = null;
            while (cur != null)
            {
				var node = cur;
				cur = cur.next;
				node.next = ptr;
				ptr = node;
            }
			return ptr;
        }

		public static bool IsPalindrome( ListNode head )
		{
			Stack<ListNode> stack = new Stack<ListNode>();
			var p = head;
			while( p != null )
			{
				stack.Push( p );
				p = p.next;
			}

			p = head;
			while( p != null )
			{
				ListNode node = stack.Pop();
				if ( p.val != node.val)
				{
					return false;
				}
				p = p.next;
			}
			return true;
		}
	}
}
