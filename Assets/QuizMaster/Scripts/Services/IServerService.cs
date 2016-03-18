using System;
using strange.extensions.signal.impl;
using Samurai.Net;

namespace Samurai.QuizMaster.Services
{
	public interface IServerService
	{
		void Connect(string host, int port);
		void Send(Packet packet);
		void Close ();
		bool Connected{ get; }

		Signal OnConnected{ get; }
		Signal OnError{ get; }
		Signal OnClose{ get; }
		Signal<Packet> OnReceive{ get; }
	}
}

