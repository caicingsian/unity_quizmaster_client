using UnityEngine;
using System.Collections;
using WebSocket4Net;
using System;

public class SocketTest2 : MonoBehaviour {

	// Use this for initialization
	private WebSocket _webSocket;

	void Start () {
		
		//string serverAdress = "ws://echo.websocket.org:80/";
		string serverAdress = "ws://192.168.43.64:8006/";
		string message = "Clients Send Message" ;
		string ServerMessage = "Server Message" ;

		_webSocket = new WebSocket( serverAdress );
		_webSocket.Opened += new EventHandler(websocket_Opened);
		//   websocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error);
		_webSocket.Closed += new EventHandler(websocket_Closed);
		_webSocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>( websocket_MessageReceived  );

		_webSocket.Open();
	}

	private void websocket_Opened(object sender, EventArgs e)
	{
		_webSocket.Send( "Join The Game" );
	}

	private void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
	{
		Debug.Log (e.Message);
		//ServerMessage += e.Message;
	}

	private void websocket_Closed(object sender, EventArgs e)
	{
		//_webSocket.Close();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
