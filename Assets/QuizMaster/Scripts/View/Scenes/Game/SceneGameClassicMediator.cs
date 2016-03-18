using UnityEngine;
using System.Collections;
using UniRx;
using System;

namespace Samurai.QuizMaster
{
	public class SceneGameClassicMediator : CommonMediator
	{

		[Inject]
		public SceneGameClassic scene{ get; set; }

		[Inject]
		public LoadSceneSignal loadSceneSignal{ get; set; }

		[Inject]
		public ManagerGame gameManager{ get; set; }

		[Inject]
		public ManagerPlayer playerProxy{ get; set; }

		public override void OnRegister ()
		{
//			Debug.Log ("OnRegister SceneGameClassicMediator");

			base.OnRegister ();
			messager.AddListener (OnCommonMessageHandler);
			//scene.SceneEnter ();
			gameManager.SelectLevel (1, 1);
			//Observable.Timer (TimeSpan.FromSeconds (1)).Subscribe (x => scene.gameController.StartGame( gameManager.curtLevel ));
			scene.levelController.InitLevelData( gameManager.subjects );
		}

		void Awake()
		{
//			Debug.Log ("Awake SceneGameClassicMediator");
		}

		void Start()
		{
//			Debug.Log ("Start SceneGameClassicMediator");
			scene.levelController.onLevelSelectSignal.AddListener (OnLevelSelectHandler);
		}

		private void OnLevelSelectHandler( LevelVO level )
		{
			scene.gameController.Show();
			scene.levelController.Hide();
			Observable.Timer (TimeSpan.FromSeconds (1)).Subscribe (x => scene.gameController.StartGame( gameManager.curtLevel ));
		}

		private void OnLobbyClick ()
		{
			//loadSceneSignal.Dispatch (SceneNames.Lobby, "");
		}
			
		public override void OnRemove ()
		{
			base.OnRemove ();
//			Debug.Log ("OnRemove SceneGameClassicMediator");
			//commonMessager.RemoveListener (OnCommonMessageHandler);
		}

		private void OnCommonMessageHandler (CommonMessages type, object data)
		{
			//Debug.Log ("type:" + type);
			if (type == CommonMessages.SayHello) {
				scene.text.text = "Total Post:" + data.ToString ();
			}
		}
	}
}