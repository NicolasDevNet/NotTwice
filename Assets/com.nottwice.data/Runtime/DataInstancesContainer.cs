using Assets.com.nottwice.data.Runtime.Proxies;

namespace Assets.com.nottwice.data.Runtime
{
	public static class DataInstancesContainer
	{
		private static IPlayerPrefs _playerPrefs;

		public static IPlayerPrefs PlayerPrefs
		{
			get
			{
				if (_playerPrefs == null)
				{
					_playerPrefs = DefaultPlayerPrefsProxy.Instance;
				}

				return _playerPrefs;
			}
			set
			{
				_playerPrefs = value;
			}
		}
	}
}
