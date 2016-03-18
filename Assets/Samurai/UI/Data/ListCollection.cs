using System;
using System.Collections.Generic;

namespace Samurai.UI
{
	public class ListCollection
	{
		public List<object> data{
			get;
			set;
		}

		public ListCollection ()
		{
			data = new List<object> ();
		}
	}
}

