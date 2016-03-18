using System;
using strange.extensions.context.impl;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.api;
using strange.extensions.command.impl;

public class CommonContext : MVCSContext
{
	public CommonContext (MonoBehaviour view) : base(view)
	{
	}

	public CommonContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
	{

	}
		
	protected override void addCoreComponents()
	{
		base.addCoreComponents ();
		injectionBinder.Unbind<ICommandBinder>();
		injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
	}


	override public IContext Start()
	{
		base.Start();
		return this;
	}

	protected override void mapBindings()
	{
		commandBinder.Bind<LoadSceneSignal> ().To<LoadSceneCommand> ();
		commandBinder.Bind<LoginSignal> ().To<LoginCommand> ().Pooled ();
	}
}
