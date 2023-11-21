using UnityEngine;

namespace Assets.com.nottwice.application.Runtime.Components
{
	/// <summary>
	/// Component used to exit the application.
	/// </summary>
	[AddComponentMenu("NotTwice/Application/QuitApplication")]
	[DisallowMultipleComponent]
	public class QuitApplication : MonoBehaviour
	{
		public void ExecuteQuitApplication()
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log ,"Try to quit application");
			ApplicationInstancesContainer.Application.Quit();
		}
	}
}
