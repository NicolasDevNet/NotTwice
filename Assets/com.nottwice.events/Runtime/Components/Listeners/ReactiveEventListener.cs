using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using Assets.com.nottwice.lifetime.Runtime;
using NaughtyAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables;
using UniRx;

namespace Assets.com.nottwice.events.Runtime.Components.Listeners
{
	public abstract class ReactiveEventListener<T, U> : MonoBehaviour
		where T : ReactiveProperty<U>
	{
		[Required, Tooltip("Event to register with.")]
		public ReactiveVariableEvent<T, U> VariableEvent;

		[Tooltip("Response to invoke when Event is raised.")]
		public UnityEvent<U> Response;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		protected void OnEnable()
		{
			VariableEvent.BoundEvent.RegisterListener(this);
		}

		protected void OnDisable()
		{
			VariableEvent.BoundEvent.UnregisterListener(this);
		}

		public void OnEventRaised(U value)
		{
			_logger.Log(LogType.Log, $"Event raise: {VariableEvent.BoundEvent.name}");
			Response?.Invoke(value);
		}
	}
}
