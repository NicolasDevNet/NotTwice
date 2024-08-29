using UnityEngine;

namespace NotTwice.Patterns.Commands.Runtime.Abstract
{
    /// <summary>
    /// NTBaseCommand is an abstract class that serves as the base for all command objects in the Command pattern.
    /// This class inherits from ScriptableObject, allowing commands to be created and managed as assets in Unity.
    /// </summary>
    public abstract class NTBaseCommand : ScriptableObject
    {
        /// <summary>
        /// The name of the command, used for identification and debugging purposes.
        /// </summary>
        public string Name;
    }
}