using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveFloatVariable", menuName = "NotTwice/Variables/Reactives/ReactiveFloatVariable")]
	public class ReactiveFloatVariable : ScriptableObject
	{
		public FloatReactiveProperty Value;
	}
}
