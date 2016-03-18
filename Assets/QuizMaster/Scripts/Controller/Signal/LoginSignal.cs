using System;
using strange.extensions.signal.impl;
using UnityEngine;
using Facebook.Unity;
using System.Collections.Generic;

public class LoginSignal:Signal
{
	public string loginType = "guest";

	public string account;

	public LoginSignal ()
	{
		
	}
}

