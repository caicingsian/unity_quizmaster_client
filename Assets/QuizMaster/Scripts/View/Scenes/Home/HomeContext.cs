using System;
using UnityEngine;

namespace Samurai.QuizMaster
{
	public class HomeContext : CommonContext
	{
		public HomeContext (MonoBehaviour view) : base(view)
		{
		}

		protected override void mapBindings()
		{
			base.mapBindings ();
			mediationBinder.Bind<SceneHome>().To<SceneHomeMediator>();
		}
	}
}

