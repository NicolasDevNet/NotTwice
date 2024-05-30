using NotTwice.Serializables.Runtime.Enums;
using System;
using UnityEngine;

namespace NotTwice.Serializables.Runtime.Operators
{
    /// <summary>
    /// Serializable class for condtiionning on Vector2 values
    /// </summary>
    [Serializable]
	public class NTSerializableVector2Condition : NTSerializableCondition<Vector2>
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

			if (typeof(Vector2) != toCompare.GetType())
			{
				return false;
			}

			Vector2 parsedValue = (Vector2)toCompare;

			switch (Operator)
			{
				case NTOperatorEnum.Inferior:
					return Value.x < parsedValue.x || Value.y < parsedValue.y;
				case NTOperatorEnum.Superior:
					return Value.x > parsedValue.x || Value.y > parsedValue.y;
				case NTOperatorEnum.InferorOrEqual:
					return (Value.x < parsedValue.x || Value.y < parsedValue.y) || Value.Equals(parsedValue);
				case NTOperatorEnum.SuperiorOrEqual:
					return (Value.x > parsedValue.x || Value.y > parsedValue.y) || Value.Equals(parsedValue);
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
