using Steamworks.Data;
using Steamworks;
using UnityEngine.Events;

namespace Assets.com.nottwice.steam.Runtime.Providers.Facepunch.Components
{
	public class FacepunchSteamMessageEvent : UnityEvent<Lobby, Friend, string>
	{
	}
}
