using UniRx;
using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveVector2Variable", menuName = "NotTwice/Tools/Variables/Reactives/ReactiveVector2Variable")]
	public class ReactiveVector2Variable : ScriptableObject
	{
		public Vector2ReactiveProperty Value;
	}
}
