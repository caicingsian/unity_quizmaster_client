using UnityEngine;
using System.Collections;
using strange.extensions.signal.impl;

public class ListItem : MonoBehaviour {

	public Signal<ListItem> OnSelectSignal = new Signal<ListItem> ();

	private object _data;
	public object Data{ get { return _data; } }

	virtual public void UpdateData( object data )
	{
		_data = data;
	}
}
