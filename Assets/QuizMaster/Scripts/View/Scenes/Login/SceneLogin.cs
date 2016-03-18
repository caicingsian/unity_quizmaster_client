using System;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;
using Samurai.UI;
using Samurai.Extensions;
using Samurai.QuizMaster.UI;

namespace Samurai.QuizMaster
{

	public class SceneLogin : SceneCommon
	{
		public CommonButton btnGuest;
		public CommonButton btnGoogle;
		public CommonButton btnFacebook;

		public SceneLogin ()
		{	
		}

		protected override void Awake ()
		{
			base.Awake ();

			btnGuest = transform.GetChildByName ("ButtonGuest").GetComponent<CommonButton> ();
			btnGoogle = transform.GetChildByName ("ButtonGoogle").GetComponent<CommonButton> ();
			//btnGoogle = transform.GetChildByName ("ButtonFacebook").GetComponent<CommonButton> ();
		}
	}
}