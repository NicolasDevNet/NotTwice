using UnityEngine;
using System.Collections.Generic;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component for subscribing to reactive variables
	/// </summary>
	[AddComponentMenu("NotTwice/Events/ReactiveVariableListener")]
	[DisallowMultipleComponent]
	public class ReactiveVariableListener : MonoBehaviour
	{
		public List<ReactiveVariableEvent> ReactiveVariableEvents = new List<ReactiveVariableEvent>();

		public void OnEnable()
		{
			foreach(ReactiveVariableEvent ev in ReactiveVariableEvents)
			{
				ev.Subscribe();
				ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Subscribe to {ev.name}");
			}
		}

		public void OnDisable()
		{
			foreach (ReactiveVariableEvent ev in ReactiveVariableEvents)
			{
				ev.UnSubscribe();
				ApplicationInstancesContainer.Logger.Log(LogType.Log, $"UnSubscribe from {ev.name}");
			}
		}
	}
}
