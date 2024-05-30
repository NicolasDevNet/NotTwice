using NotTwice.Serializables.Runtime.Enums;
using UnityEngine;

namespace NotTwice.Serializables.Runtime.Operators
{
    /// <summary>
    /// Abstract class providing basic methods for packaged serializable objects
    /// </summary>
    public abstract class NTSerializableCondition<T>
	{
        /// <summary>
        /// Associated value for comparison
        /// </summary>
        [Tooltip("Associated value for comparison")]
        public T Value;

        /// <summary>
        /// Operator to be used for value comparison
        /// </summary>
        [Tooltip("Operator to be used for value comparison")]
		public NTOperatorEnum Operator;

        /// <summary>
        /// Method for checking whether the value comparison of two objects is true
        /// </summary>
        /// <param name="toCompare">The object to be compared</param>
        /// <returns>The result of the comparison</returns>
		public abstract bool IsTrue(object toCompare);

        /// <summary>
        /// Method for checking whether the value comparison of two objects is false
        /// </summary>
        /// <param name="toCompare">The object to be compared</param>
        /// <returns>The result of the comparison</returns>
		public bool IsFalse(object toCompare)
        {
            return !IsTrue(toCompare);
        }
	}
}
