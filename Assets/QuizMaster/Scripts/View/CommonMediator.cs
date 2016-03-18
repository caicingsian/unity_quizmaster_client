using System;
using strange.extensions.mediation.impl;
using UnityEngine;

public class CommonMediator : Mediator
{
	[Inject]
	public CommonMessageSignal messager{ get; set; }

	public CommonMediator ()
	{
		
	}

	public override void OnRegister ()
	{
		base.OnRegister ();
	}
}
