using System;
using System.Collections.Generic;

namespace Assets.com.nottwice.lifetime.Runtime
{
	/// <summary>
	/// Static instance container common to an application
	/// </summary>
	public static class AppContainer
	{
		private static Dictionary<Type, object> _registeredInstances = new Dictionary<Type, object>();

		/// <summary>
		/// Method for modifying an instance associated with a contract; if the instance does not exist, it is added.
		/// </summary>
		/// <typeparam name="TConcrete">The type of the concrete instance</typeparam>
		/// <typeparam name="TContract">The type of contract</typeparam>
		/// <param name="instance">The instance to be registered</param>
		public static void AddOrUpdate<TConcrete, TContract>(TConcrete instance)
			where TConcrete : TContract
		{
			Type contractType = typeof(TContract);

			if (!_registeredInstances.ContainsKey(contractType))
			{
				_registeredInstances.Add(contractType, instance);
			}
			else
			{
				_registeredInstances[contractType] = instance;
			}
		}

		/// <summary>
		/// Method to retrieve an instance through a contract
		/// </summary>
		/// <typeparam name="TContract">The type of the targeted contract</typeparam>
		/// <returns></returns>
		/// <exception cref="Exception">Exception thrown when contract has not been registered</exception>
		public static TContract Get<TContract>()
		{
			Type contractType = typeof(TContract);

			if (!_registeredInstances.ContainsKey(contractType))
			{
				throw new Exception($"Contract {contractType.Name} has not been registered");
			}

			return (TContract)_registeredInstances[contractType];
		}
	}
}
