using UnityEngine;
using System.Collections;

namespace Samurai.QuizMaster
{

	public class SceneLobbyMediator : CommonMediator
	{

		[Inject]
		public SceneLobby sceneLobby{ get; set; }

		[Inject]
		public LoadSceneSignal loadSceneSignal{ get; set; }

		public override void OnRegister ()
		{
			base.OnRegister ();
			messager.AddListener (OnCommonMessageHandler);

			sceneLobby.btnStart.onClick.AddListener (OnStartClick);
			sceneLobby.btnBack.onClick.AddListener (OnBackClick);
		}

		private void OnStartClick ()
		{
			loadSceneSignal.Dispatch (SceneNames.GameClassic, "");
		}

		private void OnBackClick ()
		{
			loadSceneSignal.Dispatch (SceneNames.Home, "");
		}

		private void OnCommonMessageHandler (CommonMessages type, object data)
		{
			Debug.Log ("type:" + type);
		}
	}
}
