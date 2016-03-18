using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using Samurai.Extensions;

namespace Samurai.UI
{
	public class PopupWindow : Panel
	{
		protected GameObject _modalImage;
		protected bool _enableModal = true;

		virtual protected void Awake ()
		{
			base.Awake ();
			_modalImage = transform.GetChildByName ("ModalImage");
			_modalImage.SetActive (false);
		}

		protected override void PanelShow ()
		{
			this.gameObject.SetActive (true);

			if (_enableModal) {
				_canvasGroup.blocksRaycasts = true;
			}

			_rectTransform.localScale = new Vector3 (0.2f, 0.2f, 1);
			_rectTransform.DOScale (new Vector3 (1, 1, 1), 0.3f)
				.SetEase (Ease.OutBack)
				.OnComplete (OnPanelShowDone);
		}

		protected void OnPanelShowDone ()
		{
			if (_enableModal) {
				_modalImage.SetActive (true);
			}
		}

		protected override void PanelHide ()
		{
			if (_enableModal) {
				_modalImage.SetActive (false);
			}

			_rectTransform.DOScale (new Vector3 (0.2f, 0.2f, 1), 0.3f)
				.SetEase (Ease.InBack)
				.OnComplete (OnPanelHideDone);
		}

		protected void OnPanelHideDone ()
		{
			this.gameObject.SetActive (false);
			_canvasGroup.blocksRaycasts = false;
		}
	}
}
