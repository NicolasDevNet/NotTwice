using System;

namespace Assets.com.nottwice.serializables.Runtime.Operators
{
	[Serializable]
	public abstract class SerializableCondition
	{
		public OperatorEnum OperatorEnum;

		public abstract bool IsTrue(object toCompare);

		public abstract bool IsFalse(object toCompare);
	}
}
