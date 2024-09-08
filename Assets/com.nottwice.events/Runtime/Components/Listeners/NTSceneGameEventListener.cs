using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotTwice.Events.Runtime.Components.Listeners
{
	/// <summary>
	/// Event listening component for an event of type <see cref="NTSceneGameEvent"/>.
	/// </summary>
	[AddComponentMenu("NotTwice/Events/Listeners/SceneGameEventListener")]
    public class NTSceneGameEventListener : NTGenericEventListener<NTSceneGameEvent, Scene>
    {

    }
}
