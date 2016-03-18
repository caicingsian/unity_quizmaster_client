using UnityEngine;
using System.Collections;

namespace Samurai.QuizMaster
{
	public class LobbyContext : CommonContext
	{
		public LobbyContext (MonoBehaviour view) : base (view)
		{
		}

		protected override void mapBindings ()
		{
			base.mapBindings ();
			mediationBinder.Bind<SceneLobby> ().To<SceneLobbyMediator> ();
		}
	}
}