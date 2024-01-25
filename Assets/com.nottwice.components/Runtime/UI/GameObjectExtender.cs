using System.Collections.Generic;
using UnityEngine;

namespace Assets.com.nottwice.components.Runtime.UI
{
	[AddComponentMenu("NotTwice/UI/GameObjectExtender")]
	[DisallowMultipleComponent]
	public class GameObjectExtender : MonoBehaviour
	{
		public void ClearChildren()
		{
			var children = new List<GameObject>();

			foreach (Transform child in transform)
			{
				children.Add(child.gameObject);
			}

			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
		}
	}
}
