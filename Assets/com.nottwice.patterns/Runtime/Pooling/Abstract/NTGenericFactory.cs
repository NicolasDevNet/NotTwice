using NaughtyAttributes;
using UnityEngine;

namespace NotTwice.Patterns.Pooling.Runtime.Abstract
{
	/// <summary>
	/// Base class for a factory, which allows you to create custom instances of an object using the <see cref="Create"/> method.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class NTGenericFactory<T> : ScriptableObject, INTGenericFactory<T>
	{
		/// <summary>
		/// Prefab used to create the pool elements
		/// </summary>
		[Tooltip("Prefab used by the factory to create elements")]
		[Required]
		public T Prefab;

		public abstract T Create();
	}
}
