using UniRx;
using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed.Reactives
{
	[CreateAssetMenu(fileName = "ReactiveVector3Variable", menuName = "NotTwice/Tools/Variables/Reactives/ReactiveVector3Variable")]
	public class ReactiveVector3Variable : ScriptableObject
	{
		public Vector3ReactiveProperty Value;
	}
}
