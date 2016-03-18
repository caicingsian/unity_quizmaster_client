using UnityEngine;
using System.Collections;

namespace Samurai.QuizMaster
{
	public class GameRoot : CommonContextView
	{

		public override void Awake ()
		{
			base.Awake ();
			context = new GameContext (this);
		}
	}
}