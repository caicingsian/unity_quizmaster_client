using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using strange.extensions.signal.impl;

namespace Samurai.UI
{
	public class UIButton : MonoBehaviour, IButton
	{
		protected Signal<IButton> _onClickSignal = new Signal<IButton> ();

		protected bool _enabled = true;

		virtual protected void Awake ()
		{
			
		}

		public Signal<IButton> OnClick {
			get {
				return _onClickSignal;
			}
		}

		virtual public bool enable {
			get {
				return _enabled;
			}
			set {
				_enabled = value;
			}
		}

		virtual protected void OnButtonClick ()
		{
			if (!_enabled)
				return;

			_onClickSignal.Dispatch (this);
		}
	}
}