using Steamworks;
using Steamworks.Data;
using System;
using UnityEngine.Events;

namespace Assets.com.nottwice.steam.Runtime.Providers.Facepunch.Components
{
	[Serializable]
	public class FacepunchSteamEvent : UnityEvent<Lobby, Friend>
	{
	}
}
