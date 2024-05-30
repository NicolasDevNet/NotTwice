using System;

namespace Assets.com.nottwice.serializables.Runtime.Operators
{
	[Serializable]
	public class SerializableFloatCondition : SerializableCondition
	{
		public float Value;

		public override bool IsTrue(object toCompare)
		{
			if(toCompare == null)
			{
				return false;
			}

			if(!float.TryParse(toCompare.ToString(), out float parsedValue))
			{
				return false;
			}

			switch (OperatorEnum)
			{
				case OperatorEnum.Inferior:
					return Value < parsedValue;
				case OperatorEnum.Superior:
					return Value > parsedValue;
				case OperatorEnum.InferorOrEqual:
					return Value < parsedValue || Value.Equals(parsedValue);
				case OperatorEnum.SuperiorOrEqual:
					return Value > parsedValue || Value.Equals(parsedValue);
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
