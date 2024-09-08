using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NotTwice.Events.Runtime.ScriptableObjects.Events
{
	/// <summary>
	/// Scriptable event class for passing a Scene value through the event chain
	/// </summary>
	[CreateAssetMenu(fileName = "SceneGameEvent", menuName = "NotTwice/Events/SceneGameEvent")]
	public class NTSceneGameEvent : NTGenericGameEvent<NTSceneGameEvent, Scene>
	{
	}
}
