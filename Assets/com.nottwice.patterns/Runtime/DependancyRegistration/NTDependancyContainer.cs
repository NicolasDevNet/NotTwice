using System;
using System.Collections.Generic;
using UnityEngine;

namespace NotTwice.Patterns.DependancyRegistration.Runtime
{
	[CreateAssetMenu(fileName = "DependancyContainer", menuName = "NotTwice/Patterns/DependancyRegistration/DependancyContainer")]
	public class NTDependancyContainer : ScriptableObject
	{
		private Dictionary<Type, ScriptableObject> _services = new Dictionary<Type, ScriptableObject>();

		public void RegisterService<T>(T service) where T : ScriptableObject
		{
			_services[typeof(T)] = service;
		}

		public T GetService<T>() where T : class
		{
			if (_services.TryGetValue(typeof(T), out var service))
			{
				return service as T;
			}

			throw new System.Exception($"Service of type {typeof(T)} not found");
		}

		public void Clear()
		{
			_services.Clear();
		}
	}
}
