using UnityEngine;

namespace NotTwice.Scene.Runtime.Abstract
{
	/// <summary>
	/// Basic scriptable class for a stage management progress manager
	/// </summary>
	public abstract class NTBaseSceneProgressHandler : ScriptableObject
	{
		public abstract void OnProgress(float progress);
	}
}
