using NaughtyAttributes;
using UnityEngine;

namespace Assets.com.nottwice.scene.Runtime.ScriptableObjects
{
	[CreateAssetMenu(fileName = "SceneConfiguration", menuName = "NotTwice/Configurations/Scene/SceneConfiguration")]
	public class SceneConfiguration : ScriptableObject
	{
		[Scene]
		public string Name;
	}
}
