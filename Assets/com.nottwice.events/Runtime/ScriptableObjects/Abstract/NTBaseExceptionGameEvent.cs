using System;


namespace NotTwice.Events.Runtime.ScriptableObjects.Abstract
{
    public class NTBaseExceptionGameEvent<T> : NTGenericGameEvent<NTBaseExceptionGameEvent<T>, T>
        where T : Exception
    {
    }
}
