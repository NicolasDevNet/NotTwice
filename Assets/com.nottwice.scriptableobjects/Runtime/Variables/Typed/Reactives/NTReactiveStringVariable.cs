using UniRx;
using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime.Variables.Typed.Reactives
{
    /// <summary>
    /// Scriptable class containing a String reactive variable
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveStringVariable", menuName = "NotTwice/Variables/Reactives/ReactiveStringVariable")]
	public class NTReactiveStringVariable : ScriptableObject
	{
		public StringReactiveProperty Value;
	}
}
