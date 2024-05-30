using NotTwice.Serializables.Runtime.Enums;
using System;

namespace NotTwice.Serializables.Runtime.Operators
{
    /// <summary>
    /// Serializable class for condtiionning on float values
    /// </summary>
    [Serializable]
	public class NTSerializableFloatCondition : NTSerializableCondition<float>
	{
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
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

			switch (Operator)
			{
				case NTOperatorEnum.Inferior:
					return Value < parsedValue;
				case NTOperatorEnum.Superior:
					return Value > parsedValue;
				case NTOperatorEnum.InferorOrEqual:
					return Value < parsedValue || Value.Equals(parsedValue);
				case NTOperatorEnum.SuperiorOrEqual:
					return Value > parsedValue || Value.Equals(parsedValue);
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
