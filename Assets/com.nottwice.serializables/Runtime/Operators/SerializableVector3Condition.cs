using System;
using UnityEngine;

namespace Assets.com.nottwice.serializables.Runtime.Operators
{
	[Serializable]
	public class SerializableVector3Condition : SerializableCondition
	{
		public Vector3 Value;

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


			switch (OperatorEnum)
			{
				case OperatorEnum.Inferior:
					return Value.x < parsedValue.x || Value.y < parsedValue.y || Value.z < parsedValue.z;
				case OperatorEnum.Superior:
					return Value.x > parsedValue.x || Value.y > parsedValue.y || Value.z > parsedValue.z;
				case OperatorEnum.InferorOrEqual:
					return (Value.x < parsedValue.x || Value.y < parsedValue.y || Value.z < parsedValue.z) || Value.Equals(parsedValue);
				case OperatorEnum.SuperiorOrEqual:
					return (Value.x > parsedValue.x || Value.y > parsedValue.y || Value.z > parsedValue.z) || Value.Equals(parsedValue);
				case OperatorEnum.Equal:
					return Value.Equals(parsedValue);
				case OperatorEnum.NotEqual:
					return !Value.Equals(parsedValue);
				default:
					return false;
			}
		}

		public override bool IsFalse(object toCompare)
		{
			return !IsTrue(toCompare);
		}
	}
}
