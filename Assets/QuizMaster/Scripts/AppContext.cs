/// If you're new to Strange, start with MyFirstProject.
/// If you're interested in how Signals work, return here once you understand the
/// rest of Strange. This example shows how Signals differ from the default
/// EventDispatcher.
/// All comments from MyFirstProjectContext have been removed and replaced by comments focusing
/// on the differences 

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using Samurai.Utils.Timing;
using Samurai.QuizMaster;
using Samurai.Net;
using Samurai.QuizMaster.Services;


public class AppContext : CommonContext
{

	public AppContext (MonoBehaviour view) : base(view)
	{
	}

	public AppContext (MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
	{
	}
	
	// Override Start so that we can fire the StartSignal 
	override public IContext Start()
	{
		base.Start();

		StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
		startSignal.Dispatch();

		return this;
	}

	protected override void mapBindings()
	{
		base.mapBindings ();
		//setup command
		commandBinder.Bind<StartSignal>().To<StartCommand>().Once ();


		injectionBinder.Bind<CommonMessageSignal>().ToSingleton().CrossContext();

		//setup proxy and model
		injectionBinder.Bind<ManagerGame>().ToSingleton().CrossContext();
		injectionBinder.Bind<ManagerPlayer>().ToSingleton().CrossContext();

		//setup services
		injectionBinder.Bind<IServerService> ().To<LocalQuizServerService>().ToSingleton().CrossContext ();

		//syncTimer = new SyncTimer(100,100);
		//injectionBinder.Bind<SyncTimer> ().ToValue (syncTimer).CrossContext ();
	}
}

