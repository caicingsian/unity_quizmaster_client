using System;
using strange.extensions.context.impl;
using UnityEngine;

public class CommonContextView : ContextView
{
	public CommonContextView ()
	{
	}

	virtual public void Awake()
	{
		CheckAppContextExist ();
	}

	/// <summary>
	/// 檢查主要的Context是不是存在場景上面.
	/// </summary>
	/// <returns>The app context exist.</returns>
	private void CheckAppContextExist()
	{
		GameObject app = GameObject.Find ("AppRoot");
		if (app == null) {
			app = GameObject.Instantiate (Resources.Load ("prefabs/appRoot")) as GameObject;
			app.name = "AppRoot";
		}
	}
}
