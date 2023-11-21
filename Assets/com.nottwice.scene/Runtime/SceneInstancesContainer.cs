using Assets.com.nottwice.scene.Runtime.Proxies;

namespace Assets.com.nottwice
{
	/// <summary>
	/// Static instance container used for scene management
	/// </summary>
	public static partial class SceneInstancesContainer
	{
		private static ISceneManager _sceneManager;

		public static ISceneManager SceneManager
		{
			get
			{
				if(_sceneManager == null)
				{
					_sceneManager = DefaultSceneProxy.Instance;
				}

				return _sceneManager;
			}
			set
			{
				_sceneManager = value;
			}
		}
	}
}
