using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.components.Runtime.UI
{
	/// <summary>
	/// Component for changing the slider value from another source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/SliderValueChanger")]
	[DisallowMultipleComponent]
	public class SliderValueChanger : MonoBehaviour
	{
		public Slider SliderComponent;

		public void ChangeFromIntVariable(NTInt32Variable int32Variable)
		{
			ChangeDropdownValue(int32Variable.Value, int32Variable.name);
		}

		public void ChangeFromIntVariable(NTFloatVariable floatVariable)
		{
			ChangeDropdownValue(floatVariable.Value, floatVariable.name);
		}

		protected void ChangeDropdownValue(float value, string componentName)
		{
			Debug.Log($"New value for component {SliderComponent.name}: {value} | Source: {componentName}");

			SliderComponent.value = value;
		}
	}
}
