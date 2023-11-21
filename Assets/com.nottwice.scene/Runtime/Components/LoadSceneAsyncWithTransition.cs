using Assets.com.nottwice.scene.Runtime.ScriptableObjects;
using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.com.nottwice.scene.Runtime.Components
{
	/// <summary>
	/// Component for asynchronous scene loading with a transition requiring specific configuration
	/// </summary>
	[AddComponentMenu("NotTwice/Scene/LoadSceneAsyncWithTransition")]
	[DisallowMultipleComponent]
	public class LoadSceneAsyncWithTransition : LoadSceneAsync
	{
		[Tooltip("Transition scene setup")]
		[Required]
		public SceneTransitionConfiguration SceneTransitionConfiguration;

		[Tooltip("Variable used to store the scene selection in the case of a transition.")]
		[Required]
		public StringVariable TargetSceneStorage;

		[Tooltip("Variable used to store the scene preceding the transition.")]
		[Required]
		public StringVariable PreviousSceneStorage;

		public new void Execute()
		{
			Execute(OptionalTargetScene);
		}

		public void Execute(SceneConfiguration targetScene)
		{
			ApplicationInstancesContainer.Logger.Log(LogType.Log, $"Transition to {targetScene.Name} started");

			//Stores the value of the previous scene
			PreviousSceneStorage.Value = SceneInstancesContainer.SceneManager.GetActiveScene().name;

			//Stores the scene value and additively loads the transition scene
			TargetSceneStorage.Value = targetScene.Name;

			SceneInstancesContainer.SceneManager.LoadSceneAsync(SceneTransitionConfiguration.SceneName, LoadSceneMode.Additive);
		}
	}
}
