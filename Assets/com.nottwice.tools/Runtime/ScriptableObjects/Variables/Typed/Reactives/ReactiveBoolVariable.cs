using UniRx;
using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveBoolVariable", menuName = "NotTwice/Tools/Variables/Reactives/ReactiveBoolVariable")]
	public class ReactiveBoolVariable : ScriptableObject
	{
		public BoolReactiveProperty Value;
	}
}
