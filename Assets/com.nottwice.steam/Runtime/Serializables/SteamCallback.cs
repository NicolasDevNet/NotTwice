using Assets.com.nottwice.steam.Runtime.Providers.Facepunch.Components;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.com.nottwice.steam.Runtime.Serializables.Callbacks
{
	[Serializable]
	public class SteamCallback
	{
		[Tooltip("Réponse Unity utilisée quand le callback steam associé est aussi déclenché")]
		public FacepunchSteamEvent Response;

		[Tooltip("Réponse Unity utilisée quand une erreur est levée")]
		public UnityEvent ErrorHandler;
	}
}
