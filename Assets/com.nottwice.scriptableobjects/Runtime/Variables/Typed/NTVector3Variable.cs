using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime.Variables.Typed
{
    /// <summary>
    /// Scriptable class containing a Vector3 variable
    /// </summary>
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "NotTwice/Variables/Vector3Variable")]
	public class NTVector3Variable : NTScriptableVariable<Vector3>
	{
	}
}
