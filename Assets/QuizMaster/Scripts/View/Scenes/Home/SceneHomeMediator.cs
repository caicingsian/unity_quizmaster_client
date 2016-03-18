using System;
using UnityEngine;
using Samurai.UI;

namespace Samurai.QuizMaster
{

	public class SceneHomeMediator : CommonMediator
	{
		[Inject]
		public SceneHome sceneHome{ get; set; }

		[Inject]
		public LoadSceneSignal loadSceneSignal{ get; set; }

		[Inject]
		public ManagerGame gameProxy{ get; set; }

		public override void OnRegister ()
		{
			base.OnRegister ();
			messager.AddListener (OnCommonMessageHandler);

			sceneHome.btnPlayClassic.OnClick.AddListener (OnPlayClassic);
		}

		private void OnPlayClassic( IButton btn )
		{
			gameProxy.SelectLevel (1, 1);
			//loadSceneSignal.Dispatch (SceneNames.GameClassic, "");
		}

		public override void OnRemove ()
		{
			base.OnRemove ();
			Debug.Log ("OnRemove Home");
			messager.RemoveListener (OnCommonMessageHandler);
		}

		private void OnCommonMessageHandler (CommonMessages type, object data)
		{
			//Debug.Log ("type:" + type);
		}
	}

}