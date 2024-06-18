using NaughtyAttributes;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using UnityEngine;
using UnityEngine.UI;

namespace NotTwice.Components.Runtime.UI
{
	/// <summary>
	/// Component for changing the slider value from another source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/SliderValueChanger")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Slider))]
	public class NTSliderValueChanger : MonoBehaviour
	{
		[ReadOnly]
		public Slider SliderComponent;

		public void Start()
		{
			SliderComponent = GetComponent<Slider>();
		}

		/// <summary>
		/// Méthode permettant de changer la valeur d'un slider à partir de <see cref="NTInt32Variable"/>
		/// </summary>
		public void ChangeFromIntVariable(NTInt32Variable int32Variable)
		{
			ChangeDropdownValue(int32Variable.Value, int32Variable.name);
		}

        /// <summary>
        /// Méthode permettant de changer la valeur d'un slider à partir de <see cref="NTFloatVariable"/>
        /// </summary>
        public void ChangeFromIntVariable(NTFloatVariable floatVariable)
		{
			ChangeDropdownValue(floatVariable.Value, floatVariable.name);
		}

        /// <summary>
        /// Méthode permettant de changer la valeur d'un slider à partir de <see cref="float"/>
        /// </summary>
        protected void ChangeDropdownValue(float value, string componentName)
		{
			Debug.Log($"New value for component {SliderComponent.name}: {value} | Source: {componentName}");

			SliderComponent.value = value;
		}
	}
}
