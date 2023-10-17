using Assets.NotTwice.Tools.Runtime.Components.Events;

namespace Assets.NotTwice.Tools.PlayModeTests.Runtime.Components.Events
{
	internal class FakeGameEventListener : GameEventListener
	{
		public new void OnEnable()
		{
			base.OnEnable();
		}

		public new void OnDisable()
		{
			base.OnDisable();
		}
	}
}
