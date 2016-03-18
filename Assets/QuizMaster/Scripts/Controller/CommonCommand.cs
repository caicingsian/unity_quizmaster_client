using System;
using strange.extensions.command.impl;

public class CommonCommand : Command
{
	[Inject]
	public CommonMessageSignal commonMessanger{ get; set; }

	public CommonCommand ()
	{
	}

	public override void Execute ()
	{
		
	}
}

