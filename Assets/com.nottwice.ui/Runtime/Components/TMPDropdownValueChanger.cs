using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using TMPro;
using UnityEngine;

namespace Assets.com.nottwice.ui.Runtime.Components
{
	/// <summary>
	/// Component for changing the dropdown value from another source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/TMPDropdownValueChanger")]
	[DisallowMultipleComponent]
	public class TMPDropdownValueChanger : MonoBehaviour
	{
		public TMP_Dropdown DropdownComponent;

		public void ChangeFromIntVariable(Int32Variable int32Variable)
		{
			ChangeDropdownValue(int32Variable.Value, int32Variable.name);
		}

		protected void ChangeDropdownValue(int value, string componentName)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"New value for component {DropdownComponent.name}: {value} | Source: {componentName}");

			DropdownComponent.value = value;
			DropdownComponent.RefreshShownValue();
		}
	}
}
