using System;
using UnityEngine.UI;
using UnityEngine;
using Samurai.Extensions;
using Samurai.QuizMaster.UI;
using System.Collections;
using Samurai.UI;

namespace Samurai.QuizMaster
{

	public class SceneHome : SceneCommon
	{
		[HideInInspector]
		public CommonButton btnPlayClassic;

		public CommonButton btnPlayerProfile;
		public PopupWindow popupPlayerProfile;

		protected override void Awake ()
		{
			base.Awake ();
			btnPlayClassic = transform.GetChildByName ("ButtonPlayClassic").GetComponent<CommonButton> ();
			if( btnPlayerProfile != null ) btnPlayerProfile.OnClick.AddListener( OnShowPlayerProfile );
		}

		private void OnShowPlayerProfile( IButton btn )
		{
			if (popupPlayerProfile != null)
				popupPlayerProfile.Show ();
		}
	}
}