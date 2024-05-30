using UnityEngine;

namespace NotTwice.ScriptableObjects.Runtime
{
	/// <summary>
	/// This scriptable object is not to be used directly, it is to be associated with a child member declaring the generic type.
	/// This object is used to define a scriptable variable to be used define in the editor via the contextual menu.
	/// </summary>
	public abstract class NTScriptableVariable<T> : ScriptableObject
	{
		[Tooltip("Type T value of the variable")]
		public T Value;

		public override bool Equals(object other)
		{
			return Equals(other as NTScriptableVariable<T>);
		}

		public bool Equals(NTScriptableVariable<T> other)
		{
			if (other is null)
			{
				return false;
			}

			return Value.Equals(other.Value);
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public static bool operator ==(NTScriptableVariable<T> lhs, NTScriptableVariable<T> rhs)
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

		public static bool operator !=(NTScriptableVariable<T> lhs, NTScriptableVariable<T> rhs) => !(lhs == rhs);
	}
}
