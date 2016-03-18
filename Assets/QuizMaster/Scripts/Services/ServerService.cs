using System;
using Samurai.Net;
using UnityEngine;
using strange.extensions.signal.impl;

namespace Samurai.QuizMaster.Services
{
	public class ServerService : CommonProxy, IServerService
	{
		protected bool _connected = false;
		private Signal _connectedSignal;
		private Signal _connectedErrorSignal;
		private Signal _connectedCloseSignal;
		private Signal<Packet> _receiveSignal;

		public ServerService(){
			_connectedSignal = new Signal ();
			_connectedErrorSignal = new Signal ();
			_connectedCloseSignal = new Signal ();
			_receiveSignal = new Signal<Packet> ();
		}

		virtual	public void Connect (string host, int port)
		{
			
		}

		virtual public void Send (Packet packet)
		{
			
		}

		public void Close ()
		{
			
		}

		public bool Connected {
			get {
				return _connected;
			}
		}

		public Signal OnConnected {
			get {
				return _connectedSignal;
			}
		}

		public Signal OnError {
			get {
				return _connectedErrorSignal;
			}
		}

		public Signal OnClose {
			get {
				return _connectedCloseSignal;
			}
		}

		public Signal<Packet> OnReceive {
			get {
				return _receiveSignal;
			}
		}
	}
}

