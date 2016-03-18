using UnityEngine;
using System.Collections;
using Samurai.QuizMaster.UI;
using Samurai.UI;

public class QuestionListItem : ListItem {

	private CommonButton _btn;

	void Start ()
	{
		_btn = this.GetComponentInChildren<CommonButton> ();
		_btn.OnClick.AddListener (OnClick);
	}

	private void OnClick ( IButton btn )
	{
		OnSelectSignal.Dispatch (this);
	}
}
