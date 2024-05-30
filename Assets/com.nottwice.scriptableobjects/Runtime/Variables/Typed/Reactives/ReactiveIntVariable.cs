using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveIntVariable", menuName = "NotTwice/Variables/Reactives/ReactiveIntVariable")]
	public class ReactiveIntVariable : ScriptableObject
	{
		public IntReactiveProperty Value;
	}
}
