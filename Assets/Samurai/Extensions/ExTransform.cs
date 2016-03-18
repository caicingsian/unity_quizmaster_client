using System;
using UnityEngine;

namespace Samurai.Extensions
{
	public static class ExTransform
	{
		public static GameObject GetChildByName(this Transform transform, string name)
		{
			if (transform == null)
				return null;
			
			if (transform.name == name)
				return transform.gameObject;

			foreach (Transform child in transform) {
				if (child.name == name)
					return child.gameObject;
			}
				
			foreach (Transform child in transform) {
				if (child.childCount > 0) {
					GameObject go = child.GetChildByName (name);
					if (go != null)
						return go;
				}
			}

			return null;
		}
	}
}