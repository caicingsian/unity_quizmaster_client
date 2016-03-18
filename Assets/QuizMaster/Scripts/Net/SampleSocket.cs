using System;
using System.Net.Sockets;
using System.Net;
using UnityEngine;
using System.Text;
using strange.extensions.signal.impl;
using System.Timers;
using Samurai.QuizMaster.Services;

namespace Samurai.Net
{
	public class SampleSocket : ServerService
	{
		public Signal connectedSignal;
		public Signal errorSignal;
		public Signal closeSignal;
		public Signal<string> receiveSignal;

		private const int TIME_OUT_SEC = 5;

		private Socket _clientSocket = null;
		private byte[] _recieveBuffer = new byte[2048];
		private bool _connected = false;
		private bool _connecting;

		public Signal OnConnected{ get { return connectedSignal; } }

		private Timer _timeoutTimer;

		public SampleSocket ()
		{
			connectedSignal = new Signal ();
			errorSignal = new Signal ();
			closeSignal = new Signal ();
			receiveSignal = new Signal<string> ();
			_timeoutTimer = new Timer (TIME_OUT_SEC * 1000);
			_timeoutTimer.Elapsed += OnConnectTimeOut;
		}

		public bool Connected {
			get {
				if (_clientSocket != null)
					return _clientSocket.Connected;
				return _connected;
			}
		}

		public Signal OnError {
			get {
				return errorSignal;
			}
		}

		public Signal OnClose {
			get {
				return closeSignal;
			}
		}

		public Signal<string> OnReceive {
			get {
				return receiveSignal;
			}
		}

		public void Connect (string ip, int port)
		{
			try {
				if (_connecting)
					return;
				
				if (_clientSocket == null || _clientSocket.Connected == false)
					_clientSocket = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				if (_clientSocket.Connected)
					return;

				SocketAsyncEventArgs e = new SocketAsyncEventArgs ();

				IPEndPoint ipEnd = new IPEndPoint (IPAddress.Parse (ip), port);
				e.RemoteEndPoint = ipEnd;
				e.UserToken = _clientSocket;
				e.Completed += new EventHandler<SocketAsyncEventArgs> (OnConnectedHandler);

				//_clientSocket.Connect (ipEnd);
				_connecting = true;
				_timeoutTimer.Start();
				_clientSocket.ConnectAsync (e);

			} catch (SocketException ex) {
				Debug.Log ("Socket Connect Exception:" + ex.Message);
			}
		}

		private void OnConnectedHandler (object sender, SocketAsyncEventArgs e)
		{
			_timeoutTimer.Stop ();
			_connecting = false;
			connectedSignal.Dispatch ();
		}

		private void OnConnectTimeOut(object sender, EventArgs e)
		{
			Debug.Log ("OnConnectTimeOut");
			_timeoutTimer.Stop ();
			_connecting = false;
			errorSignal.Dispatch ();

		}

		public void Send (String sJson)
		{
			try {
				byte[] byteArray = System.Text.Encoding.UTF8.GetBytes (sJson);
				SendData (byteArray);
			} catch (SocketException ex) {
				Debug.LogWarning (ex.Message);
			}
			_clientSocket.BeginReceive (_recieveBuffer, 0, _recieveBuffer.Length, SocketFlags.None, new AsyncCallback (ReceiveCallback), null);
		}


		private void SendData (byte[] data)
		{
			SocketAsyncEventArgs socketAsyncData = new SocketAsyncEventArgs ();
			socketAsyncData.SetBuffer (data, 0, data.Length);
			_clientSocket.SendAsync (socketAsyncData);
		}


		private void ReceiveCallback (IAsyncResult AR)
		{
			int recieved = _clientSocket.EndReceive (AR);

			Debug.Log ("ReceiveCallback - recieved: " + recieved + " bytes");

			if (recieved <= 0)
				return;

			byte[] recData = new byte[recieved];
			Buffer.BlockCopy (_recieveBuffer, 0, recData, 0, recieved);

			string recvStr = Encoding.UTF8.GetString (recData, 0, recieved);
			Debug.Log ("recvStr: " + recvStr);

			_clientSocket.BeginReceive (_recieveBuffer, 0, _recieveBuffer.Length, SocketFlags.None, new AsyncCallback (ReceiveCallback), null);
		}

		public void Close ()
		{
			try {
				_clientSocket.Shutdown (SocketShutdown.Both);
				_clientSocket.Close ();	
			} catch (Exception ex) {
				Debug.Log ("Socket Close Exception:" + ex.Message);			
			}
		}
	}
}

