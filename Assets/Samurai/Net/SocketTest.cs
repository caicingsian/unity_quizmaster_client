using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.IO;
using System;
using System.Text;

public class SocketTest : MonoBehaviour {

	//SocketClient socket;

	// Use this for initialization
	void Start () {
		StartConnect ( "192.168.43.64", 8005 );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private TcpClient _client;
	const int READ_BUFFER_SIZE = 32;
	private byte[] readBuffer = new byte[READ_BUFFER_SIZE];
	public ArrayList lstUsers=new ArrayList();
	public string strMessage=string.Empty;
	public string res=String.Empty;
	private string pUserName;

	public string StartConnect(string sNetIP, int iPORT_NUM)
	{
		try 
		{
			_client = new TcpClient(sNetIP, iPORT_NUM);
			_client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);
			return "Connection Succeeded";
		} 
		catch(Exception ex)
		{
			return "Server is not active.  Please start server and try again.      " + ex.ToString();
		}
	}

	private void DoRead(IAsyncResult ar)
	{ 
		int BytesRead;
		try
		{
			
			BytesRead = _client.GetStream().EndRead(ar);
			//byte[] head = new byte[2];
			string head = Encoding.UTF8.GetString(readBuffer,0,2);
			Debug.Log ("BytesRead:" + BytesRead + ",head:" + head);
			if (BytesRead < 1) 
			{
				// if no bytes were read server has close.  
				res="Disconnected";
				return;
			}

			strMessage = Encoding.UTF8.GetString(readBuffer, 0, BytesRead - 2);
			Debug.Log("DoRead:" + strMessage );
			//ProcessCommands(strMessage);
			_client.GetStream().BeginRead(readBuffer, 0, READ_BUFFER_SIZE, new AsyncCallback(DoRead), null);

		} 
		catch
		{
			res="Disconnected";
		}
	}

	public void OnDestroy(){
		_client.Close ();
	}

	public void CloseSocket(){
		_client.Close ();
	}

	public void SendDataToServer(){
		SendData ("who am i");
	}

	// Use a StreamWriter to send a message to server.
	private void SendData(string data)
	{
		Debug.Log ("SendData:" + data);
		data += "\r\n";
		StreamWriter writer = new StreamWriter(_client.GetStream());
		//writer.Write(data + (char) 13);
		writer.Write(data);
		writer.Flush();
	}

}
