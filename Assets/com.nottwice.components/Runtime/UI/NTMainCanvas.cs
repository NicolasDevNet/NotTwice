using NaughtyAttributes;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NotTwice.Components.Runtime.UI
{
	/// <summary>
	/// This component uses the main canvas to detect a click on the UI
	/// </summary>
	[AddComponentMenu("NotTwice/UI/MainCanvas")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Canvas))]
	[RequireComponent(typeof(GraphicRaycaster))]
	public class NTMainCanvas : MonoBehaviour
	{
		[ReadOnly]
		public Canvas Canvas;

		[ReadOnly]
		public GraphicRaycaster GraphicRaycaster;

		[Required]
		public EventSystem EventSystem;

		public void Start()
		{
			Canvas = GetComponent<Canvas>();
			GraphicRaycaster = GetComponent<GraphicRaycaster>();
		}

		/// <summary>
		/// Method for detecting whether a user interface object is present at the position provided
		/// </summary>
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
