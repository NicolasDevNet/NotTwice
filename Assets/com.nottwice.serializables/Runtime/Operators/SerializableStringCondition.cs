using System;

namespace Assets.com.nottwice.serializables.Runtime.Operators
{
	[Serializable]
	public class SerializableStringCondition : SerializableCondition
	{
		public string Value;

		public override bool IsTrue(object toCompare)
		{
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
