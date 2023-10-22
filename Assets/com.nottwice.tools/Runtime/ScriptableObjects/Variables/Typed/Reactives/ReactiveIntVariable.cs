using UniRx;
using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveIntVariable", menuName = "NotTwice/Tools/Variables/Reactives/ReactiveIntVariable")]
	public class ReactiveIntVariable : ScriptableObject
	{
		public IntReactiveProperty Value;
	}
}
