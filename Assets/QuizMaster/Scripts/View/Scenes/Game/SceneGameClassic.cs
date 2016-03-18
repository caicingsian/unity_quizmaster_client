using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Samurai.QuizMaster
{
	public class SceneGameClassic : SceneCommon
	{
		public Text text;

		public ClassicGameController gameController;
		public ClassicGameLevelController levelController;


		override protected void Awake ()
		{
			//gameController = GetComponentInChildren<ClassicGameController> ();
			//levelController = GetComponentInChildren<ClassicGameLevelController> ();
			//levelController.onLevelSelectHandler
		}

		override protected void Start ()
		{
			
		}

		public override void SceneEnter ()
		{
			base.SceneEnter ();
		}

	}
}