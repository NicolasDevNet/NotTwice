using System;
using System.Collections.Generic;
using UnityEngine;

namespace NotTwice.Patterns.DependancyRegistration.Runtime
{
	[CreateAssetMenu(fileName = "DependancyContainer", menuName = "NotTwice/Patterns/DependancyRegistration/DependancyContainer")]
	public class NTDependancyContainer : ScriptableObject
	{
		private Dictionary<Type, ScriptableObject> _services = new Dictionary<Type, ScriptableObject>();

		// Enregistrer un service dans le conteneur
		public void RegisterService<T>(T service) where T : ScriptableObject
		{
			Type type = typeof(T);

			if (!_services.ContainsKey(type))
			{
				_services[type] = service;
			}
		}

		// Récupérer un service depuis le conteneur
		public T GetService<T>() where T : ScriptableObject
		{
			Type type = typeof(T);

			if (_services.ContainsKey(type))
			{
				return _services[type] as T;
			}

			Debug.LogError($"Service {type} not found.");

			return null;
		}

		public void Clear()
		{
			_services.Clear();
		}
	}
}
