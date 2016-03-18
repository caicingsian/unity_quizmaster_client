using UnityEngine;
using System.Collections;
using Samurai.Extensions;

namespace Samurai.UI
{
	[RequireComponent (typeof(CanvasGroup))]
	public class Panel : MonoBehaviour, IPanel
	{

		protected bool _opended = false;
		protected RectTransform _rectTransform;
		protected CanvasGroup _canvasGroup;

		protected UIButton _btnClose;

		virtual protected void Awake ()
		{
			_rectTransform = GetComponent<RectTransform> ();
			_canvasGroup = GetComponent<CanvasGroup> ();
			InitCloseButton ();
		}

		virtual protected void InitCloseButton ()
		{	
			GameObject go = transform.GetChildByName ("ButtonClose");
			if (go == null)
				return;
			
			_btnClose = go.GetComponent<UIButton> ();
			_btnClose.OnClick.AddListener (OnCloseClick);
		}

		protected void OnCloseClick (IButton btn)
		{
			Hide ();
		}

		public void Show ()
		{
			_opended = true;
			PanelShow ();
		}

		public void Hide ()
		{
			_opended = false;
			PanelHide ();
		}

		public void Toggle ()
		{
			if (_opended)
				Hide ();
			else
				Show ();
		}

		public bool opened {
			get {
				return _opended;
			}
		}

		virtual protected void PanelShow ()
		{
			gameObject.SetActive (true);
		}

		virtual protected void PanelHide ()
		{
			gameObject.SetActive (false);
		}

		virtual protected void OnDestory ()
		{
			
		}
	}
}

