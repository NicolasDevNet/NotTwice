using UnityEngine;
using System.Collections.Generic;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables;
using Assets.com.nottwice.lifetime.Runtime;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component for subscribing to reactive variables
	/// </summary>
	[AddComponentMenu("NotTwice/Events/ReactiveVariableListener")]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(12)]
	public class ReactiveVariableListener : MonoBehaviour
	{
		public List<ReactiveVariableEvent> ReactiveVariableEvents = new List<ReactiveVariableEvent>();

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void OnEnable()
		{
			foreach(ReactiveVariableEvent ev in ReactiveVariableEvents)
			{
				ev.Subscribe();
				_logger.Log(LogType.Log, $"Subscribe to {ev.name}");
			}
		}

		public void OnDisable()
		{
			foreach (ReactiveVariableEvent ev in ReactiveVariableEvents)
			{
				ev.UnSubscribe();
				_logger.Log(LogType.Log, $"UnSubscribe from {ev.name}");
			}
		}
	}
}
