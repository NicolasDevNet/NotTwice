using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.components.Runtime.UI
{
	/// <summary>
	/// This component locks a slider so that it can only be operated by clicking on the appropriate area.
	/// </summary>
	[AddComponentMenu("NotTwice/UI/OnReleasePointerSlider")]
	[DisallowMultipleComponent]
	public class OnReleasePointerSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		private Slider internalSlider;
		private bool _isPointerDown = false;

		void Start()
		{
			internalSlider = GetComponent<Slider>();
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_isPointerDown = true;
			internalSlider.interactable = false;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_isPointerDown = false;
			internalSlider.interactable = true;
		}

		void Update()
		{
			if (_isPointerDown)
			{
				float mouseAxis = Input.GetAxis("Mouse X");
				internalSlider.value += mouseAxis * Time.deltaTime;
			}
		}
	}
}
