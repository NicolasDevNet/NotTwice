using UniRx;
using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime.Variables.Typed.Reactives
{
    /// <summary>
    /// Scriptable class containing a Int reactive variable
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveIntVariable", menuName = "NotTwice/Variables/Reactives/ReactiveIntVariable")]
	public class NTReactiveIntVariable : ScriptableObject
	{
		public IntReactiveProperty Value;
	}
}
