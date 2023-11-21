using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.ui.Runtime.Components
{
	/// <summary>
	/// Component for changing the text value of a text component from the value of another component
	/// </summary>
	[AddComponentMenu("NotTwice/UI/TextChanger")]
	[DisallowMultipleComponent]
	public class TextChanger : MonoBehaviour
	{
		public TMP_Text TextComponent;

		public void ChangeFromSlider(Slider slider)
		{
			ChangeTextValue(slider.value.ToString(), slider.name);
		}

		protected void ChangeTextValue(string value, string componentName)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"New text value for component {TextComponent.name}: {value} | Source: {componentName}");
			TextComponent.text = value;
		}
	}
}
