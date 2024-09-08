using UnityEngine;
using UnityEngine.Pool;

namespace NotTwice.Patterns.Pooling.Runtime.Abstract
{
	public interface INTGenericPool<U> where U : MonoBehaviour
	{
		int CountInactive { get; }

		void Clear();
		U Get();
		PooledObject<U> Get(out U item);
		void InitializePool();
		void Release(U element);
	}
}