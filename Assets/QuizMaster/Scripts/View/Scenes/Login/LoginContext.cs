using System;
using strange.extensions.context.impl;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.api;
using strange.extensions.command.impl;

namespace Samurai.QuizMaster
{
	public class LoginContext:CommonContext
	{
		public LoginContext (MonoBehaviour view) : base (view)
		{
		}

		protected override void mapBindings ()
		{
			base.mapBindings ();

			//Debug.Log ("Login Context mapBindings");

			//bind command
			//commandBinder.Bind<StartSignal>().To<StartCommand>().Once ();
			//commandBinder.Bind<LoadSceneSignal> ().To<LoadSceneCommand> ();
			//injectionBinder.Bind<CommonMessageSignal>().ToSingleton().CrossContext();

			mediationBinder.Bind<SceneLogin> ().To<SceneLoginMediator> ();
		}
	}
}