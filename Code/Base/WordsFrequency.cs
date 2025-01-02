using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Base
{
	public class WordsFrequency
	{
		private Dictionary<string, int> _frequency;

		public WordsFrequency( string[] book )
		{
			_frequency = [];
			foreach( string key in book )
			{
				if( _frequency.TryGetValue( key, out int value ) )
				{
					_frequency[key] = ++value;
				}
				else
				{
					_frequency.Add( key, 1 );
				}
			}
		}

		public int Get( string word )
		{
			if( _frequency.TryGetValue( word, out int value ) )
			{
				return value;
			}
			return 0;
		}
	}
}
