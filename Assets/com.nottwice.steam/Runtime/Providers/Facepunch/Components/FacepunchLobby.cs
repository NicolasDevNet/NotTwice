using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.steam.Runtime.Providers.Facepunch.Proxies;
using NaughtyAttributes;
using UnityEngine;
using Unity.Netcode;
using Netcode.Transports.Facepunch;
using Steamworks.Data;
using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using Steamworks;
using Assets.com.nottwice.steam.Runtime.Serializables.Callbacks;
using Assets.com.nottwice.steam.Runtime.ScriptableObjects;

namespace Assets.com.nottwice.steam.Runtime.Providers.Facepunch.Components
{
	[AddComponentMenu("NotTwice/Multi/FacepunchLobby")]
	[DisallowMultipleComponent]
	public class FacepunchLobby : MonoBehaviour
	{
		#region Fields

		[Required, Tooltip("Shared network manager within the application")]
		public NetworkManager NetworkManager;

		[Required, Tooltip("Shared transport within the application")]
		public FacepunchTransport Transport;

		[Required, Tooltip("Maximum number of players that can be added to the lobby")]
		public Int32Variable MaxPlayers;

		[Required]
		public LobbySettings LobbySettings;

		#region Callbacks

		[Tooltip("Callback to invoke when OnLobbyCreated is raised.")]
		public SteamCallback OnLobbyCreatedCallback;

		[Tooltip("Callback to invoke when OnGameLobbyJoinRequested is raised.")]
		public SteamCallback OnGameLobbyJoinRequestedCallback;

		[Tooltip("Callback to invoke when OnLobbyMemberJoined is raised.")]
		public FacepunchSteamEvent OnLobbyMemberJoinedCallback;

		[Tooltip("Callback to invoke when OnLobbyMemberLeave is raised.")]
		public FacepunchSteamEvent OnLobbyMemberLeaveCallback;

		[Tooltip("Callback to invoke when OnLobbyMemberLeave is raised and the user is lobby's host.")]
		public FacepunchSteamEvent OnLobbyHostLeaveCallback;

		[Tooltip("Callback to invoke when OnLobbyDataChanged is raised.")]
		public FacepunchSteamEvent OnLobbyDataChangedCallback;

		[Tooltip("Callback to invoke when OnChatMessage is raised.")]
		public FacepunchSteamMessageEvent OnChatMessageCallback;

		#endregion

		#endregion

		public static FacepunchLobby Instance;

		public Lobby? CurrentLobby;

		private ILogger _logger;

		private IFacepunchSteam _facepunchSteam;

		#region Unity messages

		private void Awake()
		{
			_logger = AppContainer.Get<ILogger>();
			_facepunchSteam = AppContainer.Get<IFacepunchSteam>();
		}

		private void Start()
		{
			if (Instance == null)
			{
				Instance = this;
				DontDestroyOnLoad(gameObject);
				SetLobbyCallbacks();
			}
			else
			{
				//Replace old instance
				Destroy(Instance.gameObject);

				Instance = this;
				DontDestroyOnLoad(gameObject);
				SetLobbyCallbacks();
			}
		}

		private void OnDestroy()
		{
			RemoveLobbyCallbacks();

			if (NetworkManager == null)
			{
				return;
			}

			NetworkManager.OnServerStarted -= OnServerStarted;
			NetworkManager.OnClientConnectedCallback -= OnClientConnectedCallback;
			NetworkManager.OnClientDisconnectCallback -= OnClientDisconnectCallback;
		}

		private void OnApplicationQuit()
		{
			Disconnect();
		}

		#endregion

		#region Public

		public async void StartHost()
		{
			_logger.Log(LogType.Log, $"Trying to start hosting");

			NetworkManager.OnServerStarted += OnServerStarted;

			NetworkManager.StartHost();

			CurrentLobby = await _facepunchSteam.CreatelobbyAsync(MaxPlayers.Value);
		}

		public void LeaveLobby()
		{
			_logger.Log(LogType.Log, "Attempt to leave a lobby");

			if(CurrentLobby == null)
			{
				return;
			}

			CurrentLobby.Value.Leave();
		}

		/// <summary>
		/// Method for opening the steam invitation overlay
		/// </summary>
		public void OpenGameInviteOverlay()
		{
			if (CurrentLobby == null)
			{
				_logger.Log(LogType.Log, "No lobby created, overlay opening impossible");
				return;
			}

			_facepunchSteam.OpenGameInviteOverlay(CurrentLobby.Value.Id);

			_logger.Log(LogType.Log, "Steam overlay opening");
		}

		public void Disconnect()
		{
			_logger?.Log(LogType.Log, "Trying to disconnect");
			CurrentLobby?.Leave();
			if (NetworkManager == null)
			{
				return;
			}

			if (NetworkManager.IsHost)
			{
				NetworkManager.OnServerStarted -= OnServerStarted;
			}

			if (NetworkManager.IsClient)
			{
				NetworkManager.OnClientConnectedCallback -= OnClientConnectedCallback;
			}

			NetworkManager.Shutdown(true);
			_logger?.Log(LogType.Log, "Disconneted");
		}

		public void SendLobbyMessage(string message)
		{
			CurrentLobby?.SendChatString(message);
		}

		public void SendLobbyMessage<T>(T data)
			where T : class
		{
			CurrentLobby?.SendChatString($"{typeof(T).Name}{LobbySettings.ChatDataMessageSeparator}{JsonUtility.ToJson(data)}");
		}

		public void SetPublic()
		{
			CurrentLobby?.SetPublic();
		}

		public void SetPrivate()
		{
			CurrentLobby?.SetPrivate();
		}

		public void SetJoinable(bool isJoinable)
		{
			CurrentLobby?.SetJoinable(isJoinable);
		}

		public void SetFriendsOnly()
		{
			CurrentLobby?.SetFriendsOnly();
		}

		public void UpdateLobbySettings()
		{
			UpdateLobbySettings(CurrentLobby.Value);
		}

		#endregion

		#region Private

		private void UpdateLobbySettings(Lobby lobby)
		{
			if (LobbySettings.IsFriendsOnly)
			{
				lobby.SetFriendsOnly();
			}

			if (LobbySettings.IsPublic)
			{
				lobby.SetPublic();
			}
			else
			{
				lobby.SetPrivate();
			}

			lobby.SetJoinable(LobbySettings.IsJoinable);
		}

		private void StartClient(SteamId steamId)
		{
			NetworkManager.OnClientConnectedCallback += OnClientConnectedCallback;
			NetworkManager.OnClientDisconnectCallback += OnClientConnectedCallback;

			Transport.targetSteamId = steamId;

			if (NetworkManager.StartClient())
			{
				_logger.Log(LogType.Log, "Client has started");
			}
		}

		#endregion

		#region Callbacks

		private void SetLobbyCallbacks()
		{
			_facepunchSteam.SetOnLobbyCreated(OnLobbyCreated);
			_facepunchSteam.SetOnGameLobbyJoinRequested(OnGameLobbyJoinRequested);
			_facepunchSteam.SetOnLobbyMemberJoined(OnLobbyMemberJoined);
			_facepunchSteam.SetOnLobbyMemberLeave(OnLobbyMemberLeave);
			_facepunchSteam.SetOnLobbyDataChanged(OnLobbyDataChanged);
			_facepunchSteam.SetOnChatMessage(OnChatMessage);
			_facepunchSteam.SetOnLobbyInvite(OnLobbyInvite);
			_facepunchSteam.SetOnLobbyEntered(OnLobbyEntered);
		}

		private void RemoveLobbyCallbacks()
		{
			_facepunchSteam.RemoveOnLobbyCreated(OnLobbyCreated);
			_facepunchSteam.RemoveOnGameLobbyJoinRequested(OnGameLobbyJoinRequested);
			_facepunchSteam.RemoveOnLobbyMemberJoined(OnLobbyMemberJoined);
			_facepunchSteam.RemoveOnLobbyMemberLeave(OnLobbyMemberLeave);
			_facepunchSteam.RemoveOnLobbyDataChanged(OnLobbyDataChanged);
			_facepunchSteam.RemoveOnChatMessage(OnChatMessage);
			_facepunchSteam.RemoveOnLobbyInvite(OnLobbyInvite);
			_facepunchSteam.RemoveOnLobbyEntered(OnLobbyEntered);
		}

		private void OnLobbyCreated(Result result, Lobby lobby)
		{
			_logger.Log(LogType.Log, $"Lobby creation result: {result}");

			if(result == Result.OK || result == Result.AdministratorOK)
			{
				_logger.Log(LogType.Log, $"Lobby created: {lobby.Id}");

				UpdateLobbySettings(lobby);

				lobby.SetGameServer(lobby.Owner.Id);

				OnLobbyCreatedCallback.Response?.Invoke(lobby, lobby.Owner);

				return;
			}

			_logger.Log(LogType.Log, $"Creation lobby failure");

			OnLobbyCreatedCallback.ErrorHandler?.Invoke();
		}

		private async void OnGameLobbyJoinRequested(Lobby lobby, SteamId id)
		{
			_logger.Log(LogType.Log, $"User with id: {id.Value} is trying to join a lobby: {lobby}");

			RoomEnter joinedLobby = await lobby.Join();

			_logger.Log(LogType.Log, $"Operation status: {joinedLobby}");

			if (joinedLobby == RoomEnter.Success)
			{
				_logger.Log(LogType.Log, $"Lobby joined");

				CurrentLobby = lobby;

				OnGameLobbyJoinRequestedCallback.Response?.Invoke(lobby, new Friend(id));
			}
			else
			{
				_logger.Log(LogType.Log, $"The client was unable to join the lobby");

				OnLobbyCreatedCallback.ErrorHandler?.Invoke();
			}
		}

		private void OnLobbyEntered(Lobby lobby)
		{
			if (NetworkManager.IsHost)
			{
				//No need to go through this part if the guest is the one who joined the lobby
				return;
			}

			StartClient(lobby.Owner.Id);
		}

		private void OnLobbyMemberJoined(Lobby lobby, Friend friend)
		{
			_logger.Log(LogType.Log, $"User with id: {friend.Id} has joined the lobby");

			OnLobbyMemberJoinedCallback?.Invoke(lobby, friend);
		}

		private void OnLobbyMemberLeave(Lobby lobby, Friend friend)
		{
			_logger.Log(LogType.Log, $"User with id: {friend.Id} has left the lobby");

			if (lobby.IsOwnedBy(friend.Id))
			{
				_logger.Log(LogType.Log, $"Host left the lobby");

				OnLobbyHostLeaveCallback?.Invoke(lobby, friend);
			}
			else
			{
				OnLobbyMemberLeaveCallback?.Invoke(lobby, friend);
			}
		}

		private void OnLobbyDataChanged(Lobby lobby)
		{
			_logger.Log(LogType.Log, $"Lobby data updated. Lobby: {lobby.Id}");

			OnLobbyDataChangedCallback?.Invoke(lobby, lobby.Owner);
		}

		private void OnChatMessage(Lobby lobby, Friend friend, string message)
		{
			_logger.Log(LogType.Log, $"Chat message recieved. Lobby: {lobby.Id} | Sender: {friend.Id} | Message: {message}");

			OnChatMessageCallback?.Invoke(lobby, friend, message);
		}

		private void OnLobbyInvite(Friend friend, Lobby lobby)
		{
			_logger.Log(LogType.Log, $"Recieve an invite from: {friend.Id} to join lobby: {lobby.Id}");
		}

		private void OnServerStarted()
		{
			_logger.Log(LogType.Log, $"Host started");
		}

		private void OnClientConnectedCallback(ulong ip)
		{
			_logger.Log(LogType.Log, $"Client connected");
		}

		private void OnClientDisconnectCallback(ulong ip)
		{
			_logger.Log(LogType.Log, $"Client disconnected");
		}

		#endregion
	}
}
