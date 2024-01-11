using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.com.nottwice.components.Runtime.UI
{
	/// <summary>
	/// This component uses the main canvas to detect a click on the UI
	/// </summary>
	[AddComponentMenu("NotTwice/UI/MainCanvas")]
	[DisallowMultipleComponent]
	public class MainCanvas : MonoBehaviour
	{
		[Required]
		public Canvas Canvas;

		[Required]
		public GraphicRaycaster GraphicRaycaster;

		[Required]
		public EventSystem EventSystem;

		public bool UIObjectDetected(Vector2 position)
		{
			var pointerEvent = new PointerEventData(EventSystem);
			pointerEvent.position = position;
			List<RaycastResult> results = new List<RaycastResult>();

			//Raycast using the Graphics Raycaster and mouse click position
			GraphicRaycaster.Raycast(pointerEvent, results);

			//For every result returned, output the name of the GameObject on the Canvas hit by the Ray
			return results.Count > 0;
		}
	}
}
