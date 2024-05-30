using UniRx;
using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime.Variables.Typed.Reactives
{
    /// <summary>
    /// Scriptable class containing a Boolean reactive variable
    /// </summary>
    [CreateAssetMenu(fileName = "ReactiveBoolVariable", menuName = "NotTwice/Variables/Reactives/ReactiveBoolVariable")]
	public class NTReactiveBoolVariable : ScriptableObject
	{
		public BoolReactiveProperty Value;
	}
}
