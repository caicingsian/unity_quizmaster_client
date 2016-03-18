using System;
using UnityEngine;
using System.Collections.Generic;
using Samurai.Extensions;
using strange.extensions.signal.impl;

namespace Samurai.UI
{
	public class UIList : MonoBehaviour, IList
	{
		public GameObject prefabListItem;
		public GameObject listContainer;
		public Signal<ListItem> onItemSelect = new Signal<ListItem> ();

		private ListCollection _dataProvier;

		public ListCollection dataProvider {
			get {
				return _dataProvier;
			}
			set {
				_dataProvier = value;
				Refresh ();
			}
		}

		private List<ListItem> _items = new List<ListItem> ();

		void Awake()
		{
			//Debug.Log (listContainer);
		}

		public UIList ()
		{
			
		}

		private void Refresh ()
		{
			ListItem item;
			int i = 0;

			for ( ; i < _dataProvier.data.Count; i++) {
				item = GetListItem (i);
				UpdateItem (item, _dataProvier.data [i]);
				item.gameObject.SetActive (true);
			}

			for ( ; i < _items.Count; i++) {
				item = GetListItem (i);
				item.gameObject.SetActive (false);
			}
		}

		private ListItem GetListItem (int index)
		{
			ListItem item;
			if (index < _items.Count) {
				item = _items [index];
			} else {
				item = GameObject.Instantiate (prefabListItem).gameObject.GetComponent<ListItem>();
				item.transform.SetParent (listContainer.transform);
				item.transform.localScale = Vector2.one;
				item.OnSelectSignal.AddListener (OnItemSelectHandler);
				_items.Add (item);
			}
			return item;
		}

		private void OnItemSelectHandler( ListItem item )
		{
			onItemSelect.Dispatch( item );
		}

		private void UpdateItem( ListItem item, object data )
		{
			item.UpdateData (data);
		}
	}
}

