using NotTwice.Proxies.Runtime.Interfaces;
using System;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Application;

namespace Assets.com.nottwice.proxies.Runtime
{
	/// <summary>
	/// Proxy acting as a flat pass for <see cref="Application"/> static methods.
	/// </summary>
	public class NTApplicationProxy : INTApplication
    {
        #region Properties

        public string AbsoluteURL 
        {
            get
            {
                return absoluteURL;
            }
        }

        public ThreadPriority BackgroundLoadingPriority
        {
            get
            {
                return backgroundLoadingPriority;
            }
            set
            {
                backgroundLoadingPriority = value;
            }
        }

        public string BuildGUID
        {
            get
            {
                return buildGUID;
            }
        }

        public string CloudProjectId
        {
            get
            {
                return cloudProjectId;
            }
        }

        public string CompanyName
        {
            get
            {
                return companyName;
            }
        }

        public string ConsoleLogPath
        {
            get
            {
                return consoleLogPath;
            }
        }

        public string DataPath
        {
            get
            {
                return dataPath;
            }
        }

        public bool Genuine
        {
            get
            {
                return genuine;
            }
        }

        public bool GenuineCheckAvailable
        {
            get
            {
                return genuineCheckAvailable;
            }
        }

        public string Identifier
        {
            get
            {
                return identifier;
            }
        }

        public string InstallerName
        {
            get
            {
                return installerName;
            }
        }

        public ApplicationInstallMode InstallMode
        {
            get
            {
                return installMode;
            }
        }

        public NetworkReachability InternetReachability
        {
            get
            {
                return internetReachability;
            }
        }

        public bool IsBatchMode
        {
            get
            {
                return isBatchMode;
            }
        }

        public bool IsConsolePlatform
        {
            get
            {
                return isConsolePlatform;
            }
        }

        public bool IsEditor
        {
            get
            {
                return isEditor;
            }
        }

        public bool IsFocused
        {
            get
            {
                return isFocused;
            }
        }

        public bool IsMobilePlatform
        {
            get
            {
                return isMobilePlatform;
            }
        }

        public bool IsPlaying
        {
            get
            {
                return isPlaying;
            }
        }

        public string PersistentDataPath
        {
            get
            {
                return persistentDataPath;
            }
        }

        public RuntimePlatform Platform
        {
            get
            {
                return platform;
            }
        }

        public string ProductName
        {
            get
            {
                return productName;
            }
        }

        public bool RunInBackground
        {
            get
            {
                return runInBackground;
            }
            set
            {
                runInBackground = value;
            }
        }

        public ApplicationSandboxType SandboxType
        {
            get
            {
                return sandboxType;
            }
        }

        public string StreamingAssetsPath
        {
            get
            {
                return streamingAssetsPath;
            }
        }

        public SystemLanguage SystemLanguage
        {
            get
            {
                return systemLanguage;
            }
        }

        public int TargetFrameRate
        {
            get
            {
                return targetFrameRate;
            }
            set
            {
                targetFrameRate = value;
            }
        }

        public string TemporaryCachePath
        {
            get
            {
                return temporaryCachePath;
            }
        }

        public string UnityVersion
        {
            get
            {
                return unityVersion;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }
        }

        #endregion

        #region Methods

        #region Delegate accessors

        public void AddQuittingAction(Action action)
        {
            quitting += action;
        }

        public void RemoveQuittingAction(Action action)
        {
            quitting -= action;
        }

        public void AddWantsToQuitAction(Func<bool> func)
        {
            wantsToQuit += func;
        }

        public void RemoveWantsToQuitAction(Func<bool> func)
        {
            wantsToQuit -= func;
        }

        public void AddDeepLinkActivatedAction(Action<string> action)
        {
            deepLinkActivated += action;
        }

        public void RemoveDeepLinkActivatedAction(Action<string> action)
        {
            deepLinkActivated -= action;
        }

        public void AddFocusChangedAction(Action<bool> action)
        {
            focusChanged += action;
        }

        public void RemoveFocusChangedAction(Action<bool> action)
        {
            focusChanged -= action;
        }

        public void AddLogMessageReceivedAction(LogCallback action)
        {
            logMessageReceived += action;
        }

        public void RemoveLogMessageReceivedAction(LogCallback action)
        {
            logMessageReceived -= action;
        }

        public void AddLogMessageReceivedThreadedAction(LogCallback action)
        {
            logMessageReceivedThreaded += action;
        }

        public void RemoveLogMessageReceivedThreadedAction(LogCallback action)
        {
            logMessageReceivedThreaded -= action;
        }

		public void AddLowMemoryAction(LowMemoryCallback action)
		{
			lowMemory += action;
		}

		public void RemoveLowMemoryAction(LowMemoryCallback action)
		{
			lowMemory -= action;
		}

		public void AddOnBeforeRenderAction(UnityAction action)
		{
			onBeforeRender += action;
		}

		public void RemoveOnBeforeRenderAction(UnityAction action)
		{
			onBeforeRender -= action;
		}

		public void AddUnloadingAction(Action action)
		{
			unloading += action;
		}

		public void RemoveUnloadingAction(Action action)
		{
			unloading -= action;
		}

		#endregion

		public bool HasUserAuthorization(UserAuthorization userAuthorization)
        {
            return Application.HasUserAuthorization(userAuthorization);
        }

		public bool CanStreamedLevelBeLoaded(int levelIndex)
		{
			return Application.CanStreamedLevelBeLoaded(levelIndex);
		}

		public bool CanStreamedLevelBeLoaded(string levelName)
		{
			return Application.CanStreamedLevelBeLoaded(levelName);
		}

		public string[] GetBuildTags()
		{
			return Application.GetBuildTags();
		}

		public StackTraceLogType GetStackTraceLogType(LogType logType)
		{
			return Application.GetStackTraceLogType(logType);
		}

		public bool HasProLicense()
		{
			return Application.HasProLicense();
		}

		public bool IsObjPlaying(UnityEngine.Object @object)
		{
			return Application.IsPlaying(@object);
		}

		public void OpenURL(string url)
		{
			Application.OpenURL(url);
		}

		public void Quit()
		{
			Application.Quit();
		}

		public void Quit(int exitCode)
		{
			Application.Quit(exitCode);
		}

		public bool RequestAdvertisingIdentifierAsync(AdvertisingIdentifierCallback callback)
		{
			return Application.RequestAdvertisingIdentifierAsync(callback);
		}

		public AsyncOperation RequestUserAuthorization(UserAuthorization userAuthorization)
		{
			return Application.RequestUserAuthorization(userAuthorization);
		}

		public void SetBuildTags(string[] buildTags)
		{
			Application.SetBuildTags(buildTags);
		}

		public void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceLogType)
		{
			Application.SetStackTraceLogType(LogType.Log, stackTraceLogType);
		}

		public void Unload()
		{
			Application.Unload();
		}

		#endregion
	}
}
