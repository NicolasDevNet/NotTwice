using NotTwice.Serializables.Runtime.Enums;
using System;

namespace NotTwice.Serializables.Runtime.Operators
{
    /// <summary>
    /// Serializable class for condtiionning on string values
    /// </summary>
    [Serializable]
	public class NTSerializableStringCondition : NTSerializableCondition<string>
	{
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override bool IsTrue(object toCompare)
		{
			switch (Operator)
			{
				case NTOperatorEnum.Equal:
					return Value.Equals(toCompare);
				case NTOperatorEnum.NotEqual:
					return !Value.Equals(toCompare);
				default:
					return false;
			}
		}
	}
}
