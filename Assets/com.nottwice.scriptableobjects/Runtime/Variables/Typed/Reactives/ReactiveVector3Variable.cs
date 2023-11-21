using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveVector3Variable", menuName = "NotTwice/Variables/Reactives/ReactiveVector3Variable")]
	public class ReactiveVector3Variable : ScriptableObject
	{
		public Vector3ReactiveProperty Value;
	}
}
