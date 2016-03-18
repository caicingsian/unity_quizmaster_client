using System;
using UnityEngine;

namespace Samurai.QuizMaster
{
	public class CommonProxy
	{
		[Inject]
		public CommonMessageSignal commonMessanger{ get; set; }


		[PostConstruct]
		virtual	public void OnRegistry ()
		{
			
		}

		public CommonProxy ()
		{
			
		}
	}
}

