using System;
using strange.extensions.context.impl;
using DG.Tweening;

namespace Samurai.QuizMaster
{
	public class LoginRoot : CommonContextView
	{
		public override void Awake ()
		{
			base.Awake ();
			context = new LoginContext (this);
		}
	}
}

