using UnityEngine;
using System.Collections;

namespace Samurai.QuizMaster
{
	public class GameContext : CommonContext
	{

		public GameContext (MonoBehaviour view) : base (view)
		{
		}

		protected override void mapBindings ()
		{
			base.mapBindings ();
			mediationBinder.Bind<SceneGameClassic> ().To<SceneGameClassicMediator> ();
			mediationBinder.Bind<SceneGameBattle> ().To<SceneGameBattleMediator> ();
		}

		public override void OnRemove ()
		{
			base.OnRemove ();
			//Debug.Log ("GameContext OnRemove");
			//mediationBinder.Unbind<SceneGameClassic> ();
			//mediationBinder.Unbind<SceneGameBattle> ();
		}
	}
}