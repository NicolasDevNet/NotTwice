using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using System;

namespace NotTwice.Events.Runtime.Components.Abstract
{
    /// <summary>
    /// Abstract Unity component for passing information of type <see cref="Exception"/> through a chain of events.
    /// </summary>
    /// <typeparam name="T">Type of Exception</typeparam>
    public class NTBaseExceptionGameEventListener<T> : NTGenericEventListener<NTBaseExceptionGameEvent<T>, T>
        where T : Exception
    {

    }
}
