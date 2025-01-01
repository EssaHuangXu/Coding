using Code.Base;
using Code.Tree;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Code
{
	internal class Program
	{
		static void Main( string[] args )
		{
			var result = FindWhetherExistsPath( 4, [[0, 1], [0, 2], [1, 2], [2, 0], [3, 2]], 0, 3 );
			Console.WriteLine( result );
		}

		//Temp Replace by DFS
		public static bool FindWhetherExistsPath( int n, int[][] graph, int start, int target )
		{
			HashSet<int> visited = new HashSet<int>();
			HashSet<int> foward = new HashSet<int>();
			Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
			for( int i = 0; i < graph.Length; i++ )
			{
				var pair = graph[i];
				var s = pair[0];
				var e = pair[1];
				if ( map.ContainsKey(s) ==  false )
				{
					map.Add(s, new HashSet<int>());
				}

				var set = map[s];
				if( set.Contains( e ) == false )
				{
					set.Add( e );
				}
			}

			if ( map.ContainsKey( start ) == false )
			{
				return false;
			}
			var startSet = map[start];
			foreach( var s in startSet ) 
			{
				if( s == target ) return true;

				foward.Add( s );
			}

			while(foward.Count != 0)
			{
				var key = foward.First();
				if( visited.Contains( key ) == true )
				{
					foward.Remove(key);
					continue;
				}

				if (key == target ) return true;

				if ( map.TryGetValue( key, out var value ) == true )
				{
					foreach( var v in value )
					{
						if(foward.Contains( v ) == false )
						{
							foward.Add( v );
						}
					}
				}
				foward.Remove(key);
				visited.Add( key );
			}

			return false;
		}
	}
}
