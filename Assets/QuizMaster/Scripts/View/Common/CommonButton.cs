using UnityEngine;
using System.Collections;
using Samurai.UI;

namespace Samurai.QuizMaster.UI
{
	public class CommonButton : UGUIButton
	{
		protected override void OnButtonClick ()
		{
			base.OnButtonClick ();
			SoundManager.PlaySound (SoundNames.SND_BUTTON_CLICK);
		}
	}
}