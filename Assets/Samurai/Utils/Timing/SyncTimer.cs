using UnityEngine;
using System.Collections;
using System.Threading;
using strange.extensions.signal.impl;
using System;

namespace Samurai.Utils.Timing
{
	public class SyncTimer
	{

		public Signal tickSignal;
		private Timer _timer;
		private int _dueTime;
		private int _period;
		private int _elapsed;
		private DateTime _prevTime;

		public int Elapsed{ get { return _elapsed; } }

		public SyncTimer (int dueTime = 100, int period = 100)
		{
			tickSignal = new Signal ();
			_dueTime = dueTime;
			_period = period;
			_prevTime = DateTime.Now;
		}

		public void Start ()
		{
			if (_timer == null)
				_timer = new Timer (OnTimer, null, _dueTime, _period);
			else
				_timer.Change (_dueTime, _period);
		}

		public void Stop ()
		{
			_timer.Change (Timeout.Infinite, Timeout.Infinite);
		}

		private void OnTimer (object obj)
		{
			Debug.Log ("OnTimer");
			DateTime now = DateTime.Now;
			_elapsed = (int)now.Subtract (_prevTime).TotalMilliseconds;
			_prevTime = now;
			tickSignal.Dispatch ();
		}
	}
}


