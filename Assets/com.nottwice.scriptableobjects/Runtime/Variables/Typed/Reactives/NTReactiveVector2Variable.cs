using UniRx;
using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime.Variables.Typed.Reactives
{
    /// <summary>
    /// Scriptable class containing a Vector2 reactive variable
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveVector2Variable", menuName = "NotTwice/Variables/Reactives/ReactiveVector2Variable")]
	public class NTReactiveVector2Variable : ScriptableObject
	{
		public Vector2ReactiveProperty Value;
	}
}
