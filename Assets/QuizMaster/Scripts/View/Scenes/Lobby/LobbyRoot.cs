using UnityEngine;
using System.Collections;

namespace Samurai.QuizMaster
{
	public class LobbyRoot : CommonContextView
	{

		public override void Awake ()
		{
			base.Awake ();
			context = new LobbyContext (this);
		}
	}
}