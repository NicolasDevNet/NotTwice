using NaughtyAttributes;
using NotTwice.ScriptableObjects.Runtime;
using UnityEngine;

namespace NotTwice.Serializables.Runtime.References
{
    /// <summary>
    /// Abstract class providing the methods and properties needed to create a reference concept with scriptable objects.
    /// </summary>
    public abstract class NTScriptableReference<T>
	{
        /// <summary>
        /// Determines whether or not to use a constant value
        /// </summary>
        [Tooltip("Determines whether or not to use a constant value")]
		public bool UseConstant = true;

		/// <summary>
		/// The constant value to be filled in, which will be used instead of the value contained in the scripted variable.
		/// </summary>
		[ShowIf(nameof(UseConstant))]
        [Tooltip("The constant value to be filled in, which will be used instead of the value contained in the scripted variable.")]
		public T ConstantValue;

        /// <summary>
        /// Reference variable used to determine the value of this scriptable reference
        /// </summary>
        [Expandable ,Tooltip("Reference variable used to determine the value of this scriptable reference")]
		public NTScriptableVariable<T> Variable;

		/// <summary>
		/// Valeur de la cette référence scriptable
		/// </summary>
		public T Value
		{
			get { return UseConstant ? ConstantValue : Variable.Value; }
		}

		public override bool Equals(object other)
		{
			return Equals(other as NTScriptableReference<T>);
		}

		public bool Equals(NTScriptableReference<T> other)
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

		public static bool operator ==(NTScriptableReference<T> lhs, NTScriptableReference<T> rhs)
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

		public static bool operator !=(NTScriptableReference<T> lhs, NTScriptableReference<T> rhs) => !(lhs == rhs);
	}
}
