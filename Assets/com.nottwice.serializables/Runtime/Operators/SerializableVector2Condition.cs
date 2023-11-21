using System;
using UnityEngine;

namespace Assets.com.nottwice.serializables.Runtime.Operators
{
	[Serializable]
	public class SerializableVector2Condition : SerializableCondition
	{
		public Vector2 Value;

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

			switch (OperatorEnum)
			{
				case OperatorEnum.Inferior:
					return Value.x < parsedValue.x || Value.y < parsedValue.y;
				case OperatorEnum.Superior:
					return Value.x > parsedValue.x || Value.y > parsedValue.y;
				case OperatorEnum.InferorOrEqual:
					return (Value.x < parsedValue.x || Value.y < parsedValue.y) || Value.Equals(parsedValue);
				case OperatorEnum.SuperiorOrEqual:
					return (Value.x > parsedValue.x || Value.y > parsedValue.y) || Value.Equals(parsedValue);
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
