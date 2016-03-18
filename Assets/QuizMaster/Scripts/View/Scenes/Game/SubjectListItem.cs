using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;
using Samurai.QuizMaster.UI;
using Samurai.UI;
using Samurai.QuizMaster;

public class SubjectListItem : ListItem
{
	private CommonButton _btn;
	private UIText _label;

	void Awake()
	{
		_btn = this.GetComponentInChildren<CommonButton> ();
		_btn.OnClick.AddListener (OnClick);

		_label = this.GetComponentInChildren <UIText>();
	}

	private void OnClick ( IButton btn )
	{
		OnSelectSignal.Dispatch (this);
	}

	public override void UpdateData (object data)
	{
		base.UpdateData (data);
		SubjectVO vo = data as SubjectVO;
		_label.text = vo.title;
	}
}
