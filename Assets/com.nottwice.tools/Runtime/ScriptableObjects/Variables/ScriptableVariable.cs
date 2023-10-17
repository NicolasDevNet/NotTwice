using UnityEngine;

namespace Assets.NotTwice.Tools.Runtime.ScriptableObjects.Variables
{
	/// <summary>
	/// Cet objet scriptable n'est pas à utilisé directement, il est à associer avec un membre enfant déclarant le type générique.
	/// Cet objet permet de définir une variable scriptable à utiliser définir dans l'éditeur via le menu contextuel.
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
