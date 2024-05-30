using NotTwice.Serializables.Runtime.Enums;
using System;

namespace NotTwice.Serializables.Runtime.Operators
{
    /// <summary>
    /// Serializable class for condtiionning on boolean values
    /// </summary>
    [Serializable]
	public class NTSerializableBoolCondition : NTSerializableCondition<bool>
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

			if (!bool.TryParse(toCompare.ToString(), out bool parsedValue))
			{
				return false;
			}

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
