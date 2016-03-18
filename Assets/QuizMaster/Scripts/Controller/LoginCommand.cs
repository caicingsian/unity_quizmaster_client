using System;
using UnityEngine;
using Facebook.Unity;
using System.Collections.Generic;

public class LoginCommand : CommonCommand
{
	public LoginCommand ()
	{
		
	}

	[Inject]
	public LoadSceneSignal loadSceneSignal{ get; set; }

	[Inject]
	public LoginSignal login{ get; set; }

	public override void Execute()
	{
		switch (login.loginType) {
		case "facebook":
			LoginWithFaceook ();
			break;
		case "guest":
			LoginWithGuest ();
			break;
		default:
			break;
		}
		//Debug.Log (login.account);
		//EasyConsole.Log ("account:" + login.account);
	}
		
	private void LoginWithFaceook()
	{
		EasyConsole.Log ("LoginWithFacebook");
		if (FB.IsInitialized) {
			FB.LogInWithReadPermissions (new List<string> () { "public_profile", "email", "user_friends" }, this.OnFacebookLoginResult);
		} else {
			FB.Init(this.OnInitComplete, this.OnHideUnity);
		}
	}

	private void OnInitComplete()
	{
		//this.Status = "Success - Check log for details";
		//this.LastResponse = "Success Response: OnInitComplete Called\n";
		string logMessage = string.Format(
			"OnInitCompleteCalled IsLoggedIn='{0}' IsInitialized='{1}'",
			FB.IsLoggedIn,
			FB.IsInitialized);
		EasyConsole.Log ("Facebook Init:" + logMessage);
		//LogView.AddLog(logMessage);
	}

	private void OnHideUnity(bool isGameShown)
	{
		//this.Status = "Success - Check log for details";
		//this.LastResponse = string.Format("Success Response: OnHideUnity Called {0}\n", isGameShown);
		//LogView.AddLog("Is game shown: " + isGameShown);
	}

	private void OnFacebookLoginResult( ILoginResult result )
	{
		if (FB.IsLoggedIn) {
			EasyConsole.Log ("OnFacebookLoginResult:" + result.AccessToken.UserId );
		} else {
			//Login Failed.
			EasyConsole.Log ("OnFacebookLoginResult:" + "Failed" );
		}
	}

	private void LoginWithGuest()
	{
		EasyConsole.Log ("LoginWithGuest");
		login.account = SystemInfo.deviceUniqueIdentifier;
		EasyConsole.Log (login.account);
	}
}

