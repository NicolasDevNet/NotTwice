using UniRx;
using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime.Variables.Typed.Reactives
{
    /// <summary>
    /// Scriptable class containing a Vector3 reactive variable
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveVector3Variable", menuName = "NotTwice/Variables/Reactives/ReactiveVector3Variable")]
	public class NTReactiveVector3Variable : ScriptableObject
	{
		public Vector3ReactiveProperty Value;
	}
}
