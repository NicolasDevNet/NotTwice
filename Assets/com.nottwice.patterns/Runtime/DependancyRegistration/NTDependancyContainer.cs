using System;
using System.Collections.Generic;
using UnityEngine;

namespace NotTwice.Patterns.DependancyRegistration.Runtime
{
	[CreateAssetMenu(fileName = "DependancyContainer", menuName = "NotTwice/Patterns/DependancyRegistration/DependancyContainer")]
	public class NTDependancyContainer : ScriptableObject
	{
		// Stocke une seule instance de chaque service
		private Dictionary<Type, ScriptableObject> _serviceInstances = new Dictionary<Type, ScriptableObject>();

		// Mappe les interfaces et types vers les instances de service
		private Dictionary<Type, Type> _typeMappings = new Dictionary<Type, Type>();

		// Enregistre un ScriptableObject sous son type concret et ses interfaces
		public void RegisterService(ScriptableObject service)
		{
			var serviceType = service.GetType();

			// Enregistrer l'instance sous son type concret si elle n'est pas déjà présente
			if (!_serviceInstances.ContainsKey(serviceType))
			{
				_serviceInstances[serviceType] = service;
				Debug.Log($"Service of concrete type {serviceType} registered");
			}
			else
			{
				Debug.LogWarning($"Service of type {serviceType} is already registered.");
			}

			// Enregistrer les mappings pour les interfaces vers le type concret
			var interfaces = serviceType.GetInterfaces();
			foreach (var interfaceType in interfaces)
			{
				if (!_typeMappings.ContainsKey(interfaceType))
				{
					_typeMappings[interfaceType] = serviceType;
					Debug.Log($"Mapping of contract type {interfaceType} registered");
				}
			}
		}

		// Récupère un service par type générique (interface ou type concret)
		public T GetService<T>() where T : class
		{
			var requestedType = typeof(T);

			// Si le type est enregistré directement (cas du type concret)
			if (_serviceInstances.TryGetValue(requestedType, out var service))
			{
				return service as T;
			}

			// Si le type est une interface ou une classe de base
			if (_typeMappings.TryGetValue(requestedType, out var concreteType))
			{
				if (_serviceInstances.TryGetValue(concreteType, out service))
				{
					return service as T;
				}
			}

			throw new Exception($"Service of type {requestedType} not found");
		}

		// Récupère un service par un type spécifique (interface ou type concret)
		public ScriptableObject GetService(Type requestedType)
		{
			// Si le type est enregistré directement
			if (_serviceInstances.TryGetValue(requestedType, out var service))
			{
				return service;
			}

			// Si le type est une interface ou une classe de base
			if (_typeMappings.TryGetValue(requestedType, out var concreteType))
			{
				if (_serviceInstances.TryGetValue(concreteType, out service))
				{
					return service;
				}
			}

			throw new Exception($"Service of type {requestedType} not found");
		}

		public void Clear()
		{
			_serviceInstances.Clear();
			_typeMappings.Clear();
		}
	}
}
