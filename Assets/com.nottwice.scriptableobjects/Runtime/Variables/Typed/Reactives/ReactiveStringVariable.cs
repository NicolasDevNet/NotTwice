using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveStringVariable", menuName = "NotTwice/Variables/Reactives/ReactiveStringVariable")]
	public class ReactiveStringVariable : ScriptableObject
	{
		public StringReactiveProperty Value;
	}
}
