using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveVector2Variable", menuName = "NotTwice/Variables/Reactives/ReactiveVector2Variable")]
	public class ReactiveVector2Variable : ScriptableObject
	{
		public Vector2ReactiveProperty Value;
	}
}
