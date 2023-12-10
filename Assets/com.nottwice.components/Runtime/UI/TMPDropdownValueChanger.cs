using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
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

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void ChangeFromIntVariable(Int32Variable int32Variable)
		{
			ChangeDropdownValue(int32Variable.Value, int32Variable.name);
		}

		protected void ChangeDropdownValue(int value, string componentName)
		{
			_logger.Log(LogType.Log, $"New value for component {DropdownComponent.name}: {value} | Source: {componentName}");

			DropdownComponent.value = value;
			DropdownComponent.RefreshShownValue();
		}
	}
}
