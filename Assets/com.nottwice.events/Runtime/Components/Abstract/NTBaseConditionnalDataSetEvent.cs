using NotTwice.Events.Runtime.ScriptableObjects.Abstract;
using NotTwice.Events.Runtime.Serializables.Abstract;
using UnityEngine;
using UnityEngine.Events;

namespace NotTwice.Events.Runtime.Components.Abstract
{
    /// <summary>
    /// Abstract class for defining a conditioned collection from a conditioned element and a collection of object/events pairs.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="NTBaseGameEvent<T, U>"/></typeparam>
    /// <typeparam name="U">Type of <see cref="UnityEventBase"/></typeparam>
    /// <typeparam name="V">Type of <see cref="NTBaseDataEventItem<T, U, V>"/></typeparam>
    public abstract class NTBaseConditionnalDataSetEvent<T, U, V> : MonoBehaviour
        where V : NTBaseDataEventItem<T, U, V>
        where T : NTBaseGameEvent<T, U>
        where U : UnityEventBase
    {
        /// <summary>
        /// Object used to retrieve the appropriate event corresponding to a collection of events
        /// </summary>
        [Tooltip("Object used to retrieve the appropriate event corresponding to a collection of events")]
        public V ConditionnedItem;

        /// <summary>
        /// Collection of object/events pairs to retrieve an event by comparing it with the conditioned object
        /// </summary>
        [Tooltip("Collection of object/events pairs to retrieve an event by comparing it with the conditioned object")]
        public NTBaseEventDataSet<T, U, V> DataEventItems;

        /// <summary>
        /// Method for defining the object to be used for event coresspondance
        /// </summary>
        /// <param name="conditionnedItem">Object to be supplied</param>
        public void SetConditionalItem(V conditionnedItem)
        {
            ConditionnedItem = conditionnedItem;
        }

        /// <summary>
        /// Method for retrieving the event associated with <see cref="NTBaseDataEventItem<T, U, V> attached"/>
        /// </summary>
        /// <returns>The event <see cref="NTBaseGameEvent<T, U> found"/></returns>
        public NTBaseGameEvent<T, U> GetTargetEvent()
        {
            return DataEventItems.DataSet.Find(dei => dei.IsSame(ConditionnedItem)).Event;
        }
    }
}
