using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed
{
	[CreateAssetMenu(fileName = nameof(Int32Variable), menuName = "NotTwice/Tools/Variables")]
	public class Int32Variable : ScriptableVariable<int>
	{
	}
}
