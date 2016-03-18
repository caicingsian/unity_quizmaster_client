using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Samurai.QuizMaster.UI;
using Samurai.UI;

public class PageIndicator : MonoBehaviour 
{
	public List<RectTransform> pages;
	public List<CommonButton> btns;

	private int _curtPageIndex = 0;

	void Awake(){
		for (int i = 0; i < btns.Count; i++) {
			CommonButton btn = btns [i];
			if (btn != null)
				btn.OnClick.AddListener (OnBtnClick);
		}
	}

	private void OnBtnClick( IButton btn ){

		CommonButton tmpBtn = (CommonButton)btn;
		int idx = btns.IndexOf ( tmpBtn );
		ChangePage (idx);
	}

	public void ChangePage(int idx)
	{
		if (idx < 0 || idx >= pages.Count || _curtPageIndex == idx )
			return;

		pages [_curtPageIndex].DOAnchorPos (new Vector2 (-720, 0), 0.5f);

		pages [idx].gameObject.SetActive (true);
		pages [idx].anchoredPosition = new Vector2 (720, 0);

		pages [idx].DOAnchorPos (new Vector2 (0, 0), 0.5f);

		_curtPageIndex = idx;
	}
}
