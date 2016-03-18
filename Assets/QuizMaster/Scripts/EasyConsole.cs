using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class EasyConsole : MonoBehaviour 
{
	public Text text;
	private static Text _text;
	private static List<string> messages = new List<string> ();

	void Awake()
	{
		_text = text;
	}

	public static void Log( string message )
	{
		AddMessage (0, message);
	}

	public static void Warming( string message ){
		AddMessage (1, message);
	}

	public static void Error( string message ){
		AddMessage (2, message);
	}

	private static void AddMessage( int type, string message )
	{
		if( type == 0 ) messages.Add( "<color=#FFFFFF>"+ message +"</color>");
		else if( type == 1 ) messages.Add( "<color=#FFFF00>"+ message +"</color>");
		else if( type == 2 ) messages.Add( "<color=#FF0000>"+ message +"</color>");
		if (messages.Count > 6)
			messages.RemoveAt (0);

		Render ();
	}

	private static void Render(){
		if (_text != null) _text.text = string.Join ("\n", messages.ToArray());
	}
}
