using NaughtyAttributes;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotTwice.Components.Runtime.UI
{
	/// <summary>
	/// Component for changing the text value of a text component from an other source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/TMPTextValueChanger")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TMP_Text))]
	public class NTTMPTextValueChanger : MonoBehaviour
	{
        [ReadOnly]
        public TMP_Text TextComponent;

        public void Start()
        {
            TextComponent = GetComponent<TMP_Text>();
        }

        /// <summary>
        /// Method for changing the text value from <see cref="NTStringVariable"/>
        /// </summary>
        public void ChangeFromStringVariable(NTStringVariable stringVariable)
		{
			ChangeTextValue(stringVariable.Value, stringVariable.name);
		}

        /// <summary>
        /// Method for changing the text value from <see cref="Slider"/>
        /// </summary>
        public void ChangeFromSlider(Slider slider)
		{
			ChangeTextValue(slider.value.ToString(), slider.name);
		}

        /// <summary>
        /// Method for changing the text value from <see cref="int"/>
        /// </summary>
        public void ChangeFromIntValue(int value)
		{
			ChangeTextValue(value.ToString(), "Raw data"); ;
		}

		/// <summary>
		/// Method for changing the text value from <see cref="float"/>
		/// </summary>
		public void ChangeFromFloatValue(float value)
		{
			ChangeTextValue(value.ToString(), "Raw data"); ;
		}

		/// <summary>
		/// Method for changing the text value from <see cref="string"/>
		/// </summary>
		public void ChangeTextValue(string value)
		{
			Debug.Log($"New text value for component {TextComponent.name}: {value}");
			TextComponent.text = value;
		}

        /// <summary>
        /// Method for changing the text value from <see cref="string"/>
        /// </summary>
        protected void ChangeTextValue(string value, string componentName)
		{
			Debug.Log($"New text value for component {TextComponent.name}: {value} | Source: {componentName}");
			TextComponent.text = value;
		}
	}
}
