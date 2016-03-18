﻿/// The Root is the entry point to a strange-enabled Unity3D app.
/// ===============
/// 
/// Attach this MonoBehaviour to a GameObject at the top of your Main scene.
/// 
/// It is considered a best practice to create ONE GameObject at the top of your 
/// app and attach everything to it. (Note that you can create multiple Roots which 
/// will result in multiple Contexts.  This can be desirable, but it's an advanced use case.
/// Recommend you stick to a single Context until you're confident you know what you're doing.
/// 
/// The GameObject to which this MonoBehaviour is attached to called the 'ContextView'
/// and is injectable anywhere in the application. This is especially
/// useful in commands, where you can access the ContextView to attach further GameObjects 
/// or MonoBehaviours.

using System;
using UnityEngine;
using strange.extensions.context.impl;

public class AppRoot : ContextView
{
	void Awake()
	{
		context = new AppContext(this);
		DontDestroyOnLoad (this);
	}

	void OnDisable(){
		
	}

	void OnEnable(){
		
	}
}

