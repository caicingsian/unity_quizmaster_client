using System;

namespace Samurai.QuizMaster
{
	public class HomeRoot : CommonContextView
	{
		public override void Awake ()
		{
			base.Awake ();
			context = new HomeContext (this);
		}
	}
}

