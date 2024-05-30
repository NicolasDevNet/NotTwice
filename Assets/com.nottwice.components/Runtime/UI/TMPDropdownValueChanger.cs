using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using TMPro;
using UnityEngine;

namespace Assets.com.nottwice.components.Runtime.UI
{
	/// <summary>
	/// Component for changing the dropdown value from another source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/TMPDropdownValueChanger")]
	[DisallowMultipleComponent]
	public class TMPDropdownValueChanger : MonoBehaviour
	{
		public TMP_Dropdown DropdownComponent;

		public void ChangeFromIntVariable(NTInt32Variable int32Variable)
		{
			ChangeDropdownValue(int32Variable.Value, int32Variable.name);
		}

		protected void ChangeDropdownValue(int value, string componentName)
		{
			Debug.Log($"New value for component {DropdownComponent.name}: {value} | Source: {componentName}");

			DropdownComponent.value = value;
			DropdownComponent.RefreshShownValue();
		}
	}
}
