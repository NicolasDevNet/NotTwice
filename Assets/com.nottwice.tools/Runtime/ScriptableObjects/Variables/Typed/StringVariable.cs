using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables.Typed
{
	[CreateAssetMenu(fileName = nameof(StringVariable), menuName = "NotTwice/Tools/Variables")]
	public class StringVariable : ScriptableVariable<string>
	{
	}
}
