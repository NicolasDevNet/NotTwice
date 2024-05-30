using UniRx;
using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime.Variables.Typed.Reactives
{
    /// <summary>
    /// Scriptable class containing a Float reactive variable
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveFloatVariable", menuName = "NotTwice/Variables/Reactives/ReactiveFloatVariable")]
	public class NTReactiveFloatVariable : ScriptableObject
	{
		public FloatReactiveProperty Value;
	}
}
