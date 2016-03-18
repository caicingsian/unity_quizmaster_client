using System;
using UnityEngine;
using strange.extensions.mediation.impl;
using DG.Tweening;
using Samurai.UI;
using Fabric.Crashlytics;

namespace Samurai.QuizMaster
{
	public class SceneLoginMediator : CommonMediator
	{
		[Inject]
		public SceneLogin sceneLogin{ get; set; }

		[Inject]
		public LoginSignal loginSignal{ get; set; }

		[Inject]
		public LoadSceneSignal loadSceneSignal{ get; set; }

		public SceneLoginMediator ()
		{
			
		}

		public override void OnRegister ()
		{
			base.OnRegister ();

			//commonMessager.AddListener (OnCommonMessageHandler); 
			sceneLogin.btnGuest.OnClick.AddListener (OnGuestLogin);
			sceneLogin.btnGoogle.OnClick.AddListener (OnGoogleClick);
			sceneLogin.btnFacebook.OnClick.AddListener (OnFacebookLogin);

		}

		private void OnGoogleClick(IButton btn)
		{
			//Crashlytics.Crash();
		}

		private void OnFacebookLogin(IButton btn)
		{
			loginSignal.loginType = "facebook";
			loginSignal.Dispatch ();
			//Crashlytics.ThrowNonFatal ();
			//Application.Quit ();
		}

		private void OnGuestLogin (IButton btn)
		{
			//Debug.Log ("OnGuestLogin:" + UnityEngine.SystemInfo.deviceUniqueIdentifier);
			loginSignal.loginType = "guest";
			//loadSceneSignal.Dispatch (SceneNames.Home, string.Empty);
			//SendMessage (CommonMessages.ChangeScene, SceneNames.Home);
			//loginSignal.account = UnityEngine.SystemInfo.deviceUniqueIdentifier;
			loginSignal.Dispatch ();
		}

		private void OnCommonMessageHandler (CommonMessages type, object data)
		{
			Debug.Log ("type:" + type);
		}
	}
}