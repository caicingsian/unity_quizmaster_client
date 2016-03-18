using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Samurai.UI;

[RequireComponent (typeof(Text))]
public class UIText : MonoBehaviour, ILabel
{
	[HideInInspector]
	public Text label;
	private string _text;

	void Awake ()
	{
		label = GetComponent<Text> ();
	}

	public string text {
		get {
			return _text;
		}
		set {
			_text = value;
			label.text = _text;
		}
	}
}
