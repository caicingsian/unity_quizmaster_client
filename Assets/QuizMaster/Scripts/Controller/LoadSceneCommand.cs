using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCommand : CommonCommand
{
	[Inject]
	public string sceneName{get;set;}

	[Inject]
	public object sceneArgs{get;set;}

	public LoadSceneCommand ()
	{
		
	}

	public override void Execute ()
	{
		base.Execute ();

		if (SceneManager.GetActiveScene ().name == sceneName)
			return;

		SceneManager.LoadScene (sceneName);

	}
}