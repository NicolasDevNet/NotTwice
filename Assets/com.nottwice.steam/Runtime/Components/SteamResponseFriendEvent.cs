using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.steam.Runtime.ScriptableObjects;
using NaughtyAttributes;
using Steamworks;
using Steamworks.Data;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.com.nottwice.steam.Runtime.Components
{
	public abstract class SteamResponseFriendEvent<T> : MonoBehaviour
		where T : class
	{
		[Required]
		public LobbySettings LobbySettings;

		public UnityEvent<Lobby, Friend, T> UnityEvent;

		private ILogger _logger;

		public void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
		}

		public void Execute(Lobby lobby, Friend friend, string content)
		{
			string[] args = content.Split(LobbySettings.ChatDataMessageSeparator);

			Type targetType = typeof(T);

			if (!string.Equals(args[0].ToLowerInvariant(), targetType.Name.ToLowerInvariant()))
			{
				return;
			}

			_logger.Log(LogType.Log, $"Receive a message of type: {args[0]}");

			UnityEvent?.Invoke(lobby, friend, JsonUtility.FromJson(args[1], targetType) as T);
		}
	}
}
