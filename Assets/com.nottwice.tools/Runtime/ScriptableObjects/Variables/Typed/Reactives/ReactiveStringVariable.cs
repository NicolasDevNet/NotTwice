using UniRx;
using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveStringVariable", menuName = "NotTwice/Tools/Variables/Reactives/ReactiveStringVariable")]
	public class ReactiveStringVariable : ScriptableObject
	{
		public StringReactiveProperty Value;
	}
}
