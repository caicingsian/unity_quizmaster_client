using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Samurai.QuizMaster;
using Samurai.Extensions;
using DG.Tweening;
using Samurai.QuizMaster.UI;
using Samurai.UI;
using UniRx;
using System;

namespace Samurai.QuizMaster
{
	public class ClassicGameController : CommonPanel
	{
		public Text textTime;
		public Image timeProgress;

		public List<QuestionOption> options;
		private Text _textQuestion;
		private GameObject _panelQuestoin;

		private LevelVO _level;
		private int _questionIdx = 0;

		private IDisposable _timer;
		private float _answerTime = 0;
		private float _answerTimeLimit = 20;

		private bool _enableUseTool = false;

		override protected void Awake ()
		{
			_textQuestion = transform.GetChildByName ("TextQuestion").GetComponent<Text> ();
			_panelQuestoin = transform.GetChildByName ("PanelQuestion");
		}

		void Start ()
		{
			Reset ();
			ShowNextQuestion ();
		}

		public void StartGame( LevelVO level )
		{
			_level = level;
			_questionIdx = 0;
		}
			
		private void Reset()
		{
			_textQuestion.text = "";
			for (int i = 0; i < options.Count; i++) {
				options [i].textOption.text = "";
				options [i].btn.OnClick.AddListener (OnAnswerChoice);
			}
		}

		private void StartCountdown ()
		{
			_answerTime = 0;
			_timer = Observable.Interval (TimeSpan.FromMilliseconds (10))
				.Subscribe (OnCountdownHandler);
		}

		private void StopCountdown()
		{
			if( _timer != null ) _timer.Dispose ();
		}

		private void OnCountdownHandler (long x)
		{
			_answerTime += Time.deltaTime;

			if (_answerTime > _answerTimeLimit) {
				StopCountdown ();
				AnswerTimeout ();
			}

			UpdateTimeProgress ();
		}

		private void UpdateTimeProgress()
		{
			int leaveTime = (int)Mathf.Clamp (Mathf.Ceil (_answerTimeLimit - _answerTime), 0, _answerTimeLimit);
			float percent = 1 - Mathf.Clamp (_answerTime / _answerTimeLimit, 0, 1);

			textTime.text = leaveTime.ToString () + "'";

			timeProgress.transform.DOScaleX (percent, .1f);
		}

		private void OnAnswerChoice (IButton btn)
		{
			//Debug.Log ("choice");
			//Check Answer
			_questionIdx++;
			if (_questionIdx > 2)
				_questionIdx = 0;

			StopCountdown ();
			//Player Answer Result.
			DisableAnswer();
			ShowNextQuestion ();
		}

		private void AnswerTimeout()
		{
			ShowNextQuestion ();
		}
			
		private void ShowNextQuestion ()
		{
			FadeOutQuestion ();
			HideAnswer ();
			Invoke( "SetupQuestion" , 1 );
			Invoke ("FadeInQuestion", 1);
			Invoke ("StartAnswer", 2);
		}

		private void SetupQuestion()
		{
			//TODO 設定下一個題目.
			for (int i = 0; i < options.Count; i++) {
				//options [i].textOption.text = q.options [i];
			}
		}

		private void FadeOutQuestion ()
		{
			RectTransform rectTrans = _panelQuestoin.GetComponent<RectTransform> ();
			rectTrans.DOAnchorPos (new Vector2 (800, 0), 0.3f);
		}

		private void FadeInQuestion()
		{
			RectTransform rectTrans = _panelQuestoin.GetComponent<RectTransform> ();
			rectTrans.anchoredPosition = new Vector2 (-1000, 0);
			rectTrans.DOAnchorPos (new Vector2 (10, 0), 0.5f).SetEase (Ease.OutBack);
		}

		private void StartAnswer()
		{
			ShowAnswer ();
			StartCountdown ();
		}

		private void ShowAnswer ()
		{
			for (int i = 0; i < options.Count; i++) {
				options [i].Show ();
				options [i].Enable ();
			}
			_enableUseTool = true;
		}

		private void HideAnswer ()
		{
			for (int i = 0; i < options.Count; i++) {
				options [i].Hide ();
				options [i].Disable ();
			}
			_enableUseTool = false;
		}

		private void DisableAnswer()
		{
			for (int i = 0; i < options.Count; i++) {
				options [i].Disable ();
			}
		}

		private void EnableAnswer()
		{
			for (int i = 0; i < options.Count; i++) {
				options [i].Enable ();
			}
		}
	}
}