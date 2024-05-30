using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime.Variables.Typed
{
    /// <summary>
    /// Scriptable class containing a Color variable
    /// </summary>
    [CreateAssetMenu(fileName = "ColorVariable", menuName = "NotTwice/Variables/ColorVariable")]
	public class NTColorVariable : NTScriptableVariable<Color>
	{
	}
}
