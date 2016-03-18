using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UniRx;
using System;

[RequireComponent(typeof(RawImage))]
public class ImageLoader : MonoBehaviour {

	private RawImage image;

	void Awake(){
		image = GetComponent<RawImage> ();
	}

	void Start () {
		UpdateImageUrl ("http://static01.nyt.com/images/2011/06/26/sunday-review/26QUIZ/26QUIZ-articleLarge.jpg");
	}

	public void UpdateImageUrl( string url )
	{
		StartCoroutine( StartLoadImage(url) );
	}

	IEnumerator StartLoadImage( string url )
	{
		WWW www = new WWW (url);
		yield return www;

		if (!String.IsNullOrEmpty (www.error)) {
			Debug.LogError (www.error);
		} else {
			image.texture =  www.texture;
		}
	}
}
