using UnityEngine;
using System.Collections;
using Samurai.QuizMaster.UI;
using System.Collections.Generic;
using Samurai.UI;
using DG.Tweening;
using System.Linq;
using strange.extensions.signal.impl;
using Samurai.QuizMaster;

public class ClassicGameLevelController : CommonPanel
{
	public Signal<LevelVO> onLevelSelectSignal = new Signal<LevelVO> ();


	public GameObject pageSubject;
	public GameObject pageQuestion;

	public CommonButton btnQuestionPageBack;
	
	public UIList subjectList;
	public UIList questionList;

	void Awake ()
	{
		
	}
		
	void Start ()
	{
		btnQuestionPageBack.OnClick.AddListener (OnQuestionPageBackHandler);
	}

	public void InitLevelData (List<SubjectVO> subjects)
	{
		ListCollection lc = new ListCollection ();
		lc.data = subjects.Cast<object> ().ToList ();
		subjectList.onItemSelect.AddListener (OnSubjectButtonClick);
		subjectList.dataProvider = lc;
		//throw new System.NotImplementedException ();
	}

	private void OnQuestionPageBackHandler (IButton btn)
	{
		//Debug.Log ("back");
		RectTransform trans = pageQuestion.GetComponent<RectTransform> ();
		trans.DOAnchorPos (new Vector2 (-720, 0), 0.5f);

		trans = pageSubject.GetComponent<RectTransform> ();
		trans.gameObject.SetActive (true);
		trans.anchoredPosition = new Vector2 (720, 0);
		trans.DOAnchorPos (new Vector2 (0, 0), 0.5f);
	}

	private void OnSubjectButtonClick (ListItem item)
	{
		//Debug.Log (item.Data);
		//onLevelSelectSignal.Dispatch (null);
		//return;

		RectTransform trans = pageSubject.GetComponent<RectTransform> ();
		trans.DOAnchorPos (new Vector2 (-720, 0), 0.5f);

		trans = pageQuestion.GetComponent<RectTransform> ();
		trans.gameObject.SetActive (true);
		trans.anchoredPosition = new Vector2 (720, 0);
		trans.DOAnchorPos (new Vector2 (0, 0), 0.5f);

		List<int> d2 = new List<int> ();
		int r = Random.Range (2, 10);
		for (int i = 0; i < r; i++) {
			d2.Add (i);
		}

		ListCollection lc2 = new ListCollection ();
		lc2.data = d2.Cast<object> ().ToList ();

		questionList.onItemSelect.AddListener (OnQuestionButtonClick);
		questionList.dataProvider = lc2;

		//pages [_curtPageIndex].DOAnchorPos (new Vector2 (-720, 0), 0.5f);
		//pages [idx].gameObject.SetActive (true);
		//pages [idx].anchoredPosition = new Vector2 (720, 0);
		//pages [idx].DOAnchorPos (new Vector2 (0, 0), 0.5f);
	}

	private void OnQuestionButtonClick (ListItem item)
	{
		//Debug.Log (item + "," + item.Data);
		onLevelSelectSignal.Dispatch ( item.Data as LevelVO );
	}

	private void ShowQuestionPage ()
	{
		
	}

	private void ShowSubjectPage ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
