using NaughtyAttributes;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using TMPro;
using UnityEngine;

namespace NotTwice.Components.Runtime.UI
{
	/// <summary>
	/// Component for changing the dropdown value from another source
	/// </summary>
	[AddComponentMenu("NotTwice/UI/TMPDropdownValueChanger")]
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TMP_Dropdown))]
	public class NTTMPDropdownValueChanger : MonoBehaviour
	{
		[ReadOnly]
		public TMP_Dropdown DropdownComponent;

        public void Start()
        {
            DropdownComponent = GetComponent<TMP_Dropdown>();
        }

        /// <summary>
        /// Method for modifying the value of a drop-down list from an int variable
        /// </summary>
        public void ChangeFromIntVariable(NTInt32Variable int32Variable)
		{
			ChangeDropdownValue(int32Variable.Value, int32Variable.name);
		}

        /// <summary>
        /// Method for modifying the value of a drop-down list from an int variable
        /// </summary>
        protected void ChangeDropdownValue(int value, string componentName)
		{
			Debug.Log($"New value for component {DropdownComponent.name}: {value} | Source: {componentName}");

			DropdownComponent.value = value;
			DropdownComponent.RefreshShownValue();
		}
	}
}
