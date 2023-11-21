using Assets.com.nottwice.scriptableobjects.Runtime.Variables;

namespace Assets.com.nottwice.serializables.Runtime.References
{
	/// <summary>
	/// This object is not to be used directly, it is to be associated with a child member declaring the generic type.
	/// This object is used to define a value reference.
	/// </summary>
	public abstract class ScriptableReference<T>
	{
		public bool UseConstant = true;
		public T ConstantValue;
		public ScriptableVariable<T> Variable;

		public T Value
		{
			get { return UseConstant ? ConstantValue : Variable.Value; }
		}

		public override bool Equals(object other)
		{
			return Equals(other as ScriptableReference<T>);
		}

		public bool Equals(ScriptableReference<T> other)
		{
			if (other is null)
			{
				return false;
			}

			if(UseConstant)
			{
				if(other.UseConstant)
				{
					return ConstantValue.Equals(other.ConstantValue);
				}

				return ConstantValue.Equals(other.Variable.Value);
			}

			if (other.UseConstant)
			{
				return Variable.Value.Equals(other.ConstantValue);
			}

			return Variable.Equals(other.Variable);
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public static bool operator ==(ScriptableReference<T> lhs, ScriptableReference<T> rhs)
		{
			if (lhs is null)
			{
				if (rhs is null)
				{
					return true;
				}

				// Only the left side is null.
				return false;
			}

			// Equals handles case of null on right side.
			return lhs.Equals(rhs);
		}

		public static bool operator !=(ScriptableReference<T> lhs, ScriptableReference<T> rhs) => !(lhs == rhs);
	}
}
