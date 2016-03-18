/// The only change in StartCommand is that we extend Command, not EventCommand

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.command.impl;
using strange.extensions.dispatcher.eventdispatcher.impl;
using Samurai.QuizMaster.Services;
using Samurai.QuizMaster;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using UniRx;
using System.IO;
using System.Collections;


public class StartCommand : CommonCommand
{
	[Inject]
	public LoadSceneSignal loadSceneSignal{ get; set; }

	[Inject]
	public IServerService server{ get; set; }

	[Inject]
	public ManagerGame gameManager{ get; set; }

	[Inject]
	public ManagerPlayer playerManager{ get; set; }

	public override void Execute()
	{
		if( Application.loadedLevelName == SceneNames.Main )
			loadSceneSignal.Dispatch (SceneNames.Login, string.Empty);

		((QuizServerService)server).gameManager = gameManager;
		((QuizServerService)server).playerManager = playerManager;

		LoadLevelData ();
	}

	private void LoadLevelData()
	{
		/*
		var cancel = Observable.FromCoroutine (StartDownload)
			.Subscribe();*/

		//ObservableWWW.LoadFromCacheOrDownload("file://" + Application.dataPath + "/../AssetBundles/gamelevel").sub`
		//Debug.Log (File.Exists (Application.dataPath+"/../AssetBundles/gamelevel"));
		//ObservableWWW.Get(Application.dataPath+"../AssetBundles/gamelevel")
		/*
			ObservableWWW.Get("file://" + Application.dataPath + "/../AssetBundles/gamelevel")
			.Subscribe(
				x => {
					Debug.Log("111:"+x);
					//Debug.Log(x.Substring(0, 100));
				}, // onSuccess
				ex =>{
					Debug.Log( ex.Message );
					//Debug.LogException(ex);
				}); // onError
			*/
		//StartCoroutine (DownloadAndCache());
		

		string filePath = "LevelData";
		TextAsset targetFile = Resources.Load<TextAsset>(filePath);
		var definition = new { content = new List<SubjectVO>() };
		var data = JsonConvert.DeserializeAnonymousType(targetFile.text, definition);
		gameManager.subjects = data.content;
	}

	IEnumerator StartDownload() {
		// Download the file from the URL. It will not be saved in the Cache
		using (WWW www = new WWW("file://" + Application.dataPath + "/../AssetBundles/gamelevel")) {
			yield return www;
			if (www.error != null)
				throw new Exception("WWW download had an error:" + www.error);

			AssetBundle bundle = www.assetBundle;
			TextAsset txt = bundle.LoadAsset("LevelData", typeof(TextAsset)) as TextAsset;
			Debug.Log (txt.text);
			//Debug.Log ("aaaa");
			/*
			if (AssetName == "")
				Instantiate(bundle.mainAsset);
			else
				Instantiate(bundle.LoadAsset(AssetName));*/
			// Unload the AssetBundles compressed contents to conserve memory
			//bundle.Unload(false);

		} // memory is freed from the web stream (www.Dispose() gets called implicitly)
	}
}

