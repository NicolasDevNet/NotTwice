using NotTwice.Proxies.Runtime.Interfaces;

namespace NotTwice.Proxies.Runtime
{
    /// <summary>
    /// Static class providing access to singleton proxies
    /// </summary>
    public static partial class NTProxiesProvider
	{
        private static INTPlayerPrefs _playerPrefsInternal;

        /// <summary>
        /// Static instance of an interface implementation <see cref="INTPlayerPrefs"/>.
        /// </summary>
        public static INTPlayerPrefs PlayerPrefs
        {
            get
            {
                if (_playerPrefsInternal == null)
                {
                    _playerPrefsInternal = new NTPlayerPrefsProxy();
                }

                return _playerPrefsInternal;
            }
            set
            {
                _playerPrefsInternal = value;
            }
        }

        private static INTFile _fileInternal;

        /// <summary>
        /// Static instance of an interface implementation <see cref="INTFile"/>.
        /// </summary>
        public static INTFile File
        {
            get
            {
                if (_fileInternal == null)
                {
                    _fileInternal = new NTFileProxy();
                }

                return _fileInternal;
            }
            set
            {
                _fileInternal = value;
            }
        }

        private static INTPath _pathInternal;

        /// <summary>
        /// Static instance of an interface implementation <see cref="INTPath"/>.
        /// </summary>
        public static INTPath Path
        {
            get
            {
                if (_pathInternal == null)
                {
                    _pathInternal = new NTPathProxy();
                }

                return _pathInternal;
            }
            set
            {
                _pathInternal = value;
            }
        }

        private static INTDirectory _directoryInternal;

        /// <summary>
        /// Static instance of an interface implementation <see cref="INTDirectory"/>.
        /// </summary>
        public static INTDirectory Directory
        {
            get
            {
                if (_directoryInternal == null)
                {
                    _directoryInternal = new NTDirectoryProxy();
                }

                return _directoryInternal;
            }
            set
            {
                _directoryInternal = value;
            }
        }

        private static INTApplication _applicationInternal;

        /// <summary>
        /// Static instance of an interface implementation <see cref="INTApplication"/>.
        /// </summary>
        public static INTApplication Application
        {
            get
            {
                if (_applicationInternal == null)
                {
                    _applicationInternal = new NTApplicationProxy();
                }

                return _applicationInternal;
            }
            set
            {
                _applicationInternal = value;
            }
        }

        private static INTScreen _screenInternal;

        /// <summary>
        /// Static instance of an interface implementation <see cref="INTScreen"/>.
        /// </summary>
        public static INTScreen Screen
        {
            get
            {
                if (_screenInternal == null)
                {
                    _screenInternal = new NTScreenProxy();
                }

                return _screenInternal;
            }
            set
            {
                _screenInternal = value;
            }
        }

        private static INTSceneManager _sceneManagerInternal;

        /// <summary>
        /// Static instance of an interface implementation <see cref="INTSceneManager"/>.
        /// </summary>
        public static INTSceneManager SceneManager
        {
            get
            {
                if (_sceneManagerInternal == null)
                {
                    _sceneManagerInternal = new NTSceneManagerProxy();
                }

                return _sceneManagerInternal;
            }
            set
            {
                _sceneManagerInternal = value;
            }
        }

        private static INTQualitySettings _qualitySettingsInternal;

        /// <summary>
        /// Static instance of an interface implementation <see cref="INTQualitySettings"/>.
        /// </summary>
        public static INTQualitySettings QualitySettings
        {
            get
            {
                if (_qualitySettingsInternal == null)
                {
                    _qualitySettingsInternal = new NTQualitySettingsProxy();
                }

                return _qualitySettingsInternal;
            }
            set
            {
                _qualitySettingsInternal = value;
            }
        }
    }
}
