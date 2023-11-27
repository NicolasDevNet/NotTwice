using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.ui.Runtime.Components
{
	/// <summary>
	/// Component for changing the text value of a text component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/TMPTextValueChanger")]
	[DisallowMultipleComponent]
	public class TMPTextValueChanger : MonoBehaviour
	{
		public TMP_Text TextComponent;

		public void ChangeFromStringVariable(StringVariable stringVariable)
		{
			ChangeTextValue(stringVariable.Value, stringVariable.name);
		}

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
