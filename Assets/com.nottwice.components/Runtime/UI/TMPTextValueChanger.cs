using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.components.Runtime.UI
{
	/// <summary>
	/// Component for changing the text value of a text component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/TMPTextValueChanger")]
	[DisallowMultipleComponent]
	public class TMPTextValueChanger : MonoBehaviour
	{
		public TMP_Text TextComponent;

		public void ChangeFromStringVariable(NTStringVariable stringVariable)
		{
			ChangeTextValue(stringVariable.Value, stringVariable.name);
		}

		public void ChangeFromSlider(Slider slider)
		{
			ChangeTextValue(slider.value.ToString(), slider.name);
		}

		public void ChangeFromIntValue(int value)
		{
			ChangeTextValue(value.ToString(), "Raw data"); ;
		}

		public void ChangeTextValue(string value)
		{
			Debug.Log($"New text value for component {TextComponent.name}: {value}");
			TextComponent.text = value;
		}

		protected void ChangeTextValue(string value, string componentName)
		{
			Debug.Log($"New text value for component {TextComponent.name}: {value} | Source: {componentName}");
			TextComponent.text = value;
		}
	}
}
