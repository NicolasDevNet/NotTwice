using System;

namespace Assets.com.nottwice.serializables.Runtime.Operators
{
	[Serializable]
	public class SerializableBoolCondition : SerializableCondition
	{
		public bool Value;

		public override bool IsTrue(object toCompare)
		{
			if(toCompare == null)
			{
				return false;
			}

			if (!bool.TryParse(toCompare.ToString(), out bool parsedValue))
			{
				return false;
			}

			switch (OperatorEnum)
			{
				case OperatorEnum.Equal:
					return Value.Equals(toCompare);
				case OperatorEnum.NotEqual:
					return !Value.Equals(toCompare);
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
