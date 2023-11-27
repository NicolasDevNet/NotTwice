using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.com.nottwice.ui.Runtime.Components
{
	/// <summary>
	/// Component for changing the slider value from another source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/SliderValueChanger")]
	[DisallowMultipleComponent]
	public class SliderValueChanger : MonoBehaviour
	{
		public Slider SliderComponent;

		public void ChangeFromIntVariable(Int32Variable int32Variable)
		{
			ChangeDropdownValue(int32Variable.Value, int32Variable.name);
		}

		public void ChangeFromIntVariable(FloatVariable floatVariable)
		{
			ChangeDropdownValue(floatVariable.Value, floatVariable.name);
		}

		protected void ChangeDropdownValue(float value, string componentName)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"New value for component {SliderComponent.name}: {value} | Source: {componentName}");

			SliderComponent.value = value;
		}
	}
}
