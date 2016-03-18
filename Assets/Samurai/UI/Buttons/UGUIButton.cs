using System;
using UnityEngine.UI;
using UnityEngine;

namespace Samurai.UI
{
	[RequireComponent(typeof(Button))]
	public class UGUIButton : UIButton
	{
		protected Button _btn;

		override protected void Awake ()
		{
			base.Awake ();
			_btn = GetComponent<Button> ();
			_btn.onClick.AddListener (OnButtonClick);
		}

		public override bool enable {
			get {
				return base.enable;
			}
			set {
				base.enable = value;
				_btn.interactable = value;
			}
		}
	}
}

