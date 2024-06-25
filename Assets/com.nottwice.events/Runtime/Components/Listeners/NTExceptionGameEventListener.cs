using NotTwice.Events.Runtime.Components.Abstract;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using System;
using UnityEngine;

namespace NotTwice.Events.Runtime.Components.Listeners
{
    /// <summary>
    /// Event listening component for an event of type <see cref="NTExceptionGameEvent"/>.
    /// </summary>
    [AddComponentMenu("NotTwice/Events/Listeners/ExceptionGameEventListener")]
    public class NTExceptionGameEventListener : NTGenericEventListener<NTExceptionGameEvent, Exception>
    {

    }
}
