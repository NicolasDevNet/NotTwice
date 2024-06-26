﻿using NaughtyAttributes;
using NotTwice.Proxies.Runtime;
using NotTwice.Proxies.Runtime.Interfaces;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;
using UnityEngine;

namespace NotTwice.Components.Runtime.Application
{
	/// <summary>
	/// Component to redirect the user to the url when opening a new browser or tab.
	/// </summary>
	[AddComponentMenu("NotTwice/Application/OpenURL")]
	[DisallowMultipleComponent]
	public class NTOpenURL : MonoBehaviour
	{
		[Expandable ,Tooltip("Optional parameter used if the use of the component requires a method without parameters.")]
		public NTStringVariable UrlToRedirect;

        /// <summary>
        /// Method for opening a URL from the <see cref="NTStringVariable"/> associated with the component.
        /// </summary>
        public void ExecuteOpeningURL()
		{
			if(UrlToRedirect == null)
			{
				throw new MissingComponentException("A StringVariable is needed to use this method.");
			}

			ExecuteOpeningURL(UrlToRedirect);
		}

        /// <summary>
        /// Method for opening a URL from the <see cref="NTStringVariable"/> associated with the component.
        /// </summary>
        public void ExecuteOpeningURL(NTStringVariable targetUrl)
		{
			Debug.Log($"Redirect to {targetUrl.Value}");
			NTProxiesProvider.Application.OpenURL(targetUrl.Value);
		}
	}
}
