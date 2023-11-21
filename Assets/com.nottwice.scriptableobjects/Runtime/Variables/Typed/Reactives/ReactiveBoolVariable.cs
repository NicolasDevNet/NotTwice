using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveBoolVariable", menuName = "NotTwice/Variables/Reactives/ReactiveBoolVariable")]
	public class ReactiveBoolVariable : ScriptableObject
	{
		public BoolReactiveProperty Value;
	}
}
