using System;
using Samurai.QuizMaster.Services;
using UnityEngine;
using Samurai.Net;
using System.Collections.Generic;

namespace Samurai.QuizMaster
{
	public class ManagerGame:CommonProxy
	{
		public List<SubjectVO> subjects = new List<SubjectVO>();

		private LevelVO _curtLevel;

		public LevelVO curtLevel{ get { return _curtLevel; } }

		[Inject]
		public IServerService server{ get; set; }

		[Inject]
		public LoadSceneSignal loadSceneSignal{ get; set; }

		public override void OnRegistry ()
		{
			base.OnRegistry ();
//			Debug.Log ("ManagerGame OnRegistry");

		}

		public void SelectLevel (int type, int level)
		{
			server.Send (Packet.Create ()
				.SetCommand (ServerCommand.SelectLevel)
				.SetValue ("type", "1")
				.SetValue ("level", "1"));
		}

		public void EnterLevel( LevelVO level )
		{
			_curtLevel = level;
			commonMessanger.Dispatch (CommonMessages.EnterLevel, _curtLevel);
			loadSceneSignal.Dispatch( SceneNames.GameClassic, "");
		}
	}
}



