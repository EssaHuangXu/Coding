using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tree
{
	public class TreeNode( int val = 0, TreeNode left = null, TreeNode right = null )
	{
		public int val = val;
		public TreeNode left = left;
		public TreeNode right = right;
	}
	
	public class Traversal
	{
		public static IList<int> InorderTraversal( TreeNode root )
		{
			static void InorderTraversalInternal( TreeNode root, IList<int> list )
			{
				if( root == null ) return;
				if( root.left != null )
				{
					InorderTraversalInternal( root.left, list );
				}
				list.Add( root.val );
				if( root.right != null )
				{
					InorderTraversalInternal( root.right, list );
				}
			}

			var result = new List<int>();
			InorderTraversalInternal( root, result );
			return result;
		}

		public static int MaxDepth( TreeNode root )
		{
			static int DepthInternal( TreeNode root , int rootDepth )
			{
				if( root == null ) return rootDepth;
				var leftDepth = root.left != null ? DepthInternal( root.left, rootDepth ) : 0;
				var rightDepth = root.right != null ? DepthInternal(root.right, rootDepth ) : 0;
				return Math.Max( leftDepth, rightDepth ) + 1;
			}

			if (root == null ) return 0;	
			return DepthInternal( root, 1 );
		}

		public static TreeNode InvertTree( TreeNode root )
		{
			static void InvertInternal( TreeNode root )
			{
				if( root == null ) return;
				if( root.left == null && root.right == null ) return;
				var leftNode = root.left;
				var rightNode = root.right;
				InvertInternal( root.left );
				InvertInternal( root.right );
				root.right = leftNode;
				root.left = rightNode;
			}

			InvertInternal( root );
			return root;
		}

		public static bool IsSymmetric( TreeNode root )
		{
			static bool IsSymmetricInternal( TreeNode lr, TreeNode rr )
			{
				if( lr == null && rr == null ) return true;
				if( lr == null && rr != null ) return false;
				if( lr != null && rr == null ) return false;
				return lr.val == rr.val && IsSymmetricInternal(lr.left, rr.right) && IsSymmetricInternal( lr.right, rr.left );
			}

			if( root == null ) return true;
			if( root.left == null && root.right == null ) return true;

			return IsSymmetricInternal(root.left, root.right );
		}

		public static IList<IList<int>> LevelOrder( TreeNode root )
		{
			if ( root == null ) return new List<IList<int>>();
			var queue = new Queue<TreeNode>();
			var count = 1;
			var next = 0;
			queue.Enqueue( root );
			var result = new List<IList<int>>();
			var currentList = new List<int>();
			result.Add( currentList );
			while(queue.Count != 0)
			{
				var node = queue.Dequeue();
				if( node == null ) continue;

				currentList.Add( node.val );
				if (node.left != null )
				{
					queue.Enqueue( node.left );
					next++;
				}
				if (node.right != null )
				{
					queue.Enqueue( node.right );
					next++;
				}
				count--;

				if( count == 0 && next != 0 )
				{
					count = next;
					next = 0;
					currentList = new List<int>();
					result.Add( currentList );
				}
			}

			return result;
		}

		public static TreeNode SortedArrayToBST( int[] nums )
		{
			static TreeNode SortedArrayToBSTInternal( int[] nums, int start, int end )
			{
				if( start > end ) return null;
				var mid = (start + end) / 2;
				var node = new TreeNode( nums[mid] )
				{
					left = SortedArrayToBSTInternal( nums, start, mid - 1 ),
					right = SortedArrayToBSTInternal( nums, mid + 1, end )
				};
				return node;
			}

			if( nums.Length == 0 ) return null;
			return SortedArrayToBSTInternal( nums, 0, nums.Length - 1 );
		}

		public static bool IsValidBST( TreeNode root )
		{
			static bool IsValidBSTInternal( TreeNode root, long max, long min )
			{
				if( root == null ) return true;

				return root.val > min && root.val < max && IsValidBSTInternal( root.left, root.val, min ) && IsValidBSTInternal( root.right, max, root.val );
			}

			return IsValidBSTInternal(root, long.MaxValue, long.MinValue);
		}

		public static int KthSmallest( TreeNode root, int k )
		{
			static void CountChilds( TreeNode root, Dictionary<TreeNode, int> cache)
			{
				if (root == null)
				{
					return;
				}

				CountChilds( root.left, cache );
				CountChilds( root.right, cache );
				int letCount = root.left == null ? 0 : cache.GetValueOrDefault( root.left );
				int rightCount = root.right == null ? 0 : cache.GetValueOrDefault( root.right );
				cache[root] = letCount + rightCount + 1;
			}
			
			var cache = new Dictionary<TreeNode, int>();
			CountChilds(root, cache);

			if( cache[root] < k )
			{
				return -1;
			}

			while( root != null )
			{
				var leftCount = root.left == null ? 0 : cache.GetValueOrDefault( root.left );
				if( leftCount + 1 == k )
				{
					return root.val;
				}
				if( leftCount >= k )
				{
					root = root.left;
				}
				else
				{
					k -= leftCount + 1;
					root = root.right;
				}
			}

			return -1;
		}
	}
}
