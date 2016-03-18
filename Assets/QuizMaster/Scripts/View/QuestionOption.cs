using UnityEngine;
using System.Collections;
using Samurai.QuizMaster;
using Samurai.QuizMaster.UI;
using UnityEngine.UI;

public class QuestionOption : MonoBehaviour 
{
	public CommonButton btn;
	public Text textOption;

	void Awake()
	{
		//btn = GetComponent<CommonButton> ();
		//textOption = GetComponentInChildren<Text> ();
	}

	public void Hide()
	{
		gameObject.SetActive (false);
	}

	public void Show()
	{
		gameObject.SetActive (true);
	}

	public void Disable()
	{
		btn.enable = false;
	}

	public void Enable()
	{
		btn.enable = true;
	}
}
