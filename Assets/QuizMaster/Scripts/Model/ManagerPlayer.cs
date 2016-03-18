using System;
using Samurai.QuizMaster.Services;

namespace Samurai.QuizMaster
{
	public class ManagerPlayer:CommonProxy
	{
		private PlayerVO _self;

		[Inject]
		public IServerService server{ get; set; }

		public ManagerPlayer ()
		{
			_self = new PlayerVO();
		}

		public override void OnRegistry ()
		{
			base.OnRegistry ();
		}
	}
}

