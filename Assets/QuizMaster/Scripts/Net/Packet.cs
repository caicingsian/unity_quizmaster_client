using System;
using System.Collections.Generic;

namespace Samurai.Net
{
	public class Packet
	{
		private List<string> _keys = new List<string> ();
		private List<object> _values = new List<object> ();
		private string _command;

		public Packet ()
		{
			
		}

		public static Packet Create ()
		{
			return new Packet ();
		}

		public Packet SetCommand (string command)
		{
			_command = command;
			return this;
		}

		public string command{ get { return _command; } }

		public Packet SetValue (string key, object value)
		{
			if (_keys.IndexOf (key) >= 0)
				throw new Exception ("Set Exist Key:" + key);
			
			_keys.Add (key);
			_values.Add (value);

			return this;
		}

		public object GetValue (string key)
		{
			int idx = _keys.IndexOf (key);
			if (idx >= 0)
				return _values [idx];
			else
				return "";
		}
	}
}

