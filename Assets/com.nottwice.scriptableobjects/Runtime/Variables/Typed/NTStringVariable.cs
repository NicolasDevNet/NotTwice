using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime.Variables.Typed
{
    /// <summary>
    /// Scriptable class containing a String variable
    /// </summary>
    [CreateAssetMenu(fileName = "StringVariable", menuName = "NotTwice/Variables/StringVariable")]
	public class NTStringVariable : NTScriptableVariable<string>
	{
	}
}
