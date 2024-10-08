﻿using NaughtyAttributes;
using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.Serializables.Abstract
{
	/// <summary>
	/// Classe de base permettant à celles qui l'implémente de choisir entre un évènement
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <typeparam name="U"></typeparam>
	public abstract class NTBaseEventTypeSwitcher<T> : MonoBehaviour
		where T : NTBaseGameEvent<T, UnityEvent>
	{
		/// <summary>
		/// Defines whether a Unity event is to be used
		/// </summary>
		[Tooltip("Defines whether a Unity event is to be used") ,OnValueChanged(nameof(OnUseUnityEventChanged))]
		public bool UseUnityEvent;

		/// <summary>
		/// Defines whether a Game event is to be used
		/// </summary>
		[Tooltip("Defines whether a Game event is to be used") , OnValueChanged(nameof(OnUseGameEventChanged))]
		public bool UseGameEvent;

		/// <summary>
		/// The scriptable event object to use
		/// </summary>
		[Tooltip("The scriptable event object to use"), ShowIf(nameof(UseGameEvent))]
		public T GameEvent;

		/// <summary>
		/// The unity event to use
		/// </summary>
		[Tooltip("The unity event to use"), ShowIf(nameof(UseUnityEvent))]
		public UnityEvent UnityEvent;

		public void Raise()
		{
			if(UseUnityEvent)
			{
				Debug.Log($"UnityEvent triggered from  {name}");
				UnityEvent?.Invoke();
			}
			else
			{
				Debug.Log($"GameEvent: {GameEvent.name} triggered from {name}");
				GameEvent?.Raise();
			}
		}

		private void OnUseGameEventChanged()
		{
			if (UseGameEvent)
			{
				UseUnityEvent = false;
			}
		}

		private void OnUseUnityEventChanged()
		{
			if (UseUnityEvent)
			{
				UseGameEvent = false;
			}
		}
	}
}
