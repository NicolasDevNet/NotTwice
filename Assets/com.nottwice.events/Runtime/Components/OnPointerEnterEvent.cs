﻿using Assets.com.nottwice.events.Runtime.ScriptableObjects;
using UnityEngine.EventSystems;
using UnityEngine;
using NaughtyAttributes;
using Assets.com.nottwice.lifetime.Runtime;

namespace Assets.com.nottwice.events.Runtime.Components
{
	/// <summary>
	/// Component to trigger a GameEvent when a PointerEnter event is detected.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/OnPointerEnterEvent")]
	public class OnPointerEnterEvent : MonoBehaviour, IPointerEnterHandler
	{
		[Required, Tooltip("Event to register with.")]
		public GameEvent Event;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_logger.Log(LogType.Log, $"Pointer enter on {name}");
			Event.Raise();
		}
	}
}
