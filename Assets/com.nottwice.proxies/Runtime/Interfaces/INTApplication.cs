using System;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Proxies.Runtime.Interfaces
{
	/// <summary>
	/// Interface contract outlining methods to be defined for unity application operations
	/// </summary>
	public interface INTApplication
	{
		string AbsoluteURL { get; }
		ThreadPriority BackgroundLoadingPriority { get; set; }
		string BuildGUID { get; }
		string CloudProjectId { get; }
		string CompanyName { get; }
		string ConsoleLogPath { get; }
		string DataPath { get; }
		bool Genuine { get; }
		bool GenuineCheckAvailable { get; }
		string Identifier { get; }
		string InstallerName { get; }
		ApplicationInstallMode InstallMode { get; }
		NetworkReachability InternetReachability { get; }
		bool IsBatchMode { get; }
		bool IsConsolePlatform { get; }
		bool IsEditor { get; }
		bool IsFocused { get; }
		bool IsMobilePlatform { get; }
		bool IsPlaying { get; }
		string PersistentDataPath { get; }
		RuntimePlatform Platform { get; }
		string ProductName { get; }
		bool RunInBackground { get; set; }
		ApplicationSandboxType SandboxType { get; }
		string StreamingAssetsPath { get; }
		SystemLanguage SystemLanguage { get; }
		int TargetFrameRate { get; set; }
		string TemporaryCachePath { get; }
		string UnityVersion { get; }
		string Version { get; }

		void AddDeepLinkActivatedAction(Action<string> action);
		void AddFocusChangedAction(Action<bool> action);
		void AddLogMessageReceivedAction(Application.LogCallback action);
		void AddLogMessageReceivedThreadedAction(Application.LogCallback action);
		void AddLowMemoryAction(Application.LowMemoryCallback action);
		void AddOnBeforeRenderAction(UnityAction action);
		void AddQuittingAction(Action action);
		void AddUnloadingAction(Action action);
		void AddWantsToQuitAction(Func<bool> func);
		bool CanStreamedLevelBeLoaded(int levelIndex);
		bool CanStreamedLevelBeLoaded(string levelName);
		string[] GetBuildTags();
		StackTraceLogType GetStackTraceLogType(LogType logType);
		bool HasProLicense();
		bool HasUserAuthorization(UserAuthorization userAuthorization);
		bool IsObjPlaying(UnityEngine.Object @object);
		void OpenURL(string url);
		void Quit();
		void Quit(int exitCode);
		void RemoveDeepLinkActivatedAction(Action<string> action);
		void RemoveFocusChangedAction(Action<bool> action);
		void RemoveLogMessageReceivedAction(Application.LogCallback action);
		void RemoveLogMessageReceivedThreadedAction(Application.LogCallback action);
		void RemoveLowMemoryAction(Application.LowMemoryCallback action);
		void RemoveOnBeforeRenderAction(UnityAction action);
		void RemoveQuittingAction(Action action);
		void RemoveUnloadingAction(Action action);
		void RemoveWantsToQuitAction(Func<bool> func);
		bool RequestAdvertisingIdentifierAsync(Application.AdvertisingIdentifierCallback callback);
		AsyncOperation RequestUserAuthorization(UserAuthorization userAuthorization);
		void SetBuildTags(string[] buildTags);
		void SetStackTraceLogType(LogType logType, StackTraceLogType stackTraceLogType);
		void Unload();
	}
}
