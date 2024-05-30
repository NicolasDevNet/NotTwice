using System;
using UnityEngine;
using NotTwice.Serializables.Runtime.Enums;

namespace NotTwice.Serializables.Runtime.Operators
{
    /// <summary>
    /// Serializable class for condtiionning on Vector3 values
    /// </summary>
    [Serializable]
	public class NTSerializableVector3Condition : NTSerializableCondition<Vector3>
	{
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool IsTrue(object toCompare)
		{
			if (toCompare == null)
			{
				return false;
			}

			if (typeof(Vector3) != toCompare.GetType())
			{
				return false;
			}

			Vector3 parsedValue = (Vector3)toCompare;


			switch (Operator)
			{
				case NTOperatorEnum.Inferior:
					return Value.x < parsedValue.x || Value.y < parsedValue.y || Value.z < parsedValue.z;
				case NTOperatorEnum.Superior:
					return Value.x > parsedValue.x || Value.y > parsedValue.y || Value.z > parsedValue.z;
				case NTOperatorEnum.InferorOrEqual:
					return (Value.x < parsedValue.x || Value.y < parsedValue.y || Value.z < parsedValue.z) || Value.Equals(parsedValue);
				case NTOperatorEnum.SuperiorOrEqual:
					return (Value.x > parsedValue.x || Value.y > parsedValue.y || Value.z > parsedValue.z) || Value.Equals(parsedValue);
				case NTOperatorEnum.Equal:
					return Value.Equals(parsedValue);
				case NTOperatorEnum.NotEqual:
					return !Value.Equals(parsedValue);
				default:
					return false;
			}
		}
	}
}
