using UnityEngine;

namespace Assets.Tests.PlayMode
{
	public static class DisabledComponentsFactory
	{
		public static T Create<T>()
			where T : Component
		{
			GameObject componentParent = new GameObject();
			componentParent.SetActive(false);

			return componentParent.AddComponent<T>();
		}
	}
}
