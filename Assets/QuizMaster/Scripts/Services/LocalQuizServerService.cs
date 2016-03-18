using System;

using UniRx;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Samurai.Net;
using Samurai.Utils;

namespace Samurai.QuizMaster.Services
{
	public class LocalQuizServerService: QuizServerService
	{
		private List<QuestionVO> questions = new List<QuestionVO>();

		public override void OnRegistry ()
		{
			base.OnRegistry ();

			InitQuestions ();
			/*
			ObservableWWW.Get ("http://jsonplaceholder.typicode.com/posts").Subscribe (json => {
				List<JObject> posts = JsonConvert.DeserializeObject<List<JObject>>(json);
				Debug.Log( posts.Count );
				commonMessanger.Dispatch(CommonMessages.SayHello, posts.Count);
			});*/
		}

		private void InitQuestions()
		{
			List<string> list = new List<string>{ "陳忠實","莫言","余華","蘇童" };
			questions.Add (new QuestionVO ("1001", QuestionType.SingleChoice, "電影《活著》根據誰的同名小說改編而來？", list, "2", "", 1, "joe"));

			list = new List<string>{ "能近秦王三十步","能近秦王四十步","能近秦王五十步","能近秦王二十步" };
			questions.Add (new QuestionVO ("1002", QuestionType.SingleChoice, "在電影《英雄》中，能夠殺死長空者，有什麼待遇？", list, "3", "", 1, "joe"));

			list = new List<string>{ "李安","陳凱歌","陸川","張藝謀" };
			questions.Add (new QuestionVO ("1003", QuestionType.SingleChoice, "拍《少年派》是中國的哪位著名導演？", list, "0", "", 1, "joe"));

			list = new List<string>{ "九兒","酒兒","紅兒","梁兒" };
			questions.Add (new QuestionVO ("1003", QuestionType.SingleChoice, "電影《紅高粱》中，“我奶奶”稱為掌櫃後，讓大夥稱她什麼？", list, "0", "", 1, "joe"));
		}

		public override void Send (Packet packet)
		{
			base.Send (packet);

			if (packet.command == ServerCommand.SelectLevel) ProcessSelectLevel (packet);

			//JObject restoredObject = JsonConvert.DeserializeObject<JObject>(
			//	jsonString);
			//string json = 
				//File.ReadAllText(Path.Combine(Application.dataPath, "config.json"));
			//this.person = (Person)JSONSerialize.Deserialize(typeof(Person), json);
			//JSONObject.Parse
			//JSON.JSONArrayAttribute
		}

		private void ProcessSelectLevel( Packet packet )
		{
			LevelVO level = new LevelVO ();
			level.thinkTime = 15;
			ArrayUtil.Shuffle (questions);
			level.questions = questions.GetRange (0, 3);
			gameManager.EnterLevel (level);
			//EnterLevel (level);
			//Debug.Log (questions.Count);
		}
	}
}

