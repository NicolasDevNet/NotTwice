using UniRx;
using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveFloatVariable", menuName = "NotTwice/Tools/Variables/Reactives/ReactiveFloatVariable")]
	public class ReactiveFloatVariable : ScriptableObject
	{
		public FloatReactiveProperty Value;
	}
}
