using UnityEngine;

namespace Assets.com.nottwice.scriptableobjects.Runtime.Variables
{
	/// <summary>
	/// This scriptable object is not to be used directly, it is to be associated with a child member declaring the generic type.
	/// This object is used to define a scriptable variable to be used define in the editor via the contextual menu.
	/// </summary>
	public abstract class ScriptableVariable<T> : ScriptableObject
	{
		[Tooltip("Valeur de type T de la variable")]
		public T Value;

		public override bool Equals(object other)
		{
			return Equals(other as ScriptableVariable<T>);
		}

		public bool Equals(ScriptableVariable<T> other)
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

		public static bool operator ==(ScriptableVariable<T> lhs, ScriptableVariable<T> rhs)
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

		public static bool operator !=(ScriptableVariable<T> lhs, ScriptableVariable<T> rhs) => !(lhs == rhs);
	}
}
